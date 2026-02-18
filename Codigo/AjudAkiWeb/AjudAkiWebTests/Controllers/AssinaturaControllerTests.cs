using AutoMapper;
using Core.Service;
using Moq;
using AjudAkiWeb.Mappers;
using Core;
using AjudAkiWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AjudAkiWeb.Controllers.Tests
{
    [TestClass()]
    public class AssinaturaControllerTests
    {
        private static AssinaturaController? controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IAssinaturaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AssinaturaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAssinaturas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAssinatura());
            mockService.Setup(service => service.Get(999))
                .Returns((Assinatura?)null);
            mockService.Setup(service => service.Edit(It.IsAny<Assinatura>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Assinatura>()))
                .Verifiable();
            mockService.Setup(service => service.Delete(It.IsAny<uint>()))
                .Verifiable();
            controller = new AssinaturaController(mockService.Object, mapper);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            controller.TempData = new TempDataDictionary(controller.HttpContext, Mock.Of<ITempDataProvider>());
        }

        private Assinatura GetTargetAssinatura()
        {
            return new Assinatura
            {
                Id = 1,
                Nome = AssinaturaNomeEnum.BÁSICO.ToString(),
                Status = AssinaturaStatusEnum.ATIVA.ToString(),
                Descricao = "Plano básico com beneficios limitados"
            };
        }

        private IEnumerable<Assinatura> GetTestAssinaturas()
        {
            return new List<Assinatura>
            {
                new Assinatura
                {
                    Id = 1,
                    Nome = AssinaturaNomeEnum.BÁSICO.ToString(),
                    Status = AssinaturaStatusEnum.ATIVA.ToString(),
                    Descricao = "Plano básico com beneficios limitados"
                },
                new Assinatura
                {
                    Id = 2,
                    Nome = AssinaturaNomeEnum.AVANÇADO.ToString(),
                    Status = AssinaturaStatusEnum.ATIVA.ToString(),
                    Descricao = "Plano com beneficios avançados"
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AssinaturaViewModel>));

            List<AssinaturaViewModel>? lista = (List<AssinaturaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssinaturaViewModel));
            AssinaturaViewModel assinaturaModel = (AssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(AssinaturaNomeEnum.BÁSICO, assinaturaModel.Nome);
            Assert.AreEqual("Plano básico com beneficios limitados", assinaturaModel.Descricao);
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
            var result = controller.Create(GetNewAssinatura());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Post_Invalid()
        {
            // Arrange - simula erro de validação no modelo
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewAssinatura());

            // Assert - quando inválido, deve retornar View para o usuário corrigir
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssinaturaViewModel));
        }

        private AssinaturaViewModel GetNewAssinatura()
        {
            return new AssinaturaViewModel
            {
                Id = 4,
                Nome = AssinaturaNomeEnum.AVANÇADO,
                Status = AssinaturaStatusEnum.ATIVA,
                Valor = 99.90f,
                Descricao = "Plano com beneficios brilhantes"
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssinaturaViewModel));
            AssinaturaViewModel assinaturaModel = (AssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(AssinaturaNomeEnum.BÁSICO, assinaturaModel.Nome);
            Assert.AreEqual("Plano básico com beneficios limitados", assinaturaModel.Descricao);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetAssinaturaViewModel().Id, GetTargetAssinaturaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private AssinaturaViewModel GetTargetAssinaturaViewModel()
        {
            return new AssinaturaViewModel
            {
                Id = 2,
                Nome = AssinaturaNomeEnum.AVANÇADO,
                Status = AssinaturaStatusEnum.ATIVA,
                Valor = 149.90f,
                Descricao = "Plano com beneficios avançados"
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssinaturaViewModel));
            AssinaturaViewModel assinaturaModel = (AssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(AssinaturaNomeEnum.BÁSICO, assinaturaModel.Nome);
            Assert.AreEqual("Plano básico com beneficios limitados", assinaturaModel.Descricao);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssinaturaViewModel));
            AssinaturaViewModel assinaturaModel = (AssinaturaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(AssinaturaNomeEnum.BÁSICO, assinaturaModel.Nome);
            Assert.AreEqual("Plano básico com beneficios limitados", assinaturaModel.Descricao);
        }

        [TestMethod()]
        public void DeleteTest_Post_Confirmado()
        {
            // Act - simula confirmação de exclusão via POST
            var viewModel = GetTargetAssinaturaViewModel();
            viewModel.Id = 1;
            var result = controller.Delete(1, viewModel);

            // Assert - deve redirecionar para Index após excluir
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod()]
        public void Details_IdInexistente_DeveRedirecionarParaIndex()
        {
            // Act
            var result = controller.Details(999);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod()]
        public void Edit_IdInexistente_DeveRedirecionarParaIndex()
        {
            // Act
            var result = controller.Edit(999);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod()]
        public void Delete_IdInexistente_DeveRedirecionarParaIndex()
        {
            // Act
            var result = controller.Delete(999);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Post_IdsNaoCorrespondem_DeveRedirecionarParaIndex()
        {
            // Arrange - ID na rota diferente do ID no modelo
            var viewModel = GetTargetAssinaturaViewModel();
            viewModel.Id = 2;

            // Act
            var result = controller.Edit(99, viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }
    }
}