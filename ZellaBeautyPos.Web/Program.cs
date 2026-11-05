using Microsoft.EntityFrameworkCore;
using ZellaBeautyPos.Web.Components;
using ZellaBeautyPos.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ZellaBeautyPos.Web.Services.ToastService>();
builder.Services.AddDbContextFactory<SalonDbContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("Default") ?? "Data Source=salon.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<SalonDbContext>>();
    using var db = factory.CreateDbContext();
    db.Database.EnsureCreated();

    // EnsureCreated skips databases that already have tables, so add the sales tables
    // to an existing salon.db without touching its data. (Switch to EF migrations later.)
    db.Database.ExecuteSqlRaw(@"
        CREATE TABLE IF NOT EXISTS ""Sales"" (
            ""Id"" INTEGER NOT NULL CONSTRAINT ""PK_Sales"" PRIMARY KEY AUTOINCREMENT,
            ""CreatedAt"" TEXT NOT NULL,
            ""CustomerId"" INTEGER NULL,
            ""StaffMemberId"" INTEGER NULL,
            ""Subtotal"" TEXT NOT NULL,
            ""Discount"" TEXT NOT NULL,
            ""Total"" TEXT NOT NULL,
            ""CashReceived"" TEXT NOT NULL,
            ""ChangeGiven"" TEXT NOT NULL,
            CONSTRAINT ""FK_Sales_Customers_CustomerId"" FOREIGN KEY (""CustomerId"") REFERENCES ""Customers"" (""Id"") ON DELETE SET NULL,
            CONSTRAINT ""FK_Sales_Staff_StaffMemberId"" FOREIGN KEY (""StaffMemberId"") REFERENCES ""Staff"" (""Id"") ON DELETE SET NULL
        );
        CREATE TABLE IF NOT EXISTS ""SaleItems"" (
            ""Id"" INTEGER NOT NULL CONSTRAINT ""PK_SaleItems"" PRIMARY KEY AUTOINCREMENT,
            ""SaleId"" INTEGER NOT NULL,
            ""Name"" TEXT NOT NULL,
            ""UnitPrice"" TEXT NOT NULL,
            ""Quantity"" INTEGER NOT NULL,
            CONSTRAINT ""FK_SaleItems_Sales_SaleId"" FOREIGN KEY (""SaleId"") REFERENCES ""Sales"" (""Id"") ON DELETE CASCADE
        );
        CREATE INDEX IF NOT EXISTS ""IX_Sales_CustomerId"" ON ""Sales"" (""CustomerId"");
        CREATE INDEX IF NOT EXISTS ""IX_Sales_StaffMemberId"" ON ""Sales"" (""StaffMemberId"");
        CREATE INDEX IF NOT EXISTS ""IX_SaleItems_SaleId"" ON ""SaleItems"" (""SaleId"");");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
