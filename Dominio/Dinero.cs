namespace TiendaApi.Dominio;

// VALUE OBJECT: no tiene Id. Dos Dinero(10, "USD") son iguales (record compara por valor).
// sealed = nadie hereda de él. Sin "init" en las propiedades = inmutable,
// y además "with" NO puede saltarse la validación del constructor.
public sealed record Dinero
{
    public decimal Monto { get; }
    public string Moneda { get; }

    public Dinero(decimal monto, string moneda)
    {
        if (monto < 0)
            throw new ArgumentOutOfRangeException(nameof(monto), "El monto no puede ser negativo.");
        if (string.IsNullOrWhiteSpace(moneda) || moneda.Length != 3)
            throw new ArgumentException("La moneda debe tener 3 letras.", nameof(moneda));

        Monto = decimal.Round(monto, 2);       // 22.9885 -> 22.99 (¿recuerdan la tarea?)
        Moneda = moneda.ToUpperInvariant();    // "usd" -> "USD"
    }

    // No modifica este objeto: devuelve uno NUEVO.
    public Dinero ConIva(decimal porcentaje) => new(Monto * (1 + porcentaje / 100m), Moneda);

    // Invariant: siempre "17.25 USD", sin importar si el servidor está en español ("17,25").
    public override string ToString() => FormattableString.Invariant($"{Monto:0.00} {Moneda}");
}
