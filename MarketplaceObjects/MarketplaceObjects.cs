using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceObjects
{
    [Keyless]
    public class AllObjectsCount
    {
        public int MarketplacesCount { get; set; }
        public int CategoriesCount { get; set; }
        public int OffersCount { get; set; }
        public int OrdersCount { get; set; }
        public int UsersCount { get; set; }
    }

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

        public int MarketplaceId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }

    [Owned]
    public class PostalAddress
    {
        public string? PostalCode { get; set; }
    }

    public class Offer
    {
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        [Timestamp]
        public byte[]? LastChangeTimestamp { get; set; }

        [Required]
        [ForeignKey("User")]
        public int SellerId { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }

        [Required]
        public PostalAddress? Address { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }

        [Required]
        public OrderDetails? OrderDetails { get; set; }
        public OrderStatus Status { get; set; }

        [Timestamp]
        public byte[]? LastChangeTimestamp { get; set; }
    }

    [Owned]
    public class OrderDetails
    {
        public ReservationProposal? ReservationProposal { get; set; }
    }

    [Owned]
    public class ReservationProposal
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public enum OrderStatus
    {
        Created, // PendingApproval
        Locked, // Approved
        Shipped, // Delivered
    }

    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [Timestamp]
        public byte[]? LastChangeTimestamp { get; set; }

        public List<Offer> Offers { get; } = new();
        public List<Order> Orders{ get; } = new();

        /* [MaxLength(10)/*, ErrorMessage="Alias must be 10 characters or less")* /, MinLength(5)] */
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [NotMapped]
        public string? UserAlias { get; set; } // GetUserAlias / InspectedUserAlias

        [NotMapped]
        public DateTime LoadedFromDatabase { get; set; }
    }
}
