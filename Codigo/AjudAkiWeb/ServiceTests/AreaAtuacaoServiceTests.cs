using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace Service.Tests
{
    [TestClass()]
    public class AreaAtuacaoServiceTests
    {
        private AjudakiContext context;
        private IAreaAtuacaoService areaAtuacaoService;

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
            var agendas = new List<Areaatuacao>
                {
                    new() { Id = 1, Nome = "Educação"},
                    new Areaatuacao { Id = 2, Nome = "Tecnologia"},
                    new Areaatuacao { Id = 3, Nome = "Marketing"},
                };

            context.AddRange(agendas);
            context.SaveChanges();

            areaAtuacaoService = new AreaAtuacaoService(context);
        }



        [TestMethod()]
        public void CreateTest()
        {
            // Act
            areaAtuacaoService.Create(new Areaatuacao() { Id = 4, Nome = "Construção" });
            // Assert
            Assert.AreEqual(4, areaAtuacaoService.GetAll().Count());
            var areaAtuacao = areaAtuacaoService.Get(4);
            Assert.AreEqual("Construção", areaAtuacao.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            areaAtuacaoService.Delete(2);
            // Assert
            Assert.AreEqual(2, areaAtuacaoService.GetAll().Count());
            var areaAtuacao = areaAtuacaoService.Get(2);
            Assert.AreEqual(null, areaAtuacao);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var areaAtuacao = areaAtuacaoService.Get(3);
            areaAtuacao.Nome = "Design";
            areaAtuacaoService.Edit(areaAtuacao);
            //Assert
            areaAtuacao = areaAtuacaoService.Get(3);
            Assert.IsNotNull(areaAtuacao);
            Assert.AreEqual("Design", areaAtuacao.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var areaAtuacao = areaAtuacaoService.Get(1);
            Assert.IsNotNull(areaAtuacao);
            Assert.AreEqual("Educação", areaAtuacao.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAreaAtuacao = areaAtuacaoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAreaAtuacao, typeof(IEnumerable<Areaatuacao>));
            Assert.IsNotNull(listaAreaAtuacao);
            Assert.AreEqual(3, listaAreaAtuacao.Count());
            Assert.AreEqual((uint)1, listaAreaAtuacao.First().Id);
            Assert.AreEqual("Educação", listaAreaAtuacao.First().Nome);
        }

    }
}
