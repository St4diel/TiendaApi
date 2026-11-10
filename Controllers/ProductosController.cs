using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TiendaApi.Dominio;
using TiendaApi.Dtos;
using TiendaApi.Excepciones;
using TiendaApi.Options;
using TiendaApi.Services;

namespace TiendaApi.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepository _repositorio;
    private readonly TiendaOptions _opciones;

    public ProductosController(IProductoRepository repositorio, IOptions<TiendaOptions> opciones)
    {
        _repositorio = repositorio;
        _opciones = opciones.Value;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductoDto>> Listar() =>
        Ok(_repositorio.ObtenerTodos().Select(ADto));

    [HttpGet("{id:int}")]
    public ActionResult<ProductoDto> Obtener(int id)
    {
        var producto = _repositorio.ObtenerPorId(id);
        return producto is null ? NotFound() : ADto(producto);
    }

    [HttpPost]
    public ActionResult<ProductoDto> Crear(CrearProductoDto dto)
    {
        var producto = new Producto(dto.Nombre, dto.Precio, dto.Stock, dto.Categoria, dto.Descripcion);
        _repositorio.Agregar(producto);
        return CreatedAtAction(nameof(Obtener), new { id = producto.Id }, ADto(producto));
    }

    [HttpPost("{id:int}/retirar-stock")]
    public ActionResult<ProductoDto> RetirarStock(int id, RetirarStockDto dto)
    {
        var producto = _repositorio.ObtenerPorId(id);
        if (producto is null) return NotFound();

        // PROVISIONAL: en el módulo 15 un middleware global hará esto por nosotros.
        try
        {
            producto.RetirarStock(dto.Cantidad);
            return ADto(producto);
        }
        catch (ReglaNegocioException ex)
        {
            return UnprocessableEntity(new { error = ex.Message });   // 422
        }
    }

    // Entidad -> DTO. En el módulo 11 esto se muda a ProductoService.
    private ProductoDto ADto(Producto p)
    {
        var conIva = new Dinero(p.Precio, _opciones.Moneda).ConIva(_opciones.IvaPorcentaje);
        return new ProductoDto(p.Id, p.Nombre, p.Descripcion, p.Precio, conIva.ToString(), p.Stock, p.Categoria);
    }
}
