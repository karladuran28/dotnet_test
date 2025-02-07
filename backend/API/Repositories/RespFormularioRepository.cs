using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public interface IRespFormularioRepository 
{
  Task<RespuestaFormulario> GetRespuestaFormularioAsync(int id);
  Task<List<RespuestaFormulario>> GetRespuestasPorFormularioAsync(int formularioId);
  Task CrearRespuestaFormularioAsync(RespuestaFormulario respuestaFormulario);
  Task ActualizarRespuestaFormularioAsync(RespuestaFormulario respuestaFormulario);
  Task EliminarRespuestaFormularioAsync(int id);
}

public class RespFormularioRepository(DataContext context) : IRespFormularioRepository
{

  public async Task<RespuestaFormulario> GetRespuestaFormularioAsync(int id)
  {
    var respuestaFormulario = await context.RespuestasFormularios
      .Include(rf => rf.RespuestasInputs)
      .FirstOrDefaultAsync(rf => rf.Id == id);

    return respuestaFormulario ?? throw new KeyNotFoundException($"No se encontró el formulario con ID {id}");
  }

  public async Task<List<RespuestaFormulario>> GetRespuestasPorFormularioAsync(int formularioId)
  {
    var respuestasPorFormulario = await context.RespuestasFormularios
      .Where(rf => rf.FormularioId == formularioId)
      .Include(rf => rf.RespuestasInputs)
      .ToListAsync();
    
    return respuestasPorFormulario ?? throw new KeyNotFoundException($"No se encontraron respuestas para el formulario con ID {formularioId}");
  }

  // Crear una nueva respuesta de formulario
  public async Task CrearRespuestaFormularioAsync(RespuestaFormulario respuestaFormulario)
  {
    context.RespuestasFormularios.Add(respuestaFormulario);
    await context.SaveChangesAsync();
  }

  // Actualizar una respuesta de formulario existente
  public async Task ActualizarRespuestaFormularioAsync(RespuestaFormulario respuestaFormulario)
  {
    context.RespuestasFormularios.Update(respuestaFormulario);
    await context.SaveChangesAsync();
  }

  // Eliminar una respuesta de formulario
  public async Task EliminarRespuestaFormularioAsync(int id)
  {
    var respuestaFormulario = await context.RespuestasFormularios.FindAsync(id);
    if (respuestaFormulario != null)
    {
      context.RespuestasFormularios.Remove(respuestaFormulario);
      await context.SaveChangesAsync();
    }
  }

}