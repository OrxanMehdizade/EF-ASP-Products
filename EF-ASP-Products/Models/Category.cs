using EF_ASP_Products.Models.ViewModels;

namespace EF_ASP_Products.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public ICollection<Product>? Products { get; set;}
        public static implicit operator Category(AddCategoryViewModel viewModel)
        {
            return new()
            {
                Name = viewModel.Name,
                ImageUrl = viewModel.ImageUrl,
            };
        }
    }
}
