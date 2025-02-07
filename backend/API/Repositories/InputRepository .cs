using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public interface IInputRepository 
{
  Task<List<Input>> GetInputsAsync();
  Task<Input> GetInputAsync(int id);
  Task<Input> ActualizarInputAsync(int id, Input inputActualizado);
  Task EliminarInputAsync(int id);
  // Task CrearRespuestaInputAsync(RespuestaInput respuestaInput);
  // Task EliminarRespuestaInputAsync(int id);
}

public class InputRepository(DataContext context) : IInputRepository
{
  public async Task<List<Input>> GetInputsAsync()
  {
    var inputs = await context.Inputs
    .ToListAsync();
    
    return inputs;
  }

  public async Task<Input> GetInputAsync(int id)
  {
    var input = await context.Inputs
      .FirstOrDefaultAsync(rf => rf.Id == id);

    return input ?? throw new KeyNotFoundException($"No se encontró el input con ID {id}");
  }

  public async Task<Input> ActualizarInputAsync(int id, Input inputActualizado)
  {
    var inputExistente = await context.Inputs
      .FirstOrDefaultAsync(rf => rf.Id == id);

    if (inputExistente == null)
    {
        throw new KeyNotFoundException($"No se encontró el input con ID {id}");
    }

    inputExistente.Nombre = inputActualizado.Nombre;
    inputExistente.EsObligatorio = inputActualizado.EsObligatorio;
    inputExistente.TipoDato = inputActualizado.TipoDato;

    await context.SaveChangesAsync();
    return inputExistente;
  }

  public async Task EliminarInputAsync(int id)
  {
    var inputExistente = await context.Inputs
      .FirstOrDefaultAsync(rf => rf.Id == id);

    if (inputExistente == null)
    {
        throw new KeyNotFoundException($"No se encontró el input con ID {id}");
    }

    context.Inputs.Remove(inputExistente);
    await context.SaveChangesAsync();
  }

}