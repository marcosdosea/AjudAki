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
    public class ServicoControllerTests
    {
        private static ServicoController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IServicoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ServicoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestServicos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetServicos());
            mockService.Setup(service => service.Edit(It.IsAny<Servico>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Servico>()))
                .Verifiable();
            controller = new ServicoController(mockService.Object, mapper);
        }
        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ServicoViewModel>));

            List<ServicoViewModel>? lista = (List<ServicoViewModel>)viewResult.ViewData.Model;
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

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoViewModel));
            ServicoViewModel servicoModel = (ServicoViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("Encanador", servicoModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), servicoModel.DataHoraSolicitacao);
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
            var result = controller.Create(GetNewServico());

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
            var result = controller.Create(GetNewServico());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoViewModel));
            ServicoViewModel servicoModel = (ServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Encanador", servicoModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), servicoModel.DataHoraSolicitacao);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetServicoModel().Id, GetTargetServicoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoViewModel));
            ServicoViewModel servicoModel = (ServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Encanador", servicoModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), servicoModel.DataHoraSolicitacao);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ServicoViewModel));
            ServicoViewModel servicoModel = (ServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Encanador", servicoModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), servicoModel.DataHoraSolicitacao);
        }

        private ServicoViewModel GetNewServico()
        {
            return new ServicoViewModel
            {
                Id = 4,
                Nome = "Cozinheiro",
                DataHoraSolicitacao = DateTime.Parse("1951-02-23")
            };
        }

        private Servico GetTargetServicos()
        {
            return new Servico
            {
                Id = 1,
                Nome = "Encanador",
                Data = DateTime.Parse("2000-02-07")
            };
        }

        private ServicoViewModel GetTargetServicoModel()
        {
            return new ServicoViewModel
            {
                Id = 2,
                Nome = "Encanador",
                DataHoraSolicitacao = DateTime.Parse("2002-09-24")
            };
        }

        private IEnumerable<Servico> GetTestServicos()
        {
            return new List<Servico>
            {
                new Servico
                {
                    Id = 1,
                    Nome = "Cozinheiro",
                    Data = DateTime.Parse("1892-10-27")
                },
                new Servico
                {
                    Id = 2,
                    Nome = "Faxineiro",
                    Data = DateTime.Parse("1839-06-21")
                },
                new Servico
                {
                    Id = 3,
                    Nome = "Eletricista",
                    Data = DateTime.Parse("1982-01-01")
                },
            };
        }
    }
}
