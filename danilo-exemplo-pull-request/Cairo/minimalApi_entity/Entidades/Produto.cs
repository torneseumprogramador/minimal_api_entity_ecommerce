namespace Cairo.Entidades;

public record Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public double Valor { get; set; }
}
