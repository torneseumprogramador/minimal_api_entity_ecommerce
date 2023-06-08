using System.ComponentModel.DataAnnotations;

namespace Entity.Entidades;

public record Produto
{
    [Key]
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public double Valor { get; set; }
}