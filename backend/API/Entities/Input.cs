namespace API.Entities;

public class Input
{
  public int Id {get; set;}
  public int FormularioId {get; set;}
  public required string Nombre {get; set;}
  public required TipoDato TipoDato {get; set;}
  public bool EsObligatorio {get; set;}
  public required Formulario Formulario {get; set;}
}

public enum TipoDato
{
  // String
  STR = 1,

  // Entero
  INT = 2,

  // Fecha
  DTE = 3,

  // Booleano
  BOO = 4,

  // Flotante
  FLO = 5
}