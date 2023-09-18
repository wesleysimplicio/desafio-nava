
using DesafioNava.API.Application.Interfaces;
using DesafioNava.API.Application.Services;
using DesafioNava.API.Controllers;
using DesafioNava.API.Domain;
using DesafioNava.API.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Desafio.API.Tests
{
    public class PessoasControllerTest
    {
        [Fact]
        public void ShoudReturnGet()
        {
            // Arrange
            var pessoa =  new Pessoa[]{
            new Pessoa
            {
                Name = "João",
                LastName = "Silva", 
                DocumentNumber = "123456789",
                Telephone = "987654321",
                DateBirthday = new DateTime(1990, 5, 15),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                Status = 1
            }
        };
            var mockService = new Mock<IPessoaService>();
            mockService
                .Setup(svc => svc.Get())
                .Returns(pessoa);
            var controller = new PessoasController(mockService.Object);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<Pessoa[]>(okResult.Value);
            Assert.NotNull(model);
            Assert.Single(model);
        }

        [Fact]
        public void ShouldReturnBadRequestWhenValueIsInvalid()
        {
            // Arrange
            var mockService = new Mock<IPessoaService>();
            mockService.Setup(svc => svc.Get()).Throws(new DomainException("Mensagem de erro"));

            var controller = new PessoasController(mockService.Object);

            // Act and Assert
            Assert.Throws<DomainException>(() => controller.Get());
        }

    }
}
