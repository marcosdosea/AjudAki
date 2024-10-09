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
    public class AreaAtuacaoControllerTests
    {

        private static AreaAtuacaoController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IAreaAtuacaoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AreaAtuacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAreasAtuacao());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAreaAtuacao());
            mockService.Setup(service => service.Edit(It.IsAny<Areaatuacao>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Areaatuacao>()))
                .Verifiable();
            controller = new AreaAtuacaoController(mockService.Object, mapper);
        }


        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AreaAtuacaoViewModel>));

            List<AreaAtuacaoViewModel>? lista = (List<AreaAtuacaoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreaAtuacaoViewModel));
            AreaAtuacaoViewModel areaAtuacaoModel = (AreaAtuacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Eletricista", areaAtuacaoModel.Nome);
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
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewAreaAtuacao());

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
            var result = controller.Create(GetNewAreaAtuacao());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreaAtuacaoViewModel));
            AreaAtuacaoViewModel areaAtuacaoModel = (AreaAtuacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Eletricista", areaAtuacaoModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetAreaAtuacaoModel().Id, GetTargetAreaAtuacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }



        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AreaAtuacaoViewModel));
            AreaAtuacaoViewModel areaAtuacaoModel = (AreaAtuacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Eletricista", areaAtuacaoModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetAreaAtuacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private AreaAtuacaoViewModel GetNewAreaAtuacao()
        {
            return new AreaAtuacaoViewModel
            {
                Id = 4,
                Nome = "Saúde",
            };
        }

        private static Areaatuacao GetTargetAreaAtuacao()
        {
            return new Areaatuacao
            {
                Id = 1,
                Nome = "Eletricista",
            };
        }
        private AreaAtuacaoViewModel GetTargetAreaAtuacaoModel()
        {
            return new AreaAtuacaoViewModel
            {
                Id = 2,
                Nome = "Eletricista",
            };
        }
        private IEnumerable<Areaatuacao> GetTestAreasAtuacao()
        {

            return new List<Areaatuacao>
            {
                new Areaatuacao
                {
                    Id = 1,
                    Nome = "Educação",
                },
                new Areaatuacao
                {
                    Id = 2,
                    Nome = "Eletricista",
                },
                new Areaatuacao
                {
                    Id = 3,
                    Nome = "Construção",
                },
            };
        }
    }
}