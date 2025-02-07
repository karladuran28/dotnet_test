namespace API.Entities;

public class RespuestaInput 
{
  public int Id {get; set;}
  public int InputId {get; set;}
  public required Input Input {get; set;}
  public required string Valor {get; set;} 
}