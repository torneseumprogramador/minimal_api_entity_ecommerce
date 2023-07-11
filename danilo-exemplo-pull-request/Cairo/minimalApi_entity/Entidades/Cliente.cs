using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo.Entidades;

[Table("clientes")]
public record Cliente
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column(name: "nome")]
    public string Nome { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    [Column(name: "email")]
    public string Email { get; set; } = default!;
}
