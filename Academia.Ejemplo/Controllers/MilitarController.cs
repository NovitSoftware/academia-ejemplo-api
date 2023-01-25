using Microsoft.AspNetCore.Mvc;

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MilitarController : ControllerBase
{
    [HttpGet]
    public ActionResult GetCostos()
    {
        return Ok();
    }


    [HttpPost]
    public ActionResult Atacar()
    {
        return Ok();
    }

    [HttpDelete]
    public ActionResult Morir(string idMilitar)
    {
        return NoContent();
    }
}
