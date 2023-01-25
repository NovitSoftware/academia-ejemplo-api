namespace Academia.Ejemplo.DTO;

public class JugadorDto
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
