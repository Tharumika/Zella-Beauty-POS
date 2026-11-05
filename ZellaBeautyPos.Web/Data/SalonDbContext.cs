using Microsoft.EntityFrameworkCore;
using ZellaBeautyPos.Web.Models;

namespace ZellaBeautyPos.Web.Data;

public class SalonDbContext(DbContextOptions<SalonDbContext> options) : DbContext(options)
{
    public DbSet<Service> Services => Set<Service>();
    public DbSet<StaffMember> Staff => Set<StaffMember>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Service>().Property(x => x.Price).HasPrecision(12, 2);
        b.Entity<Service>().Property(x => x.Category).HasConversion<string>();
        b.Entity<StaffMember>().Property(x => x.CommissionPercent).HasPrecision(5, 2);

        b.Entity<Sale>(e =>
        {
            e.Property(x => x.Subtotal).HasPrecision(12, 2);
            e.Property(x => x.Discount).HasPrecision(12, 2);
            e.Property(x => x.Total).HasPrecision(12, 2);
            e.Property(x => x.CashReceived).HasPrecision(12, 2);
            e.Property(x => x.ChangeGiven).HasPrecision(12, 2);
            e.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.SetNull);
            e.HasOne(x => x.Staff).WithMany().HasForeignKey(x => x.StaffMemberId).OnDelete(DeleteBehavior.SetNull);
            e.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.SaleId).OnDelete(DeleteBehavior.Cascade);
        });
        b.Entity<SaleItem>(e =>
        {
            e.Property(x => x.UnitPrice).HasPrecision(12, 2);
            e.Ignore(x => x.LineTotal);
        });

        b.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Haircut", Category = ServiceCategory.Hair, Price = 2500, DurationMinutes = 45 },
            new Service { Id = 2, Name = "Classic Manicure", Category = ServiceCategory.Nails, Price = 2000, DurationMinutes = 40 },
            new Service { Id = 3, Name = "Gel Polish", Category = ServiceCategory.Nails, Price = 3500, DurationMinutes = 60 },
            new Service { Id = 4, Name = "Nail Art (per nail)", Category = ServiceCategory.NailArt, Price = 300, DurationMinutes = 10 },
            new Service { Id = 5, Name = "Full Set Nail Art", Category = ServiceCategory.NailArt, Price = 5000, DurationMinutes = 90 });
        b.Entity<StaffMember>().HasData(
            new StaffMember { Id = 1, Name = "Owner", Role = "Owner", CommissionPercent = 0 });
    }
}
