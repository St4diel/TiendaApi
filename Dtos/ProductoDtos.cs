using System.ComponentModel.DataAnnotations;
using TiendaApi.Dominio;

namespace TiendaApi.Dtos;

// Lo que ENTRA. Con [ApiController], si un atributo falla la API responde 400 sola.
// ===== HUECO 3 · Atributos de validación =====
// Agrega un atributo delante de Nombre, Precio, Stock, Categoria y Descripcion.
public record CrearProductoDto(
    string Nombre,
    decimal Precio,
    int Stock,
    CategoriaProducto Categoria,
    string? Descripcion);

// Lo que SALE. El cliente no ve ni depende de la entidad interna.
public record ProductoDto(
    int Id, string Nombre, string? Descripcion, decimal Precio, string PrecioConIva, int Stock, CategoriaProducto Categoria);

public record RetirarStockDto([Range(1, 1000)] int Cantidad);

// Lo usa el módulo 11 (reporte agrupado por categoría con LINQ).
public record ResumenCategoriaDto(CategoriaProducto Categoria, int Productos, int Unidades, decimal ValorInventario);
