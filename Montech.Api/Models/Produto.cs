using System.ComponentModel.DataAnnotations;

namespace Montech.Api.Models;

public class Produto
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [MaxLength(25, ErrorMessage = "O tamanho do campo Nome não pode exceder 25 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Categoria é obrigatório")]
    public int CategoriaId { get; set; } // Chave estrangeira para Categoria
    public Categoria? Categoria { get; set; }

    [MaxLength(350, ErrorMessage = "O tamanho do campo Descricao não pode exceder 350 caracteres")]
    public string Descricao { get; set; }

    public DateTime DataCompra { get; set; }

    [Required(ErrorMessage = "O campo ValorCompra é obrigatório")]
    public decimal ValorCompra { get; set; }

    public decimal ValorMercado { get; set; }

    public bool IsValid { get; set; }

    public Produto()
    {
        Id = Guid.NewGuid();
    }
}
