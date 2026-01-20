using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public sealed class OrderService
{
    private readonly AppDbContext _db;

    public OrderService()
    {
        // Concrete dependency on AppDbContext: provider + connection string inside the service
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=prod-sql;Database=Orders;Trusted_Connection=True;")
            .Options;

        _db = new AppDbContext(options);
    }

    public Task<bool> CanShipAsync(string orderId, CancellationToken ct = default)
        => _db.Orders.AnyAsync(o => o.Id == orderId, ct);
}
