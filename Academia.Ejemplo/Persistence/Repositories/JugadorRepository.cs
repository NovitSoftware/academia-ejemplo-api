using Microsoft.EntityFrameworkCore;

namespace Academia.Ejemplo.Persistence.Repositories
{
    public class JugadorRepository
    {
        private readonly AplicacionDbContext aplicacionDbContext;

        public JugadorRepository(AplicacionDbContext aplicacionDbContext)
        {
            this.aplicacionDbContext = aplicacionDbContext;
        }

        public IEnumerable<Jugador> FindAll()
        {
            return this.aplicacionDbContext.Jugador.Include(x => x.IdAldeano).Include(x => x.IdMilitar).Include(x => x.IdEdificio).ToList();
        }

        public Jugador? Find(int id)
        {
            return this.aplicacionDbContext.Jugador.FirstOrDefault(x => x.IdJugador == id);
        }
    }
}
