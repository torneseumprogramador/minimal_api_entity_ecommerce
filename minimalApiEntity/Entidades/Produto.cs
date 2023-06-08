using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entidades;

[Table("produtos")]
public record Produto
{
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Column(name: "nome")]
    public string Nome { get; set; } = string.Empty;

    [Column(name: "descricao")]
    public string? Descricao { get; set; }

    [Column(name: "valor")]
    public double Valor { get; set; }
}