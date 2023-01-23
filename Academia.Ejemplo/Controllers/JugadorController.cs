using Academia.Ejemplo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JugadorController : ControllerBase
{
    private List<Jugador> jugadores;

    public JugadorController()
    {
        jugadores = new List<Jugador>();

        jugadores.Add(new Jugador() { Nombre = "Jugador1", Civilizacion = "Bizantinos" });
    }

    [HttpGet]
    public ActionResult GetJugadores()
    {
        return Ok(jugadores);
    }

    [HttpPost]
    public ActionResult<List<Jugador>> CrearJugador([FromBody] Jugador jugador)
    {
        jugadores.Add(jugador);

        //return Ok(jugadores);
        return StatusCode(StatusCodes.Status200OK, jugadores);
    }
}
