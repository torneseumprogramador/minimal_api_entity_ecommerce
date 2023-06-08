using System.ComponentModel.DataAnnotations;

namespace Entity.Entidades;

public record Fornecedor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Telefone { get; set; } = string.Empty;

    public string? Observacao { get; set; }
}