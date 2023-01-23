using Academia.Ejemplo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Ejemplo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EdificioController : ControllerBase
{
    // GET: api/<EdificioController>
    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }

    // POST api/<EdificioController>
    [HttpPost]
    public ActionResult Post([FromBody] Edificio edificio)
    {
        return Ok();
    }

    // PUT api/<EdificioController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<EdificioController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
