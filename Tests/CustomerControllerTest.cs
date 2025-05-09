using Moq;
using TanzEksp.Application.Interfaces;
using TanzEksp.Shared.DTO;
using TanzEksp.Server.Controllers;
using TanzEksp.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Domain.Entities;

namespace Test
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task GetCustomer()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<Customer>
                {
                    new Customer { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" },
                    new Customer { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe" }
                });
            var customerUseCase = new CustomerUseCase(mockCustomerRepository.Object);

            var controller = new CustomerController(customerUseCase);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var customers = Assert.IsAssignableFrom<List<Customer>>(okResult.Value);
            Assert.Equal(2, customers.Count);
        }
    }
}
