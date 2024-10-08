using AutoMapper;
using Moq;
using Core.Service;
using AjudAkiWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using AjudAkiWeb.Models;

namespace AjudAkiWeb.Controllers.Tests
{
    [TestClass()]
    public class ContratacaoControllerTests
    {
        private static ContratacaoController controller;
        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IContratacaoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ContratacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestContratacoes());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetContratacao());
            mockService.Setup(service => service.Edit(It.IsAny<Contratacao>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Contratacao>()))
                .Verifiable();
            controller = new ContratacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ContratacaoViewModel>));

            List<ContratacaoViewModel>? lista = (List<ContratacaoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest_Valido()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ContratacaoViewModel));
            ContratacaoViewModel contratacaoModel = (ContratacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pintor José Ramos", contratacaoModel.Nome);
            Assert.AreEqual(DateTime.Parse("2024-02-23"), contratacaoModel.Data);
        }

        [TestMethod()]
        public void CreateTest_Get_Valido()
        {
            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valido()
        {
            // Act
            var result = controller.Create(GetNewContratacao());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Post_Invalido()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewContratacao());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get_Valid()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ContratacaoViewModel));
            ContratacaoViewModel contratacaoModel = (ContratacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pintor José Ramos", contratacaoModel.Nome);
            Assert.AreEqual(DateTime.Parse("2024-02-23"), contratacaoModel.Data);
        }

        [TestMethod()]
        public void EditTest_Post_Valido()
        {
            // Act
            var result = controller.Edit(GetTargetContratacaoModel().Id, GetTargetContratacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valido()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ContratacaoViewModel));
            ContratacaoViewModel contratacaoModel = (ContratacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Pintor José Ramos", contratacaoModel.Nome);
            Assert.AreEqual(DateTime.Parse("2024-02-23"), contratacaoModel.Data);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetContratacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ContratacaoViewModel GetNewContratacao()
        {
            return new ContratacaoViewModel
            {
                Id = 4,
                Nome = "Ian Pintor",
                Data = DateTime.Parse("2024-02-23")
            };
        }

        private static Contratacao GetTargetContratacao()
        {
            return new Contratacao
            {
                Id = 1,
                Nome = "Pintor José Ramos",
                Data = DateTime.Parse("2024-02-23")
            };
        }

        private ContratacaoViewModel GetTargetContratacaoModel()
        {
            return new ContratacaoViewModel
            {
                Id = 2,
                Nome = "Pintor José Ramos",
                Data = DateTime.Parse("2024-02-23")
            };
        }

        private IEnumerable<Contratacao> GetTestContratacoes()
        {
            return new List<Contratacao>
            {
                new Contratacao
                {
                    Id = 1,
                    Nome = "Pedro do lava-jato",
                    Data = DateTime.Parse("2024-02-23")
                },
                new Contratacao
                {
                    Id = 2,
                    Nome = "Eletricista de filho de Totonho",
                    Data = DateTime.Parse("2024-02-23")
                },
                new Contratacao
                {
                    Id = 3,
                    Nome = "Dósea do fogão",
                    Data = DateTime.Parse("2024-02-23")
                },
            };
        }
    }
}