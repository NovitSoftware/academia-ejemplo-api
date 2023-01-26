using Academia.Ejemplo.DTO;
using Academia.Ejemplo.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        var jugadores = context.Jugador.Include(x => x.IdAldeano).Include(x => x.IdMilitar).Include(x => x.IdEdificio);

        return Ok(jugadores.Select(j =>
            new {
                j.IdJugador,
                j.Nombre, 
                j.Civilizacion, 
                j.Puntaje, 
                j.Poblacion, 
                j.Oro, 
                j.Piedra, 
                j.Madera, 
                j.Comida, 
                aldeanos = j.IdAldeano.Select(a => 
                    new {
                        a.IdAldeano,
                        a.Nombre,
                        a.Categoria,
                        a.PuntosAtaque,
                        a.PuntosVida
                    }),
                militares = j.IdMilitar.Select(m =>
                    new {
                        m.IdMilitar,
                        m.Nombre,
                        m.Categoria,
                        m.PuntosAtaque,
                        m.PuntosVida
                    }),
                edificios = j.IdEdificio.Select(e =>
                new {
                    e.IdEdificio,
                    e.Nombre,
                    e.PuntosAtaque,
                    e.PuntosVida
                }),
            }));
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

    /// <summary>
    /// Representa a los edificios que puede construir el jugador (al momento de crearse no se encuentran construidos)
    /// </summary>
    /// <param name="edificioDto"></param>
    /// <param name="idJugador"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Permite pasar un recuso determinado de un jugador a otro jugador
    /// eg. Jugador 1 (envia 50 madera) a jugador 2
    /// </summary>
    /// <param name="recursoDto"></param>
    /// <param name="idJugador"></param>
    /// <returns></returns>
    [HttpPut("{idJugadorEnvia}")]
    public ActionResult PagarTributo([FromBody] RecursoDto tributoDto, int idJugadorEnvia)
    {
        var jugadorEnvia = context.Jugador.First(x => x.IdJugador == idJugadorEnvia);

        var jugadorRecibe = context.Jugador.First(x => x.IdJugador == tributoDto.IdJugador);

        switch(tributoDto.Recurso)
        {
            case "Oro":
                {
                    jugadorEnvia.Oro = jugadorEnvia.Oro - tributoDto.Cantidad;
                    jugadorRecibe.Oro = jugadorRecibe.Oro + tributoDto.Cantidad;
                    break;
                }
            case "Piedra":
                {
                    jugadorEnvia.Piedra = jugadorEnvia.Piedra - tributoDto.Cantidad;
                    jugadorRecibe.Piedra = jugadorRecibe.Piedra + tributoDto.Cantidad;
                    break;
                }
            case "Madera":
                {
                    jugadorEnvia.Madera = jugadorEnvia.Madera - tributoDto.Cantidad;
                    jugadorRecibe.Madera = jugadorRecibe.Madera + tributoDto.Cantidad;
                    break;
                }
            case "Comida":
                {
                    jugadorEnvia.Comida = jugadorEnvia.Comida - tributoDto.Cantidad;
                    jugadorRecibe.Comida = jugadorRecibe.Comida + tributoDto.Cantidad;
                    break;
                }
        }

        context.Entry(jugadorEnvia).State = EntityState.Modified;

        context.Entry(jugadorRecibe).State = EntityState.Modified;

        context.SaveChanges();

        return Ok();
    }
}
