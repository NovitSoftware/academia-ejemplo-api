using System;
using System.Collections.Generic;

namespace Academia.Ejemplo.Persistence
{
    public partial class Edificio
    {
        public Edificio()
        {
            IdJugador = new HashSet<Jugador>();
        }

        public int IdEdificio { get; set; }
        public string Nombre { get; set; } = null!;
        public int PuntosVida { get; set; }
        public int PuntosAtaque { get; set; }

        public virtual ICollection<Jugador> IdJugador { get; set; }
    }
}
