namespace Academia.Ejemplo.DTO;

public class JugadorDto
{
    public int IdJugador { get; set; }
    public string Nombre { get; set; } = null!;
    public int Puntaje { get; set; }
    public int Poblacion { get; set; }
    public string Civilizacion { get; set; } = null!;
    public int Madera { get; set; }
    public int Piedra { get; set; }
    public int Oro { get; set; }
    public int Comida { get; set; }
    public int SumaRecursos { get; set; }
    public List<UnidadDto> Aldeanos{get; set;}
    public List<UnidadDto> Militares{get; set;}
    public List<EdificioDto> Edificios{get; set;}
}

public class JugadorDtoRequest
{
    public string Nombre { get; set; } = null!;
    public int Puntaje { get; set; }
    public int Poblacion { get; set; }
    public string Civilizacion { get; set; } = null!;
    public int Madera { get; set; }
    public int Piedra { get; set; }
    public int Oro { get; set; }
    public int Comida { get; set; }
}
