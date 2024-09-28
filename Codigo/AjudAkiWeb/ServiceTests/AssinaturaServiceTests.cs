using Microsoft.EntityFrameworkCore;
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
namespace Service.Tests
{
    [TestClass()]
    public class ClienteServiceTests
    {
        private AjudakiContext context;
        private IClienteService assinaturaService;

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

            // Criação da lista de clientes com todas as propriedades obrigatórias
            var assinaturas = new List<Pessoa>
            {
                new()
                {
                    Id = 1,
                    Nome = "Padrão",
                    Descricao = "Plano basico"
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Ian S. Sommervile",
                    
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Laila Esterfane",
                    
                },
            };

            context.AddRange(assinaturas);
            context.SaveChanges();

            assinaturaService = new ClienteService(context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var novaPessoa = new Pessoa()
            {
                Id = 4,
                Nome = "Pedro Ramos",
                
            };

            assinaturaService.Create(novaAssinatura);

            // Assert
            Assert.AreEqual(4, assinaturaService.GetAll().Count());
            var assinatura = assinaturaService.Get(4);

            Assert.AreEqual("Pedro Ramos", assinatura.Nome);
            Assert.AreEqual(DateTime.Parse("2003-12-25"), assinatura.DataNascimento);
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

            assinatura.Nome = "Paulo Lima";
            assinaturaService.Edit(assinatura);

            // Assert
            assinatura = assinaturaService.Get(3);

            Assert.IsNotNull(assinatura);
            Assert.AreEqual("Paulo Lima", assinatura.Nome);
            Assert.AreEqual(DateTime.Parse("1993-11-21"), assinatura.DataNascimento);
        }

        [TestMethod()]
        public void GetTest()
        {
            var assinatura = assinaturaService.Get(1);

            Assert.IsNotNull(assinatura);
            Assert.AreEqual("Pedro de Assis", assinatura.Nome); // Corrigido o nome para coincidir com a inicialização
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAssinaturas = assinaturaService.GetAll();

            // Assert
            Assert.IsInstanceOfType(listaAssinatura, typeof(IEnumerable<Assinatura>));
            Assert.IsNotNull(listaAssinatura);
            Assert.AreEqual(3, listaAssinatura.Count());
            Assert.AreEqual((uint)1, listaAssinatura.First().Id);
            Assert.AreEqual("Pedro de Assis", listaAssinatura.First().Nome); // Corrigido o nome para coincidir com a inicialização
        }
    }
}