using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entidades;

[Table("fornecedores")]
public record Fornecedor
{
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column(name: "nome")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [Column(name: "telefone")]
    public string Telefone { get; set; } = string.Empty;

    [Column(name: "observacao")]
    public string? Observacao { get; set; }
}