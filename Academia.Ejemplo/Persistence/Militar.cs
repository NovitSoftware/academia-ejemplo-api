using System;
using System.Collections.Generic;

namespace Academia.Ejemplo.Persistence
{
    public partial class Militar
    {
        public Militar()
        {
            IdJugador = new HashSet<Jugador>();
        }

        public int IdMilitar { get; set; }
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public int PuntosVida { get; set; }
        public int PuntosAtaque { get; set; }

        public virtual ICollection<Jugador> IdJugador { get; set; }
    }
}
