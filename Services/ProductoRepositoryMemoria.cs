using TiendaApi.Dominio;

namespace TiendaApi.Services;

public interface IProductoRepository
{
    IReadOnlyList<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    void Agregar(Producto producto);
}

public class ProductoRepositoryMemoria : IProductoRepository
{
    private readonly List<Producto> _productos = [];
    private int _siguienteId = 1;

    public ProductoRepositoryMemoria()
    {
        // Ahora los datos semilla también pasan por el constructor (y sus reglas).
        Agregar(new Producto("Mouse", 15m, 22, CategoriaProducto.Perifericos));
        Agregar(new Producto("Teclado", 45m, 5, CategoriaProducto.Perifericos));
        Agregar(new Producto("Monitor 24", 200m, 3, CategoriaProducto.Monitores));
        Agregar(new Producto("SSD 1TB", 80m, 8, CategoriaProducto.Almacenamiento));
    }

    public IReadOnlyList<Producto> ObtenerTodos() => _productos;

    public Producto? ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

    public void Agregar(Producto producto)
    {
        producto.AsignarId(_siguienteId++);
        _productos.Add(producto);
    }
}
