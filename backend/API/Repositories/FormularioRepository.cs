using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public interface IFormularioRepository 
{
  Task<List<Formulario>> GetFormulariosAsync();
  Task<Formulario> GetFormularioAsync(int id);
}


public class FormularioRepository(DataContext context) : IFormularioRepository
{
  public async Task<List<Formulario>> GetFormulariosAsync()
  {
    var formularios = await context.Formularios
    .ToListAsync();

    return formularios;
  }

  public async Task<Formulario> GetFormularioAsync(int id)
  {
    var formulario = await context.Formularios
      .Include(rf => rf.Inputs)
      .FirstOrDefaultAsync(rf => rf.Id == id);

    return formulario ?? throw new KeyNotFoundException($"No se encontró el formulario con ID {id}");
  }

}