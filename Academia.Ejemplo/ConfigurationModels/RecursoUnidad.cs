﻿namespace Academia.Ejemplo.ConfigurationModels;

public class RecursoUnidad
{
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public int Madera { get; set; }
    public int Piedra { get; set; }
    public int Oro { get; set; }
    public int Comida { get; set; }
}