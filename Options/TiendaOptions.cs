using System.ComponentModel.DataAnnotations;

namespace TiendaApi.Options;

// Igual que en EjercicioTienda (módulo 9): la configuración tipada de la tienda.
public class TiendaOptions
{
    public const string Seccion = "Tienda";

    [Required] public string NombreTienda { get; set; } = string.Empty;
    [Required] public string Moneda { get; set; } = string.Empty;
    [Range(0, 100)] public decimal IvaPorcentaje { get; set; }
}
