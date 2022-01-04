using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using Negocio;
using Entidades;

namespace Frontend.Controllers;

public class TareaController : Controller
{
    private TareaService tareaService;
    public TareaController()
    {
        tareaService = new TareaService();
    }

    public ActionResult<List<TareaDto>> Index()
    {
        var tareas = tareaService.ObtenerTodasLasTareas();
        return View(tareas);
    }

    public IActionResult Editar(int id)
    {
        return View();
    }
}
