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
    public class ClienteControllerTests
    {
        private static ClienteController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IClienteService>();
            var mockService2 = new Mock<IAssinaturaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ClienteProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestClientes());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetCliente());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pessoa>()))
                .Verifiable();
            controller = new ClienteController(mockService.Object, mockService2.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ClienteViewModel>));

            List<ClienteViewModel>? lista = (List<ClienteViewModel>)viewResult.ViewData.Model;
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

            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ClienteViewModel));
            ClienteViewModel clienteModel = (ClienteViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("Miguel dos Santos", clienteModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), clienteModel.DataNascimento);
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
            var result = controller.Create(GetNewCliente());

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
            var result = controller.Create(GetNewCliente());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ClienteViewModel));
            ClienteViewModel clienteModel = (ClienteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Miguel dos Santos", clienteModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), clienteModel.DataNascimento);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetClienteModel().Id, GetTargetClienteModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ClienteViewModel));
            ClienteViewModel clienteModel = (ClienteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Miguel dos Santos", clienteModel.Nome);
            Assert.AreEqual(DateTime.Parse("2000-02-07"), clienteModel.DataNascimento);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetClienteModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ClienteViewModel GetNewCliente()
        {
            return new ClienteViewModel
            {
                Id = 4,
                Nome = "Marlysson Dantas",
                DataNascimento = DateTime.Parse("1951-02-23")
            };
        }

        private Pessoa GetTargetCliente()
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Miguel dos Santos",
                DataNascimento = DateTime.Parse("2000-02-07")
            };
        }

        private ClienteViewModel GetTargetClienteModel()
        {
            return new ClienteViewModel
            {
                Id = 2,
                Nome = "Paulo Borbas",
                DataNascimento = DateTime.Parse("2002-09-24")
            };
        }

        private IEnumerable<Pessoa> GetTestClientes()
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