using Academia.Ejemplo.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AldeanoController : ControllerBase
{
    private readonly AplicacionDbContext context;

    public AldeanoController(AplicacionDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult GetCostos()
    {
        var aldeanos = context.Aldeano.ToList();

        return Ok(aldeanos);
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
    public ActionResult Construir() 
    {
        return Ok();
    }

    [HttpDelete]
    public ActionResult Morir(int idAldeano)
    {
        return NoContent();
    }
}
