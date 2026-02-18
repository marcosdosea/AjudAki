using Microsoft.EntityFrameworkCore;
using Core;
using Core.Service;
using AjudAkiWeb.Models;
namespace Service.Tests
{
    [TestClass()]
    public class AssinaturaServiceTests
    {
        private AjudakiContext context;
        private IAssinaturaService assinaturaService;

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

            var assinaturas = new List<Assinatura>
            {
                new Assinatura
                {
                    Id = 1,
                    Nome = AssinaturaNomeEnum.BÁSICO.ToString(),
                    Status = AssinaturaStatusEnum.ATIVA.ToString(),
                    Descricao = "Plano com funcionalidades básicas"
                },
                new Assinatura
                {
                    Id = 2,
                    Nome = AssinaturaNomeEnum.AVANÇADO.ToString(),
                    Status = AssinaturaStatusEnum.INATIVA.ToString(),
                    Descricao = "Plano com funcionalidades avançadas"
                },
                new Assinatura
                {
                    Id = 3,
                    Nome = AssinaturaNomeEnum.AVANÇADO.ToString(),
                    Status = AssinaturaStatusEnum.ATIVA.ToString(),
                    Descricao = "Plano premium com todas as funcionalidades"
                },
            };

            context.AddRange(assinaturas);
            context.SaveChanges();

            assinaturaService = new AssinaturaService(context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var novaAssinatura = new Assinatura()
            {
                Id = 4,
                Nome = AssinaturaNomeEnum.AVANÇADO.ToString(),
                Status = AssinaturaStatusEnum.ATIVA.ToString()
            };

            assinaturaService.Create(novaAssinatura);

            // Assert
            Assert.AreEqual(4, assinaturaService.GetAll().Count());
            var assinatura = assinaturaService.Get(4);

            Assert.AreEqual(AssinaturaNomeEnum.AVANÇADO.ToString(), assinatura.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            assinaturaService.Delete(2);

            // Assert
            Assert.AreEqual(2, assinaturaService.GetAll().Count());

            var assinatura = assinaturaService.Get(2);
            Assert.IsNull(assinatura);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act 
            var assinatura = assinaturaService.Get(3);

            assinatura.Nome = AssinaturaNomeEnum.AVANÇADO.ToString();
            assinaturaService.Edit(assinatura);

            // Assert
            assinatura = assinaturaService.Get(3);

            Assert.IsNotNull(assinatura);
            Assert.AreEqual(AssinaturaNomeEnum.AVANÇADO.ToString(), assinatura.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var assinatura = assinaturaService.Get(1);

            Assert.IsNotNull(assinatura);
            Assert.AreEqual(AssinaturaNomeEnum.BÁSICO.ToString(), assinatura.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAssinaturas = assinaturaService.GetAll();

            // Assert
            Assert.IsInstanceOfType(listaAssinaturas, typeof(IEnumerable<Assinatura>));
            Assert.IsNotNull(listaAssinaturas);
            Assert.AreEqual(3, listaAssinaturas.Count());
            Assert.AreEqual((uint)1, listaAssinaturas.First().Id);
            Assert.AreEqual(AssinaturaNomeEnum.BÁSICO.ToString(), listaAssinaturas.First().Nome);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_AssinaturaNull_DeveLancarArgumentNullException()
        {
            assinaturaService.Create(null!);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Delete_IdInexistente_DeveLancarInvalidOperationException()
        {
            assinaturaService.Delete(999);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Edit_AssinaturaNull_DeveLancarArgumentNullException()
        {
            assinaturaService.Edit(null!);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Edit_IdInexistente_DeveLancarInvalidOperationException()
        {
            var assinaturaInexistente = new Assinatura
            {
                Id = 999,
                Nome = AssinaturaNomeEnum.BÁSICO.ToString(),
                Status = AssinaturaStatusEnum.ATIVA.ToString()
            };
            assinaturaService.Edit(assinaturaInexistente);
        }

        [TestMethod()]
        public void Get_IdInexistente_DeveRetornarNull()
        {
            var assinatura = assinaturaService.Get(999);
            Assert.IsNull(assinatura);
        }

        [TestMethod()]
        public void Create_DevePersistirDescricaoEStatus()
        {
            var novaAssinatura = new Assinatura
            {
                Id = 4,
                Nome = AssinaturaNomeEnum.BÁSICO.ToString(),
                Status = AssinaturaStatusEnum.ATIVA.ToString(),
                Descricao = "Plano novo com descricao completa"
            };

            assinaturaService.Create(novaAssinatura);
            var assinaturaSalva = assinaturaService.Get(4);

            Assert.IsNotNull(assinaturaSalva);
            Assert.AreEqual("Plano novo com descricao completa", assinaturaSalva.Descricao);
            Assert.AreEqual(AssinaturaStatusEnum.ATIVA.ToString(), assinaturaSalva.Status);
        }
    }
}
