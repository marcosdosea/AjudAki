using Core.Service;
using Core;
using AutoMapper;
using Moq;
using AjudAkiWeb.Mappers;
using Microsoft.AspNetCore.Mvc;
using AjudAkiWeb.Models;

namespace AjudAkiWeb.Controllers.Tests
{
    [TestClass()]
    public class AvaliarControllerTests
    {
        private static AvaliarController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IAvaliarService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AvaliarProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAvaliar());
            mockService.Setup(service => service.Create(It.IsAny<Avaliacao>()))
                .Verifiable();
            controller = new AvaliarController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AvaliarViewModel>));

            List<AvaliarViewModel>? lista = (List<AvaliarViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest1()
        {
            // Act
            var result = controller.Create(GetNewAvaliar());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private AvaliarViewModel GetNewAvaliar()
        {
            return new AvaliarViewModel
            {
                Id = 10,
                NotaServico = true,
                NotaProfissional = false,
                Status = 1,
                Comentario = "O serviço foi bom, mas o profissional poderia melhorar.",
                IdContratacao = 20,
                IdContratacaoNavigation = new Contratacao { Id = 20, Nome = "Contratação Exemplo" }
            };
        }
        private IEnumerable<Avaliacao> GetTestAvaliar()
        {
            return new List<Avaliacao>
    {
        new Avaliacao
        {
            Id = 1,
            NotaServico = true,
            NotaProfissional = true,
            Status = 1,
            Comentario = "Serviço excelente",
            IdContratacao = 101
        },
        new Avaliacao
        {
            Id = 2,
            NotaServico = false,
            NotaProfissional = true,
            Status = 2,
            Comentario = "Serviço mediano",
            IdContratacao = 102
        },
        new Avaliacao
        {
            Id = 3,
            NotaServico = true,
            NotaProfissional = false,
            Status = 1,
            Comentario = "Profissional abaixo do esperado",
            IdContratacao = 103
        }
        };
        }
    }
}