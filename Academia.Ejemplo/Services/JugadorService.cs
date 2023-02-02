using Academia.Ejemplo.DTO;
using Academia.Ejemplo.Persistence.Repositories;

namespace Academia.Ejemplo.Services
{
    public class JugadorService
    {
        private readonly JugadorRepository jugadorRepository;
        private readonly AldeanoService aldeanoService;

        public JugadorService(JugadorRepository jugadorRepository,
            AldeanoService aldeanoService)
        {
            this.jugadorRepository = jugadorRepository;
            this.aldeanoService = aldeanoService;
        }

        public IEnumerable<JugadorDto> GetJugadores()
        {
            return this.jugadorRepository.FindAll().Select(x => new JugadorDto {
                IdJugador = x.IdJugador,
                Nombre = x.Nombre,
                Civilizacion = x.Civilizacion,
                Puntaje = x.Comida + x.Piedra + x.Oro*2 + x.Madera + x.Poblacion + aldeanoService.GetAldeanosJugador(x.IdJugador).Count()*3,
                Madera = x.Madera,
                Oro = x.Oro,
                Piedra = x.Piedra,
                Comida = x.Comida,
                Poblacion = x.Poblacion,
                SumaRecursos = x.Comida + x.Piedra + x.Oro + x.Madera,
                Aldeanos = aldeanoService.GetAldeanosJugador(x.IdJugador).ToList()
            }); ;
        }
    }
}
