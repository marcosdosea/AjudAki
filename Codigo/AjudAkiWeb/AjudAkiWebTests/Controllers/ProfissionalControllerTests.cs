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
    public class ProfissionalControllerTests
    {
        private static ProfissionalController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IProfissionalService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ProfissionalProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestProfissionais());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetProfissionais());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pessoa>()))
                .Verifiable();
            controller = new ProfissionalController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ProfissionalViewModel>));

            List<ProfissionalViewModel>? lista = (List<ProfissionalViewModel>)viewResult.ViewData.Model;
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

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ProfissionalViewModel));
            ProfissionalViewModel profissionalModel = (ProfissionalViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("Miguel dos Santos", profissionalModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), profissionalModel.DataNascimento);
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
            var result = controller.Create(GetNewProfissional());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void CreateTest_Post_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewProfissional());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ProfissionalViewModel));
            ProfissionalViewModel profissionalModel = (ProfissionalViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Miguel dos Santos", profissionalModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), profissionalModel.DataNascimento);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetProfissionalModel().Id, GetTargetProfissionalModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Arrange
            var profissional = GetTargetProfissionalModel();

            // Act
            var result = controller.Delete(profissional);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetProfissionalModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ProfissionalViewModel GetNewProfissional()
        {
            return new ProfissionalViewModel
            {
                Id = 4,
                Nome = "Marlysson Dantas",
                DataNascimento = DateTime.Parse("1951-02-23")
            };
        }

        private Pessoa GetTargetProfissionais()
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Miguel dos Santos",
                DataNascimento = DateTime.Parse("2000-02-07")
            };
        }

        private ProfissionalViewModel GetTargetProfissionalModel()
        {
            return new ProfissionalViewModel
            {
                Id = 2,
                Nome = "Paulo Borbas",
                DataNascimento = DateTime.Parse("2002-09-24")
            };
        }

        private IEnumerable<Pessoa> GetTestProfissionais()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Pedro Ramos",
                    DataNascimento = DateTime.Parse("1892-10-27")
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Lula da Silva",
                    DataNascimento = DateTime.Parse("1839-06-21")
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Marcos Dósea",
                    DataNascimento = DateTime.Parse("1982-01-01")
                },
            };
        }

    }
}