using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Threading.Tasks;

public class OrderServiceTests
{
    [Fact]
    public async Task CanShip_WhenOrderExists_ReturnsTrue()
    {
        // In-memory EF Core database for a true unit-ish test
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var db = new AppDbContext(options);
        db.Orders.Add(new Order { Id = "A123", Status = "Ready" });
        await db.SaveChangesAsync();

        IOrderRepository repo = new EfOrderRepository(db);
        var service = new OrderService(repo);

        Assert.True(await service.CanShipAsync("A123"));
    }
}
