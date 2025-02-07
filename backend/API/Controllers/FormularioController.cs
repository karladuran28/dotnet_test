using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API;

[ApiController]
[Route("api/[controller]")] // api/formularios
public class FormulariosController : ControllerBase 
{
  private readonly IFormularioRepository _formularioRepository;

  public FormulariosController(IFormularioRepository formularioRepository)
  {
    _formularioRepository = formularioRepository;
  }

  // Método GET para obtener todos los formularios
  [HttpGet(Name = "GetFormularios")]
  public async Task<ActionResult<List<Formulario>>> GetFormularios()
  {
    var formularios = await _formularioRepository.GetFormulariosAsync();

    return Ok(formularios);
  }

  // Método GET para obtener un formulario por su ID
  [HttpGet("{id:int}")]
  public async Task<ActionResult<RespFormularioViewDTO>> ObtenerFormularioPorId(int id)
  {
    // Obtener el formulario desde la base de datos
    var formulario = await _formularioRepository.GetFormularioAsync(id);

    if (formulario == null)
    {
      return NotFound();
    }

    var formularioDto = new FormularioViewDTO
    {
      Id = formulario.Id,
      Nombre = formulario.Nombre,
      Inputs = [.. formulario.Inputs.Select(input => new InputViewDTO
      {
        Id = input.Id,
        Nombre = input.Nombre,
        TipoDato = input.TipoDato,
        EsObligatorio = input.EsObligatorio
      })]
    };

    return Ok(formularioDto);
  }
}

