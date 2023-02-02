namespace Academia.Ejemplo.Persistence.Repositories
{
    public class EdificioRepository
    {
        private readonly AplicacionDbContext aplicacionDbContext;

        public EdificioRepository(AplicacionDbContext aplicacionDbContext)
        {
            this.aplicacionDbContext = aplicacionDbContext;
        }

        public IEnumerable<Edificio> FindAll()
        {
            return this.aplicacionDbContext.Edificio.ToList();
        }

        public void AddEdificioToJugador(Edificio edificio, Jugador jugador)
        {
            edificio.IdJugador.Add(jugador);
            this.aplicacionDbContext.Edificio.Add(edificio);
            this.aplicacionDbContext.SaveChanges();
        }
    }
}
