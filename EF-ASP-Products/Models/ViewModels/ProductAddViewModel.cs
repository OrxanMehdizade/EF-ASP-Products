namespace EF_ASP_Products.Models.ViewModels
{
    public class ProductAddViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

    }
}
