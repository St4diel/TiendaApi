using TiendaApi.Excepciones;

namespace TiendaApi.Dominio;

// ENTIDAD: tiene identidad (Id). Dos productos con el mismo nombre siguen siendo distintos.
public class Producto
{
    // private set: desde afuera se LEE, pero solo la propia clase lo cambia.
    public int Id { get; private set; }
    public string Nombre { get; private set; }
    public string? Descripcion { get; private set; }   // "?" = opcional, puede ser null
    public decimal Precio { get; private set; }
    public int Stock { get; private set; }
    public CategoriaProducto Categoria { get; private set; }

    // El constructor es la "aduana": un Producto inválido no puede existir.
    public Producto(string nombre, decimal precio, int stock, CategoriaProducto categoria, string? descripcion = null)
    {
        // ===== HUECO 2 · Reglas del constructor =====
        // Escribe aquí los 3 if (nombre vacío, precio <= 0, stock < 0).

        Nombre = nombre.Trim();
        Precio = precio;
        Stock = stock;
        Categoria = categoria;
        Descripcion = descripcion;
    }

    // Solo para el repositorio en memoria. Desaparece en el módulo 13 con EF Core.
    internal void AsignarId(int id) => Id = id;

    // Método con INTENCIÓN: protege la regla mejor que "Stock -= 5" desde cualquier lado.
    public void RetirarStock(int cantidad)
    {
        // ===== HUECO 4 · Reglas de RetirarStock =====
        // Escribe aquí los 2 if (cantidad <= 0, cantidad > Stock).

        Stock -= cantidad;
    }
}
