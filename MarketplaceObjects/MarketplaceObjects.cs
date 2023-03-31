using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceObjects
{
    public class Marketplace
    {
        public int MarketplaceId { get; set; }

        [Required]
        public string? Title { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }

    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }

    public class Offer
    {
        public int OfferId { get; set; }

        [Timestamp]
        public byte[]? ChangeCheck { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User? Seller { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? PostalCode { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }

        [Timestamp]
        public byte[]? ChangeCheck { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User? Buyer { get; set; }

        [Required]
        [ForeignKey("OfferId")]
        public Offer? Offer { get; set; }

        public DateTime? TimeSlot { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }

        [Timestamp]
        public byte[]? ChangeCheck { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        /* [MaxLength(10)/*, ErrorMessage="Alias must be 10 characters or less")* /, MinLength(5)] */
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? Alias { get; set; }
        public List<Offer> Offers { get; } = new();
        public List<Order> Orders{ get; } = new();
    }
}
