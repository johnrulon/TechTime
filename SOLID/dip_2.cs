using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// Repository interface abstracting data access
public interface IOrderRepository
{
    Task<bool> ExistsAsync(string orderId, CancellationToken ct = default);
}

// EF Core implementation of the repository
public sealed class EfOrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public EfOrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public Task<bool> ExistsAsync(string orderId, CancellationToken ct = default)
        => _db.Orders.AnyAsync(o => o.Id == orderId, ct);
}

// Service depending on the repository abstraction
public sealed class OrderService
{
    private readonly IOrderRepository _repo;

    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }

    public Task<bool> CanShipAsync(string orderId, CancellationToken ct = default)
        => _repo.ExistsAsync(orderId, ct);
}

// Order entity
public sealed class Order
{
    public string Id { get; set; } = default!;
    public string Status { get; set; } = "Ready";
}

// DbContext
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
}

