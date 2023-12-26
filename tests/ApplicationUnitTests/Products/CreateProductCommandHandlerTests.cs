using Infrastructure.DataAccess;
using Moq;
using NUnit.Framework;

namespace ApplicationUnitTests.Products
{
    [TestFixture]
    public class CreateProductCommandHandlerTests
    {
        [Test]
        public async Task Handle_ProductIsAdded_UnitOfWorkIsSaved()
        {
            // Arrange
            //var mockProductRepository = new Mock<IProductRepository>();
            //var mockUnitOfWork = new Mock<IUnitOfWork>();

            //var handler = new CreateProductCommandHandler(mockProductRepository.Object, mockUnitOfWork.Object);

            //var command = new CreateProductCommand("Sample Product", 10.99m, 100);

            // Act
            //await handler.Handle(command, CancellationToken.None);

            // Assert
            //mockProductRepository.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Once);
            //mockUnitOfWork.Verify(unitOfWork => unitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
