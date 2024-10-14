using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class ServicoServiceTests
    {
        private AjudakiContext context;
        private IServicoService ServicoService;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<AjudakiContext>();
            builder.UseInMemoryDatabase("Ajudaki");
            var options = builder.Options;

            context = new AjudakiContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Criação da lista de Servicos com todas as propriedades obrigatórias
            var servicos = new List<Servico>
            {
                new()
                {
                    Id = 1,
                    Nome = "Encanador",
                    Data = DateTime.Parse("2000-12-31"),
                },
                new()
                {
                    Id = 2,
                    Nome = "Mecânico",
                    Data = DateTime.Parse("1935-12-31"),
                },
                new Servico
                {
                    Id = 3,
                    Nome = "Eletricista",
                    Data = DateTime.Parse("1998-11-20"),
                },
            };

            context.AddRange(servicos);
            context.SaveChanges();

            ServicoService = new ServicoService(context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var novoServico = new Servico()
            {
                Id = 4,
                Nome = "Cozinheiro",
                Data = DateTime.Parse("2003-12-25"),
            };

            ServicoService.Create(novoServico);

            // Assert
            Assert.AreEqual(4, ServicoService.GetAll().Count());
            var Servico = ServicoService.Get(4);

            Assert.AreEqual("Cozinheiro", Servico.Nome);
            Assert.AreEqual(DateTime.Parse("2003-12-25"), Servico.Data);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            ServicoService.Delete(2);

            // Assert
            Assert.AreEqual(2, ServicoService.GetAll().Count());

            var Servico = ServicoService.Get(2);
            Assert.IsNull(Servico);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act 
            var Servico = ServicoService.Get(3);

            Servico.Nome = "Faxineiro";
            Servico.Data = DateTime.Parse("1993-11-21");
            ServicoService.Edit(Servico);

            // Assert
            Servico = ServicoService.Get(3);

            Assert.IsNotNull(Servico);
            Assert.AreEqual("Faxineiro", Servico.Nome);
            Assert.AreEqual(DateTime.Parse("1993-11-21"), Servico.Data);
        }

        [TestMethod()]
        public void GetTest()
        {
            var Servico = ServicoService.Get(1);

            Assert.IsNotNull(Servico);
            Assert.AreEqual("Encanador", Servico.Nome); // Corrigido o nome para coincidir com a inicialização
            Assert.AreEqual(DateTime.Parse("2000-12-31"), Servico.Data);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaServico = ServicoService.GetAll();

            // Assert
            Assert.IsInstanceOfType(listaServico, typeof(IEnumerable<Servico>));
            Assert.IsNotNull(listaServico);
            Assert.AreEqual(3, listaServico.Count());
            Assert.AreEqual((uint)1, listaServico.First().Id);
            Assert.AreEqual("Encanador", listaServico.First().Nome); // Corrigido o nome para coincidir com a inicialização
        }
    }
}