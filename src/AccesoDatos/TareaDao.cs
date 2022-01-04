using System.Data;
using System.Data.SQLite;
using Entidades;

namespace AccesoDatos;
public class TareaDao
{
    private SQLiteConnection conexion;

    public TareaDao()
    {
        conexion = new SQLiteConnection();
        conexion.ConnectionString = @"Data Source=..\..\.\db\AppTareas.db;Version=3;";
    }

    public int CrearTarea(TareaDto tarea)
    {
        conexion.Open();

        SQLiteCommand comando = new SQLiteCommand();
        comando.Connection = conexion;
        comando.CommandText = "insert into Tareas values(@Titulo, @Descripcion, @Finalizada, @FechaCreacion, @FechaFinalizada)";
        comando.CommandType = CommandType.Text;
        comando.Parameters.AddWithValue("@Titulo", tarea.Titulo);
        comando.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
        comando.Parameters.AddWithValue("@Finalizada", tarea.Finalizada);
        comando.Parameters.AddWithValue("@FechaCreacion", DateTime.UtcNow);
        comando.Parameters.AddWithValue("@FechaFinalizada", null);

        int filasAgregadas = comando.ExecuteNonQuery();

        conexion.Close();

        return filasAgregadas;
    }

    public List<TareaDto> ObtenerTareas()
    {
        List<TareaDto> tareas = new List<TareaDto>();

        conexion.Open();

        SQLiteCommand comando = new SQLiteCommand();
        comando.Connection = conexion;
        comando.CommandText = "Select * from Tareas;";
        comando.CommandType = CommandType.Text;

        SQLiteDataReader datos = comando.ExecuteReader();

        while (datos.Read()) // true false
        {
            TareaDto tarea = new TareaDto();
            tarea.Id = Convert.ToInt32(datos["Id"]);
            tarea.Titulo = Convert.ToString(datos["Titulo"]);
            tarea.Descripcion = datos["Descripcion"].ToString();
            tarea.Finalizada = Convert.ToBoolean(datos["Finalizada"]);
            tarea.FechaCreacion = Convert.ToDateTime(datos["FechaCreacion"]);

            if (datos["FechaFinalizada"] != DBNull.Value)
            {
                tarea.FechaFinalizada = Convert.ToDateTime(datos["FechaFinalizada"]);
            }
            
            tareas.Add(tarea);
        }

        datos.Close();
        conexion.Close();

        return tareas;
    }

    public int EditarTarea(TareaDto tarea)
    {
        conexion.Open();

        SQLiteCommand comando = new SQLiteCommand();
        comando.Connection = conexion;
        comando.CommandText = "update Tareas set Titulo = @Titulo, Descripcion = @Descripcion, Finalizada = @Finalizada, FechaFinalizada = @FechaFinalizada where Id = @Id;";
        comando.CommandType = CommandType.Text;
        comando.Parameters.AddWithValue("@Id", tarea.Id);
        comando.Parameters.AddWithValue("@Titulo", tarea.Titulo);
        comando.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
        comando.Parameters.AddWithValue("@Finalizada", tarea.Finalizada);
        comando.Parameters.AddWithValue("@FechaFinalizada", tarea.FechaFinalizada);

        int filasModificadas = comando.ExecuteNonQuery();

        conexion.Close();

        return filasModificadas;
    }

    public int ElimnarTareaPorId(int id)
    {
        conexion.Open();

        SQLiteCommand comando = new SQLiteCommand();
        comando.Connection = conexion;
        comando.CommandText = "delete from Tareas where Id = @Id;";
        comando.CommandType = CommandType.Text;
        comando.Parameters.AddWithValue("@Id", id);

        int filasEliminadas = comando.ExecuteNonQuery();

        conexion.Close();

        return filasEliminadas;
    }

    public TareaDto ObtenerTarePorId(int id)
    {
        TareaDto tarea = new TareaDto();

        conexion.Open();

        SQLiteCommand comando = new SQLiteCommand();
        comando.Connection = conexion;
        comando.CommandText = "Select * from Tareas where Id = @Id;";
        comando.CommandType = CommandType.Text;
        comando.Parameters.AddWithValue("@Id", id);

        SQLiteDataReader datos = comando.ExecuteReader();

        while (datos.Read())
        {
            tarea.Id = Convert.ToInt32(datos["Id"]);
            tarea.Titulo = Convert.ToString(datos["Titulo"]);
            tarea.Descripcion = datos["Descripcion"].ToString();
            tarea.Finalizada = Convert.ToBoolean(datos["Finalizada"]);
            tarea.FechaCreacion = Convert.ToDateTime(datos["FechaCreacion"]);
            tarea.FechaFinalizada = Convert.ToDateTime(datos["FechaFinalizada"]);
        }

        datos.Close();
        conexion.Close();

        return tarea;
    }
}
