using API.Entities;

namespace API.DTOs;

public class FormularioViewDTO
{
  public int Id {get; set;}
  public required string Nombre {get; set;}
  public required List<InputViewDTO> Inputs {get; set;}
}

public class RespFormularioViewDTO
{
  public int FormularioId {get; set;}
  public required List<RespInputViewDTO> RespuestasInputs {get; set;}
}

public class InputViewDTO
{
  public int Id { get; set; }
  public required string Nombre {get; set;}
  public required TipoDato TipoDato {get; set;}
  public bool EsObligatorio {get; set;}
}

public class RespInputViewDTO
{
  public int InputId { get; set; }
  public required string Valor { get; set; }
}
