﻿using System.ComponentModel.DataAnnotations;

namespace MarketplaceObjects
{
    public class Marketplace
    {
        public int MarketplaceId { get; set; }

        public string? Title { get; set; }

        [Required]
        public CategoriesList? CategoriesList;
    }

    public class CategoriesList
    {
        public int CategoriesListId { get; set; }

        public List<Category> Categories { get; } = new();
    }

    public class Category
    {
        public int CategoryId { get; set; }

        // [Required]
        public string? Title { get; set; }
        // [Required]
        public string? Content { get; set; }
    }    
        
    public class Offer
    {
        public int OfferId { get; set; }

        [Required]
        public User? User { get; set; }
        [Required]
        public Category? Category { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public User? User { get; set; }
        [Required]
        public Offer? Offer { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
    }
        
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Alias { get; set; }
        public List<Offer> Offers { get; } = new();
        public List<Order> Orders{ get; } = new();
    }
}
