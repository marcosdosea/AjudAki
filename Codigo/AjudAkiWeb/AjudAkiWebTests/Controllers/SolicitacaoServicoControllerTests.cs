using AjudAkiWeb.Mappers;
using AjudAkiWeb.Models;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AjudAkiWeb.Controllers.Tests
{
    [TestClass()]
    public class SolicitacaoServicoControllerTests
    {
        private static SolicitacaoServicoController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<ISolicitacaoServicoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new SolicitacaoServicoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestSolicitacoesServicos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetSolicitacaoServico());
            mockService.Setup(service => service.Edit(It.IsAny<Solicitacaoservico>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Solicitacaoservico>()))
                .Verifiable();
            controller = new SolicitacaoServicoController(mockService.Object, mapper);
        }
        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<SolicitacaoServicoViewModel>));

            List<SolicitacaoServicoViewModel>? lista = (List<SolicitacaoServicoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(SolicitacaoServicoViewModel));
            SolicitacaoServicoViewModel solicitacaoServicoModel = (SolicitacaoServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Supervisionar e Alimentar animais", solicitacaoServicoModel.Nome);
            Assert.AreEqual(80m, solicitacaoServicoModel.Valor);

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
            var result = controller.Create(GetNewSolicitacaoServico());

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
            var result = controller.Create(GetNewSolicitacaoServico());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(SolicitacaoServicoViewModel));
            SolicitacaoServicoViewModel solicitacaoServicoModel = (SolicitacaoServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Banho nos cachorros", solicitacaoServicoModel.Nome);
            Assert.AreEqual(530m, solicitacaoServicoModel.Valor);

        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetSolicitacaoServicoModel().Id, GetTargetSolicitacaoServicoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(SolicitacaoServicoViewModel));
            SolicitacaoServicoViewModel solicitacaoServicoModel = (SolicitacaoServicoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(530m, solicitacaoServicoModel.Valor);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetSolicitacaoServicoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private SolicitacaoServicoViewModel GetNewSolicitacaoServico()
        {
            return new SolicitacaoServicoViewModel
            {
                Id = 4,
                Nome = "Limpeza de banheiros",
                Valor = 230
            };
        }

        private static Solicitacaoservico GetTargetSolicitacaoServico()
        {
            return new Solicitacaoservico
            {
                Id = 1,
                Nome = "Banho nos cachorros",
                Valor = 530
            };
        }

        private SolicitacaoServicoViewModel GetTargetSolicitacaoServicoModel()
        {
            return new SolicitacaoServicoViewModel
            {
                Id = 2,
                Nome = "Cuidar de criança de 10 anos",
                Valor = 130
            };
        }

        private IEnumerable<Solicitacaoservico> GetTestSolicitacoesServicos()
        {

            return new List<Solicitacaoservico>
            {
                new Solicitacaoservico
                {
                    Id = 1,
                    Nome = "Supervisionar e Alimentar animais",
                    Valor = 80
                },
                new Solicitacaoservico
                {
                    Id = 2,
                    Nome = "Conserto de notebook",
                    Valor = 200

                },
                new Solicitacaoservico
                {
                    Id = 3,     
                    Nome = "Fazer atividade da faculdade de Sistemas de informação",
                    Valor = 100

                },
            };
        }
    }
}