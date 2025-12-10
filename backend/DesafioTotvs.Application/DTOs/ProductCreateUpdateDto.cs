namespace DesafioTotvs.Application.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateUpdateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a zero.")]
        public decimal Price { get; set; }
    }

}
