using Microsoft.EntityFrameworkCore;

namespace Academia.Ejemplo.Persistence.Repositories
{
    public class AldeanoRepository
    {
        private readonly AplicacionDbContext aplicacionDbContext;

        public AldeanoRepository(AplicacionDbContext aplicacionDbContext)
        {
            this.aplicacionDbContext = aplicacionDbContext;
        }

        public IEnumerable<Aldeano> FindAll()
        {
            return this.aplicacionDbContext.Aldeano.ToList();
        }

        public Aldeano? FindOne(int id)
        {
            return this.aplicacionDbContext.Aldeano.FirstOrDefault(x => x.IdAldeano == id);
        }

        public IEnumerable<Aldeano> FindByIdJugador(int IdJugador)
        {
            var jugador = this.aplicacionDbContext.Jugador.Include(x => x.IdAldeano).FirstOrDefault(x => x.IdJugador == IdJugador);

            if (jugador == null)
                return new List<Aldeano>();

            return jugador.IdAldeano.ToList();
        }
    }
}
