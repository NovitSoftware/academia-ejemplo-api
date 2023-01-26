using Academia.Ejemplo.ConfigurationModels;
using Academia.Ejemplo.DTO;
using Academia.Ejemplo.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AldeanoController : ControllerBase
{
    private readonly AplicacionDbContext context;
    private readonly IConfiguration configuration;

    public AldeanoController(AplicacionDbContext context, IConfiguration configuration)
    {
        this.context = context;
        this.configuration = configuration;
    }

    [HttpGet]
    public ActionResult GetCostos()
    {
        var costoAldeanos = configuration.GetSection("CostoUnidades").Get<List<RecursoUnidad>>().Where(x => x.Tipo.ToUpper() == "CIVIL");

        return Ok(costoAldeanos);
    }

    [HttpGet]
    public ActionResult GetValoresProductor()
    {
        var aldeanoProductor = configuration.GetSection("AldeanoProductor").Get<List<AldeanoProductor>>();

        return Ok(aldeanoProductor);
    }

    [HttpPost("{idJugador}")]
    public ActionResult Recolectar(int idJugador, [FromBody] RecursoDto recursoDto)
    {
        return Ok();
    }

    [HttpPost("{idJugador}")]
    public ActionResult Construir(int idJugador, int idEdificio) 
    {
        //en base al edificio se le debe descontar los recursos al jugador

        return Ok();
    }

    [HttpDelete]
    public ActionResult Morir(int idAldeano)
    {
        return Ok();
    }
}
