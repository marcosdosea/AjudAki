using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class AgendaServiceTests
    {

        private AjudakiContext context;
        private IAgendaService agendaService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<AjudakiContext>();
            builder.UseInMemoryDatabase("Ajudaki");
            var options = builder.Options;

            context = new AjudakiContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var agendas = new List<Agendum>
                {
                    new Agendum {
                        Id = 1,
                        Data = DateTime.Parse("2025-07-10"),
                        Turno = "TARDE",
                        TurnoOcupado = 1, 
                        DiaOcupado = 0    
                    },
                    new Agendum {
                        Id = 2,
                        Data = DateTime.Parse("2025-10-12"),
                        Turno = "MANHÃ",
                        TurnoOcupado = 0, 
                        DiaOcupado = 1    
                    },
                    new Agendum {
                        Id = 3,
                        Data = DateTime.Parse("2025-12-31"),
                        Turno = "NOITE",
                        TurnoOcupado = 1,
                        DiaOcupado = 1    
                    }
                };
            context.AddRange(agendas);
            context.SaveChanges();

            agendaService = new AgendaService(context);
        }



        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var novaAgenda = new Agendum()
            {
                Id = 4,
                Data = DateTime.Parse("2025-01-20"),
                Turno = "TARDE",
                TurnoOcupado = 0,
                DiaOcupado = 0
            };

            agendaService.Create(novaAgenda);

            // Assert
            Assert.AreEqual(4, agendaService.GetAll().Count());
            var agenda = agendaService.Get(4);

            Assert.AreEqual(DateTime.Parse("2025-01-20"), agenda.Data);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            agendaService.Delete(2);
            // Assert
            Assert.AreEqual(2, agendaService.GetAll().Count());
            var agenda = agendaService.Get(2);
            Assert.AreEqual(null, agenda);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var agenda = agendaService.Get(3);
            agenda.Turno = "MANHÃ";
            agendaService.Edit(agenda);
            //Assert
            agenda = agendaService.Get(3);
            Assert.IsNotNull(agenda);
            Assert.AreEqual("MANHÃ", agenda.Turno);
        }

        [TestMethod()]
        public void GetTest()
        {
            var agenda = agendaService.Get(1);
            Assert.IsNotNull(agenda);
            Assert.AreEqual(DateTime.Parse("2025-07-10"), agenda.Data);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAgenda = agendaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAgenda, typeof(IEnumerable<Agendum>));
            Assert.IsNotNull(listaAgenda);
            Assert.AreEqual(3, listaAgenda.Count());
            Assert.AreEqual((uint)1, listaAgenda.First().Id);
            Assert.AreEqual("TARDE", listaAgenda.First().Turno);
        }

    }
}