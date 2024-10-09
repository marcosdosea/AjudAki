using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class PagarAssinaturaServiceTests
    {
        private AjudakiContext context;
        private IPagarAssinaturaService pagarAssinaturaService;

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

            // Criação da lista de assinaturas com todas as propriedades obrigatórias
            var pagarAssinaturas = new List<Pagamentoassinatura>
        {
            new()
            {
                Id = 1,
                DataPagamento = DateTime.Parse("2024-02-23 14:30"),
                Status = "PAGO",
                NomePlano = "Plano Básico"
            },
            new Pagamentoassinatura
            {
                Id = 2,
                DataPagamento = DateTime.Parse("2024-02-23 14:30"),
                Status = "ATRASADO",
                NomePlano = "Plano Básico"
            },
            new Pagamentoassinatura
            {
                Id = 3,
                DataPagamento = DateTime.Parse("2024-02-23 14:30"),
                Status = "ATIVO",
                NomePlano = "Plano Básico"
            },
        };

            context.AddRange(pagarAssinaturas);
            context.SaveChanges();

            pagarAssinaturaService = new PagarAssinaturaService(context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var novoPagamentoassinatura = new Pagamentoassinatura()
            {
                Id = 4,
                DataPagamento = DateTime.Parse("2024-02-23 14:30"),
                Status = "ATIVO",
                NomePlano = "Plano Básico"
            };

            pagarAssinaturaService.Create(novoPagamentoassinatura);

            // Assert
            Assert.AreEqual(4, pagarAssinaturaService.GetAll().Count());
            var pagarAssinatura = pagarAssinaturaService.Get(4);

            Assert.AreEqual("Plano Básico", pagarAssinatura.NomePlano);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            pagarAssinaturaService.Delete(2);

            // Assert
            Assert.AreEqual(2, pagarAssinaturaService.GetAll().Count());

            var pagarAssinatura = pagarAssinaturaService.Get(2);
            Assert.IsNull(pagarAssinatura);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act 
            var pagarAssinatura = pagarAssinaturaService.Get(3);

            pagarAssinatura.NomePlano = "Padrão";
            pagarAssinaturaService.Edit(pagarAssinatura);

            // Assert
            pagarAssinatura = pagarAssinaturaService.Get(3);

            Assert.IsNotNull(pagarAssinatura);
            Assert.AreEqual("Padrão", pagarAssinatura.NomePlano);
        }

        [TestMethod()]
        public void GetTest()
        {
            var pagarAssinatura = pagarAssinaturaService.Get(1);

            Assert.IsNotNull(pagarAssinatura);
            Assert.AreEqual("Plano Básico", pagarAssinatura.NomePlano);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPagarAssinaturas = pagarAssinaturaService.GetAll();

            // Assert
            Assert.IsInstanceOfType(listaPagarAssinaturas, typeof(IEnumerable<Pagamentoassinatura>));
            Assert.IsNotNull(listaPagarAssinaturas);
            Assert.AreEqual(3, listaPagarAssinaturas.Count());
            Assert.AreEqual((uint)1, listaPagarAssinaturas.First().Id);
            Assert.AreEqual("Plano Básico", listaPagarAssinaturas.First().NomePlano);
        }
    }
}