using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo.Entidades;

[Table("produtos")]
public record Produto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Column(name: "nome")]
    public string Nome { get; set; } = default!;

    [Column(name: "valor")]
    public double Valor { get; set; }
}
