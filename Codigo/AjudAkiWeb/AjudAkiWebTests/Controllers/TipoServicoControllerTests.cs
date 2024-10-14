using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjudAkiWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service;
using Moq;
using Mappers;
using Core;
using AjudAkiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using AjudAkiWeb.Mappers;

namespace AjudAkiWeb.Controllers.Tests
{
    [TestClass()]
    public class TipoServicoControllerTests
    {
        private static TipoServicoController? controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<ITipoServicoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new TipoServicoProfile())).CreateMapper();
            mockService.Setup(service => service.Get(1))
    .Returns(GetTargetTipoServico());
            mockService.Setup(service => service.GetAll())
                .Returns(GetTestTipoServicos());
            mockService.Setup(service => service.Edit(It.IsAny<Tiposervico>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Tiposervico>()))
                .Verifiable();
            controller = new TipoServicoController(mockService.Object, mapper);
        }
        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<TipoServicoViewModel>));

            List<TipoServicoViewModel>? lista = (List<TipoServicoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoServicoViewModel));
            TipoServicoViewModel tipoServicoModel = (TipoServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Encanador", tipoServicoModel.Nome);
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
            var result = controller.Create(GetNewTipoServico());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void CreateTest_Post_Invalid()
        {
            //arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewTipoServico());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoServicoViewModel));
            TipoServicoViewModel tipoServicoModel = (TipoServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Encanador", tipoServicoModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetTipoServicoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoServicoViewModel));
            TipoServicoViewModel tipoServicoModel = (TipoServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Encanador", tipoServicoModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetTipoServicoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private TipoServicoViewModel GetNewTipoServico()
        {
            return new TipoServicoViewModel
            {
                Id = 4,
                Nome = "Cozinheiro",
            };
        }

        private Tiposervico GetTargetTipoServico()
        {
            return new Tiposervico
            {
                Id = 1,
                Nome = "Encanador",
            };
        }

        private TipoServicoViewModel GetTargetTipoServicoModel()
        {
            return new TipoServicoViewModel
            {
                Id = 2,
                Nome = "Encanador",
            };
        }

        private IEnumerable<Tiposervico> GetTestTipoServicos()
        {
            return new List<Tiposervico>
            {
                new Tiposervico
                {
                    Id = 1,
                    Nome = "Cozinheiro",
                },
                new Tiposervico
                {
                    Id = 2,
                    Nome = "Faxineiro",
                },
                new Tiposervico
                {
                    Id = 3,
                    Nome = "Eletricista",
                },
            };
        }
    }
}