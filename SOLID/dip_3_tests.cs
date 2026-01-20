using Moq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

public class OrderServiceTests
{
    [Fact]
    public async Task CanShip_WhenOrderExists_ReturnsTrue()
    {
        // Arrange: set up mock repository
        var mockedRepo = new Mock<IOrderRepository>();

        mockedRepo.Setup(r => r.ExistsAsync("A123", It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var service = new OrderService(mockedRepo.Object);

        // Act
        var result = await service.CanShipAsync("A123");

        // Assert
        Assert.True(result);

        // Verify actions
        mockedRepo.Verify(r => r.ExistsAsync("A123", It.IsAny<CancellationToken>()), Times.Once);
        mockedRepo.VerifyNoOtherCalls();
    }
}