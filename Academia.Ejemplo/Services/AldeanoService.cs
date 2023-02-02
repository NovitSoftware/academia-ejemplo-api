using Academia.Ejemplo.DTO;
using Academia.Ejemplo.Persistence.Repositories;

namespace Academia.Ejemplo.Services
{
    public class AldeanoService
    {
        private readonly AldeanoRepository aldeanoRepository;

        public AldeanoService(AldeanoRepository aldeanoRepository)
        {
            this.aldeanoRepository = aldeanoRepository;
        }

        //public IEnumerable<UnidadDto> GetAldeanos()
        //{
        //    return this.aldeanoRepository.FindAll();
        //}

        public UnidadDto GetAldeano(int id)
        {
            var aldeano = this.aldeanoRepository.FindOne(id);
            return new UnidadDto() { Nombre = aldeano.Nombre, PuntosAtaque = aldeano.PuntosAtaque, PuntosVida = aldeano.PuntosVida, Categoria = aldeano.Categoria };
        }

        public IEnumerable<UnidadDto> GetAldeanosJugador(int idJugador)
        {
            var aldeanos = this.aldeanoRepository.FindByIdJugador(idJugador);
            return aldeanos.Select(x=> new UnidadDto() { Nombre = x.Nombre, PuntosAtaque = x.PuntosAtaque, PuntosVida = x.PuntosVida, Categoria = x.Categoria });
        }
    }
}
