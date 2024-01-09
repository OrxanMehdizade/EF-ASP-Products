using EF_ASP_Products.Models.ViewModels;

namespace EF_ASP_Products.Models
{
    public class Product:BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public static implicit operator Product(ProductAddViewModel viewModel)
        {
            return new()
            {
                ImageUrl = viewModel.ImageUrl,
                Title = viewModel.Title,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Price = viewModel.Price,
            };
        }
    }
}
