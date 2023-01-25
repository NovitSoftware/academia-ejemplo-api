using Academia.Ejemplo.DTO;
using Academia.Ejemplo.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class JugadorController : ControllerBase
{
    private readonly AplicacionDbContext context;

    public JugadorController(AplicacionDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult GetJugadores()
    {
        var jugadores = context.Jugador.ToList();

        return Ok(jugadores);
    }

    [HttpPost]
    public ActionResult<List<Jugador>> CrearJugador([FromBody] JugadorDto jugadorDto)
    {
        var jugador = new Jugador()
        {
            Nombre = jugadorDto.Nombre,
            Puntaje = jugadorDto.Puntaje,
            Poblacion = jugadorDto.Poblacion,
            Civilizacion = jugadorDto.Civilizacion,
            Madera = jugadorDto.Madera,
            Oro = jugadorDto.Oro,
            Piedra = jugadorDto.Piedra,
            Comida =jugadorDto.Comida
        };

        context.Jugador.Add(jugador);

        context.SaveChanges();

        var jugadores = context.Jugador.ToList();

        //return Ok(jugadores);
        return StatusCode(StatusCodes.Status200OK, jugadores);
    }

    [HttpPost("{idJugador}")]
    public ActionResult CrearEdificio([FromBody] EdificioDto edificioDto, int idJugador)
    {
        var edificio = new Edificio()
        {
            Nombre = edificioDto.Nombre,
            PuntosAtaque = edificioDto.PuntosAtaque,
            PuntosVida = edificioDto.PuntosVida
        };
        
        var jugador = context.Jugador.First(x => x.IdJugador == idJugador);

        jugador.IdEdificio.Add(edificio);

        context.SaveChanges();

        return Ok(jugador.IdJugador);
    }

    [HttpPut]
    public ActionResult PagarTributo(string nombreJugador)//, [FromBody] RecursoDto recursoDto
    {
        return Ok();
    }
}
