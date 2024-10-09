using AjudAkiWeb.Models;
using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AjudAkiWeb.Mappers;

namespace AjudAkiWeb.Controllers.Tests
{
    [TestClass()]
    public class AgendaControllerTests
    {


        private static AgendaController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IAgendaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AgendaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAgendas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAgenda());
            mockService.Setup(service => service.Edit(It.IsAny<Agendum>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Agendum>()))
                .Verifiable();
            controller = new AgendaController(mockService.Object, mapper);
        }


        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AgendaViewModel>));

            List<AgendaViewModel>? lista = (List<AgendaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AgendaViewModel));
            AgendaViewModel agendaModel = (AgendaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(DateTime.Parse("2025-07-24"), agendaModel.Data);
            Assert.AreEqual(Enum.Parse(typeof(TurnoEnum), "MANHÃ"), agendaModel.Turno);

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
            var result = controller.Create(GetNewAgenda());

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
            var result = controller.Create(GetNewAgenda());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AgendaViewModel));
            AgendaViewModel agendaModel = (AgendaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(DateTime.Parse("2025-07-24"), agendaModel.Data);
            Assert.AreEqual(Enum.Parse(typeof(TurnoEnum), "MANHÃ"), agendaModel.Turno);

        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetAgendaModel().Id, GetTargetAgendaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AgendaViewModel));
            AgendaViewModel agendaModel = (AgendaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(DateTime.Parse("2025-07-24"), agendaModel.Data);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetAgendaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        //MÉTODOS PRIVADOS
        private AgendaViewModel GetNewAgenda()
        {
            return new AgendaViewModel
            {
                Id = 4,
                Data = DateTime.Parse("2025-10-27")
            };
        }

        private static Agendum GetTargetAgenda()
        {
            return new Agendum
            {
                Id = 1,
                Data = DateTime.Parse("2025-07-24"),
                Turno = "MANHÃ"

            };
        }
        private AgendaViewModel GetTargetAgendaModel()
        {
            return new AgendaViewModel
            {
                Id = 2,
                Data = DateTime.Parse("2025-02-10"),
            };
        }
        private IEnumerable<Agendum> GetTestAgendas()
        {

            return new List<Agendum>
            {
                new Agendum
                {
                    Id = 1,
                    Data = DateTime.Parse("2025-05-04"),
                    Turno = "NOITE"
                },
                new Agendum
                {
                    Id = 2,
                    Data = DateTime.Parse("2025-08-27"),
                    Turno = "TARDE"
                },
                new Agendum
                {
                    Id = 3,
                    Data = DateTime.Parse("2025-11-10"),
                    Turno = "MANHÃ"
                },
            };
        }
    }
}