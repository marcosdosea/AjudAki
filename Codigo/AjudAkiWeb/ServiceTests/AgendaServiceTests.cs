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
            var autores = new List<Areaatuacao>
                {
                    new() { Id = 1, Nome = "Educação"},
                    new Areaatuacao { Id = 2, Nome = "Tecnologia"},
                    new Areaatuacao { Id = 3, Nome = "Marketing"},
                };

            context.AddRange(autores);
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
            var areaatuacao = areaAtuacaoService.Get(4);
            Assert.AreEqual("Construção", areaatuacao.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            areaAtuacaoService.Delete(2);
            // Assert
            Assert.AreEqual(2, areaAtuacaoService.GetAll().Count());
            var areaatuacao = areaAtuacaoService.Get(2);
            Assert.AreEqual(null, areaatuacao);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var areaatuacao = areaAtuacaoService.Get(3);
            areaatuacao.Nome = "Design";
            areaAtuacaoService.Edit(areaatuacao);
            //Assert
            areaatuacao = areaAtuacaoService.Get(3);
            Assert.IsNotNull(areaatuacao);
            Assert.AreEqual("Design", areaatuacao.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var areaatuacao = areaAtuacaoService.Get(1);
            Assert.IsNotNull(areaatuacao);
            Assert.AreEqual("Educação", areaatuacao.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAutor = areaAtuacaoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAutor, typeof(IEnumerable<Areaatuacao>));
            Assert.IsNotNull(listaAutor);
            Assert.AreEqual(3, listaAutor.Count());
            Assert.AreEqual((uint)1, listaAutor.First().Id);
            Assert.AreEqual("Educação", listaAutor.First().Nome);
        }

    }
}