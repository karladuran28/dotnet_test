namespace API.Entities;

public class Formulario
{
  public int Id {get; set;}
  public required string Nombre {get; set;}
  public List<Input> Inputs {get; set;} = new List<Input>();
}