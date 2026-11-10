namespace TiendaApi.Services;

// Repaso del módulo 8: un servicio Scoped vive lo que dura UNA petición HTTP.
// El módulo 11 lo usa para mostrar que cada petición recibe un Id distinto.
public interface IContextoSolicitud
{
    Guid IdSolicitud { get; }
}

public class ContextoSolicitud : IContextoSolicitud
{
    public Guid IdSolicitud { get; } = Guid.NewGuid();
}
