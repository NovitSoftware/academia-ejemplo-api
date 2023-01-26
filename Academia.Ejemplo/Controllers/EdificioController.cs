using Academia.Ejemplo.ConfigurationModels;
using Academia.Ejemplo.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EdificioController : ControllerBase
{
    private readonly IConfiguration configuration;

    public EdificioController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    [HttpGet]
    public ActionResult GetCostos()
    {
        var costoEdificio = configuration.GetSection("CostoEdificio").Get<List<RecursoEdificio>>();

        return Ok(costoEdificio);
    }

    [HttpPost]
    public ActionResult CrearAldeano(int idJugador, Aldeano aldeano)
    {
        return Ok();
    }

    [HttpPut("{idEdificio}")]
    public ActionResult Mejorar(int idEdificio)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int idEdificio)
    {
        return NoContent();
    }
}
