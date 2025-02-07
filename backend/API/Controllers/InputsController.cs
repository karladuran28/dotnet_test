using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace API;

[ApiController]
[Route("api/[controller]")] // api/input
public class InputsController : ControllerBase 
{
  private readonly IInputRepository _inputRepository;

  public InputsController(IInputRepository inputRepository)
  {
    _inputRepository = inputRepository;
  }

  // Método GET para obtener todos los inputs
  [HttpGet(Name = "GetInputs")]
  public async Task<ActionResult<List<Input>>> GetInputs()
  {
    var inputs = await _inputRepository.GetInputsAsync();
    return Ok(inputs);
  }

  // Método GET para obtener un input por su ID
  [HttpGet("{id:int}")]
  public async Task<ActionResult<InputViewDTO>> ObtenerInputPorId(int id)
  {
    // Obtener el formulario desde la base de datos
    var input = await _inputRepository.GetInputAsync(id);

    if (input == null)
    {
      return NotFound();
    }

    var inputDto = new InputViewDTO
    {
      Id = input.Id,
      Nombre = input.Nombre,
      TipoDato = input.TipoDato,
      EsObligatorio = input.EsObligatorio
    };

    return Ok(inputDto);
  }

// Método PUT para modificar un input por su ID
[HttpPut("{id:int}")]
public async Task<IActionResult> ActualizarInput(int id, [FromBody] Input inputActualizado)
{
    try
    {
      var input = await _inputRepository.ActualizarInputAsync(id, inputActualizado);
      return Ok(input);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Error interno del servidor: {ex.Message}");
    }
}
}

