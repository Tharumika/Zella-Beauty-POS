using System.ComponentModel.DataAnnotations;

namespace ZellaBeautyPos.Web.Models;

public enum ServiceCategory { Hair, Nails, NailArt, Skin, Other }

public class Service
{
    public int Id { get; set; }
    [Required, StringLength(100)] public string Name { get; set; } = "";
    public ServiceCategory Category { get; set; } = ServiceCategory.Nails;
    [Range(0, 1_000_000)] public decimal Price { get; set; }
    [Range(5, 600)] public int DurationMinutes { get; set; } = 30;
    public bool IsActive { get; set; } = true;
}

public class StaffMember
{
    public int Id { get; set; }
    [Required, StringLength(100)] public string Name { get; set; } = "";
    [StringLength(50)] public string Role { get; set; } = "Stylist";
    [Range(0, 100)] public decimal CommissionPercent { get; set; } = 30;
    public bool IsActive { get; set; } = true;
}

public class Customer
{
    public int Id { get; set; }
    [Required, StringLength(100)] public string Name { get; set; } = "";
    [Phone, StringLength(30)] public string? Phone { get; set; }
    [StringLength(500)] public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class Sale
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int? StaffMemberId { get; set; }
    public StaffMember? Staff { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public decimal CashReceived { get; set; }
    public decimal ChangeGiven { get; set; }
    public List<SaleItem> Items { get; set; } = [];
}

public class SaleItem
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    /// <summary>Name and price are copied at sale time so old sales never change when prices are edited.</summary>
    [Required, StringLength(100)] public string Name { get; set; } = "";
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal LineTotal => UnitPrice * Quantity;
}
