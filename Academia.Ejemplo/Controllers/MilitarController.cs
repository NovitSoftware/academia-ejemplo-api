using Academia.Ejemplo.ConfigurationModels;
using Academia.Ejemplo.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MilitarController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly AplicacionDbContext context;

    public MilitarController(IConfiguration configuration, AplicacionDbContext context)
    {
        this.configuration = configuration;
        this.context = context;
    }

    [HttpGet]
    public ActionResult GetCostos()
    {
        var costosMilitar = configuration.GetSection("CostoUnidades").Get <List<RecursoUnidad>>().Where(x => x.Tipo.ToUpper() == "MILITAR");

        return Ok(costosMilitar);
    }

    /// <summary>
    /// Solo pueden atacar los militares entre si
    /// </summary>
    /// <param name="idMilitarAtacante"></param>
    /// <param name="idMilitarObjetivo"></param>
    /// <returns></returns>
    [HttpPost("{idMilitar}")]
    public ActionResult Atacar(int idMilitarAtacante, int idMilitarObjetivo)
    {
        var atacante = context.Militar.First(x => x.IdMilitar == idMilitarAtacante);
        
        var objetivo = context.Militar.First(x => x.IdMilitar == idMilitarObjetivo);

        objetivo.PuntosVida = objetivo.PuntosVida - atacante.PuntosAtaque;

        return Ok();
    }

    [HttpDelete("{idMilitar}")]
    public ActionResult Morir(int idMilitar)
    {
        var militar = context.Militar.First(x => x.IdMilitar == idMilitar);

        context.Militar.Remove(militar);

        context.SaveChanges();

        return Ok();
    }
}
