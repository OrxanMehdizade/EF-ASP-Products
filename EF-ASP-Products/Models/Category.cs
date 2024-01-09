﻿namespace EF_ASP_Products.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Product>? Products { get; set;}
    }
}
