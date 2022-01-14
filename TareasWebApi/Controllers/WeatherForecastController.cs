using Microsoft.AspNetCore.Mvc;
using TareasWebApi.Models;

namespace TareasWebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")] // Modelo como debe ser las rutas
public class WeatherForecastController : ControllerBase
{

    [HttpGet("{id}")]
    public ActionResult ObtenerDatos(int id, string? nombre = "", string? apellido = "")
    {
        Console.WriteLine($"Este es el id , el nombre es {nombre} y el apellido es {apellido}");
        return Ok("Tome sus datos");
    }

    [HttpPost]
    public ActionResult GuardarDatos([FromBody] TareaViewModel tarea)
    {
        return Ok(new { mensaje = $"Se creo la tare con el id {tarea.Id}" });
    }

    [HttpPut]
    public ActionResult ActualizarDatos([FromBody] TareaViewModel tarea)
    {
        return NotFound($"No existe la tarea con el id {tarea.Id}"); return Ok($"Se actulizo la tarea con el id {tarea.Id}");
    }

    [HttpPut("{id}")]
    public ActionResult EliminarDatos(int id)
    {
        return Ok($"Se elimino la tarea con el id {id}");
    }
}