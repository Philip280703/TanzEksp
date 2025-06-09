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
using System.Runtime.InteropServices;

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
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);        // Sikrer at resultated er af typen CreatedAtActionResult, som bruges til at returnere 201 statuskald
            Assert.Equal("GetById", createdResult.ActionName);                      // Sikrer at actionname er "GetById" så klienten kan bruge dette navn til at hente kunden
            Assert.Equal(newCustomer.Id, ((Customer)createdResult.Value).Id);      // Sikrer at den id der returneres er den samme som den id der blev sendt til controlleren
        }

        [Fact]
        public async Task UpdateCustomerTest()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();

            Guid id = Guid.Parse("33442A82-D297-433F-92AB-08DD88E57474");
            var customerToUpdate = new Customer
            {
                Id = id,
                FirstName = "John"
            };

            mockRepository.Setup(repo => repo.Update(It.IsAny<Customer>()))
                          .Returns(Task.CompletedTask); // Optional, if method is async void

            var customerUseCase = new CustomerUseCase(mockRepository.Object);
            var controller = new CustomerController(customerUseCase);

            // Act
            var result = await controller.Update(id, customerToUpdate);

            // Assert
            mockRepository.Verify(repo => repo.Update(It.Is<Customer>(c =>
                c.Id == customerToUpdate.Id && c.FirstName == customerToUpdate.FirstName)), Times.Once);

            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public async Task DeleteCustomer_ControllerTest()
        {
            //arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var id = Guid.Parse("33442A82-D297-433F-92AB-08DD88E57475");

            // Først henter vi kunden med metoden GetById og tjekker om kunden eksistere

            mockRepository.Setup(r => r.GetById(id)).ReturnsAsync(new Customer { Id = id, FirstName = "Andreas" });

            // Hvis kunden eksistere, så kalder vi delete metoden (id)
        
            mockRepository.Setup(r => r.Delete(id)).Returns(Task.CompletedTask);
            // Delete metoden retunere en completed task 

            var usecase = new CustomerUseCase(mockRepository.Object);
            var controller = new CustomerController(usecase);

            // Tjekker resultatet: 
            //act 
            var result = await controller.Delete(id);

            //assert
            mockRepository.Verify(r => r.Delete(id), Times.Once);
            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public async Task DeleteCusotmer_UseCaseTest()
        {
            //arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var id = Guid.Parse("33442A82-D297-433F-92AB-08DD88E57475");

            mockRepository.Setup(r => r.Delete(It.IsAny<Guid>())).Returns(Task.CompletedTask);
            var useCase = new CustomerUseCase(mockRepository.Object);

            //act
            await useCase.Delete(id);

            //assert

            mockRepository.Verify(r => r.Delete(id), Times.Once);
        }

    }
}
