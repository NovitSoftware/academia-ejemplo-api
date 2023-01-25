using System;
using System.Collections.Generic;

namespace Academia.Ejemplo.Persistence
{
    public partial class Jugador
    {
        public Jugador()
        {
            IdAldeano = new HashSet<Aldeano>();
            IdEdificio = new HashSet<Edificio>();
            IdMilitar = new HashSet<Militar>();
        }

        public int IdJugador { get; set; }
        public string Nombre { get; set; } = null!;
        public int Puntaje { get; set; }
        public int Poblacion { get; set; }
        public string Civilizacion { get; set; } = null!;
        public int Madera { get; set; }
        public int Piedra { get; set; }
        public int Oro { get; set; }
        public int Comida { get; set; }

        public virtual ICollection<Aldeano> IdAldeano { get; set; }
        public virtual ICollection<Edificio> IdEdificio { get; set; }
        public virtual ICollection<Militar> IdMilitar { get; set; }
    }
}
