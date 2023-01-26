using Academia.Ejemplo.ConfigurationModels;
using Academia.Ejemplo.DTO;
using Academia.Ejemplo.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EdificioController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly AplicacionDbContext context;

    public EdificioController(IConfiguration configuration, AplicacionDbContext context)
    {
        this.configuration = configuration;
        this.context = context;
    }

    [HttpGet]
    public ActionResult GetCostos()
    {
        var costoEdificio = configuration.GetSection("CostoEdificio").Get<List<RecursoEdificio>>();

        return Ok(costoEdificio);
    }

    [HttpPost]
    public ActionResult CrearUnidad(int idJugador, UnidadDto unidadDto)
    {
        var jugador = context.Jugador.First(x => x.IdJugador == idJugador);

        Aldeano aldeano;

        Militar militar;

        switch(unidadDto.Categoria.ToUpper())
        {
            case "CIVIL":
                {
                    aldeano = new Aldeano()
                    {
                        Nombre = unidadDto.Nombre,
                        Categoria = unidadDto.Categoria,
                        PuntosAtaque = unidadDto.PuntosAtaque,
                        PuntosVida = unidadDto.PuntosVida
                    };

                    jugador.IdAldeano.Add(aldeano);

                    break;
                }
            case "MILITAR":
                {
                    militar = new Militar()
                    {
                        Nombre = unidadDto.Nombre,
                        Categoria = unidadDto.Categoria,
                        PuntosAtaque = unidadDto.PuntosAtaque,
                        PuntosVida = unidadDto.PuntosVida
                    };
                    
                    jugador.IdMilitar.Add(militar);
                    
                    break;
                }
        }
        
        context.SaveChanges();

        return Ok();
    }

    [HttpPut("{idEdificio}")]
    public ActionResult Mejorar(int idEdificio)
    {
        var edificio = context.Edificio.First(x => x.IdEdificio == idEdificio);

        edificio.PuntosAtaque = edificio.PuntosAtaque * 3;

        edificio.PuntosVida = edificio.PuntosVida * 2;

        context.Entry(edificio).State = EntityState.Modified;

        context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{idEdificio}")]
    public ActionResult Delete(int idEdificio)
    {
        var edificio = context.Edificio.First(x => x.IdEdificio == idEdificio);

        context.Edificio.Remove(edificio);

        context.SaveChanges();

        return Ok();
    }
}
