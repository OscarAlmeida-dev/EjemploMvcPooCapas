using AccesoDatos;
using Entidades;

namespace Negocio;
public class TareaService
{
    private TareaDao tareaDao;

    public TareaService()
    {
        tareaDao = new TareaDao();
    }

    public List<TareaDto> ObtenerTareasCompletadas()
    {
        List<TareaDto> tareasCompletadas = new List<TareaDto>();
        var tareas = tareaDao.ObtenerTareas();

        foreach (TareaDto tarea in tareas)
        {
            if (tarea.Finalizada == true)
            {
                tareasCompletadas.Add(tarea);
            }
        }

        return tareasCompletadas;
    }

    public List<TareaDto> ObtenerTodasLasTareas()
    {
        return tareaDao.ObtenerTareas();
    }
}
