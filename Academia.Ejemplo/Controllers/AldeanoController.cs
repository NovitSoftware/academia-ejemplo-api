using Academia.Ejemplo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AldeanoController : ControllerBase
{
    [HttpGet]
    public ActionResult GetCostos()
    {
        return Ok();
    }

    [HttpGet]
    public ActionResult GetValoresProductor()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult Recolectar(string recurso)
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult Construir(Edificio edificio)
    {
        return Ok();
    }

    [HttpDelete]
    public ActionResult Morir(int idAldeano)
    {
        return NoContent();
    }
}
