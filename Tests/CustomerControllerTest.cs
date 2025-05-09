using Moq;
using TanzEksp.Application.Interfaces;
using TanzEksp.Shared.DTO;
using TanzEksp.Server.Controllers;
using TanzEksp.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using TanzEksp.Domain.Entities;
using TanzEksp.Client.Services;
using System.Net.Http.Json;
using System.Net;

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

        [Fact]
        public async Task AddCustomer()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var customerUseCase = new CustomerUseCase(mockCustomerRepository.Object);
            var controller = new CustomerController(customerUseCase);

            var newCustomer = new Customer { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" };

            // Act
            var result = await controller.Add(newCustomer);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", createdResult.ActionName);
            Assert.Equal(newCustomer.Id, ((Customer)createdResult.Value).Id);
        }
    }
}
