namespace TiendaApi.Excepciones;

// Excepciones con nombre de negocio. En el módulo 15 un manejador global
// las traducirá a 404 y 422 automáticamente.
public class NoEncontradoException(string mensaje) : Exception(mensaje);

public class ReglaNegocioException(string mensaje) : Exception(mensaje);
