using TareasPWA.Models;

namespace TareasPWA.Services;

public class TareaService
{
    private readonly List<Tarea> _tareas = new();
    private int _siguienteId = 1;

    public IReadOnlyList<Tarea> ObtenerTodas() => _tareas;

    public void Agregar(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            return;

        _tareas.Add(new Tarea
        {
            Id = _siguienteId++,
            Titulo = titulo.Trim(),
            Completada = false
        });
    }

    public void CambiarEstado(int id)
    {
        var tarea = _tareas.FirstOrDefault(x => x.Id == id);
        if (tarea is not null)
            tarea.Completada = !tarea.Completada;
    }

    public void Eliminar(int id)
    {
        var tarea = _tareas.FirstOrDefault(x => x.Id == id);
        if (tarea is not null)
            _tareas.Remove(tarea);
    }
}
