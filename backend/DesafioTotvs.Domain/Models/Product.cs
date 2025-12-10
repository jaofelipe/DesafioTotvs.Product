using System.ComponentModel.DataAnnotations;

namespace DesafioTotvs.Domain.Models
{
    public class Product
    {
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; private set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; private set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; private set; }

        private Product() { } // EF

        public Product(string name, string? description, decimal price)
        {
            Id = Guid.NewGuid();
            Update(name, description, price);
        }

        public void Update(string name, string? description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            if (price < 0)
                throw new ArgumentException("Price must be greater or equal to zero.", nameof(price));

            Name = name.Trim();
            Description = description?.Trim();
            Price = price;
        }
    }
}
