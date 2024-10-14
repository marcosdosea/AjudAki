using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class TipoServicoServiceTests
    {
        private AjudakiContext context;
        private ITipoServicoService tipoServicoService;

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
            var classes = new List<Tiposervico>
                {
                    new() { Id = 1, Nome = "Educação"},
                    new Tiposervico { Id = 2, Nome = "Tecnologia"},
                    new Tiposervico { Id = 3, Nome = "Marketing"},
                };

            context.AddRange(classes);
            context.SaveChanges();

            tipoServicoService = new TipoServicoService(context);
        }



        [TestMethod()]
        public void CreateTest()
        {
            // Act
            tipoServicoService.Create(new Tiposervico() { Id = 4, Nome = "Construção" });
            // Assert
            Assert.AreEqual(4, tipoServicoService.GetAll().Count());
            var tipoServico = tipoServicoService.Get(4);
            Assert.AreEqual("Construção", tipoServico.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            tipoServicoService.Delete(2);
            // Assert
            Assert.AreEqual(2, tipoServicoService.GetAll().Count());
            var tipoServico = tipoServicoService.Get(2);
            Assert.AreEqual(null, tipoServico);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var tipoServico = tipoServicoService.Get(3);
            tipoServico.Nome = "Design";
            tipoServicoService.Edit(tipoServico);
            //Assert
            tipoServico = tipoServicoService.Get(3);
            Assert.IsNotNull(tipoServico);
            Assert.AreEqual("Design", tipoServico.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var tipoServico = tipoServicoService.Get(1);
            Assert.IsNotNull(tipoServico);
            Assert.AreEqual("Educação", tipoServico.Nome);
        }
        
        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listatiposServicos = tipoServicoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaTiposServicos, typeof(IEnumerable<Tiposervico>));
            Assert.IsNotNull(listaTiposServicos);
            Assert.AreEqual(3, listaTiposServicos.Count());
            Assert.AreEqual((uint)1, listaTiposServicos.First().Id);
            Assert.AreEqual("Educação", listaTiposServicos.First().Nome);
        }

    }
}
