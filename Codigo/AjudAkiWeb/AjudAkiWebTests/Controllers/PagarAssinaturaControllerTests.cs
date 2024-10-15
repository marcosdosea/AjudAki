using AutoMapper;
using Core.Service;
using Moq;
using AjudAkiWeb.Mappers;
using Core;
using AjudAkiWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjudAkiWeb.Controllers.Tests
{
    [TestClass()]
    public class PagarAssinaturaControllerTests
    {
        private static PagarAssinaturaController? controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IPagarAssinaturaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PagarAssinaturaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPagarAssinaturas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPagarAssinatura());
            mockService.Setup(service => service.Edit(It.IsAny<Pagamentoassinatura>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pagamentoassinatura>()))
                .Verifiable();
            controller = new PagarAssinaturaController(mockService.Object, mapper);
        }

        private Pagamentoassinatura GetTargetPagarAssinatura()
        {
            return new Pagamentoassinatura
            {
                Id = 1,
                DataPagamento = DateTime.Parse("2024-02-23 14:30"),
                Status = "CANCELADO"
            };
        }

        private IEnumerable<Pagamentoassinatura> GetTestPagarAssinaturas()
        {
            return new List<Pagamentoassinatura>
            {
                new Pagamentoassinatura
                {
                    Id = 1,
                    DataPagamento = DateTime.Parse("2024-02-23 14:30"),
                    Status = "CANCELADO"
                },
                new Pagamentoassinatura
                {
                    Id = 2,
                    DataPagamento = DateTime.Parse("2024-02-24 14:30"),
                    Status = "ATRASADO"
                }
            };
        }


        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PagarAssinaturaViewModel>));

            List<PagarAssinaturaViewModel>? lista = (List<PagarAssinaturaViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(2, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest_Valido()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PagarAssinaturaViewModel));
            PagarAssinaturaViewModel pagarAssinaturaModel = (PagarAssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("CANCELADO", pagarAssinaturaModel.Status.ToString());
            Assert.AreEqual(PagamentoStatusEnum.CANCELADO, pagarAssinaturaModel.Status);
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
            var result = controller.Create(GetNewPagamentoassinatura());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PagarAssinaturaViewModel GetNewPagamentoassinatura()
        {
            return new PagarAssinaturaViewModel
            {
                Id = 3,
                DataPagamento = DateTime.Parse("2024-02-23 15:30"),
                Status = PagamentoStatusEnum.PAGO,
            };
        }

        [TestMethod()]
        public void EditTest_Get_Valid()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PagarAssinaturaViewModel));
            PagarAssinaturaViewModel pagarAssinaturaModel = (PagarAssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("CANCELADO", pagarAssinaturaModel.Status.ToString());
            Assert.AreEqual(PagamentoStatusEnum.CANCELADO, pagarAssinaturaModel.Status);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetPagarAssinaturaViewModel().Id, GetTargetPagarAssinaturaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PagarAssinaturaViewModel GetTargetPagarAssinaturaViewModel()
        {
            return new PagarAssinaturaViewModel
            {
                Id = 1,
                DataPagamento = DateTime.Parse("2024-02-23 14:30"),
                Status = PagamentoStatusEnum.PAGO
            };
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PagarAssinaturaViewModel));
            PagarAssinaturaViewModel pagarAssinaturaModel = (PagarAssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("CANCELADO", pagarAssinaturaModel.Status.ToString());
            Assert.AreEqual(PagamentoStatusEnum.CANCELADO, pagarAssinaturaModel.Status);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PagarAssinaturaViewModel));
            PagarAssinaturaViewModel pagarAssinaturaModel = (PagarAssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("CANCELADO", pagarAssinaturaModel.Status.ToString());
            Assert.AreEqual(PagamentoStatusEnum.CANCELADO, pagarAssinaturaModel.Status);

        }
    }
}