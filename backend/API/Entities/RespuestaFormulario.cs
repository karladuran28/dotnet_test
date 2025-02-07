namespace API.Entities;

public class RespuestaFormulario 
{
  public int Id {get; set;}
  public int FormularioId {get; set;}
  public required Formulario Formulario {get; set;}
  public List<RespuestaInput> RespuestasInputs {get; set;} = new List<RespuestaInput>();
}