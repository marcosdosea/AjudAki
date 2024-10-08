using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class ContratacaoServiceTests
    {
        private AjudakiContext context;
        private IContratacaoService contratacaoService;

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

            var contratacaos = new List<Contratacao>
                {
                    new() { Id = 1,
                            Nome = "Laila da encanação",
                            Data = DateTime.Parse("2024-12-31"),
                            Cep = "12345-678",
                            Bairro = "Centro",
                            Rua = "Rua A",
                            NumResidencia = "100",
                            PontoReferencia = "Próximo ao mercado",
                            Status = "Ativo",
                            IdServico = 1,
                            IdCliente = 1
                    },
                    new() { Id = 2,
                            Nome = "Dósea do fogão",
                            Data = DateTime.Parse("2024-11-21"),
                            Cep = "12345-679",
                            Bairro = "Bairro B",
                            Rua = "Rua B",
                            NumResidencia = "101",
                            PontoReferencia = "Em frente ao banco",
                            Status = "Ativo",
                            IdServico = 2,
                            IdCliente = 2
                    },
                    new() { Id = 3,
                            Nome = "Mathias eletricista, filho de Tontonho",
                            Data = DateTime.Parse("2024-11-20"),
                            Cep = "12345-680",
                            Bairro = "Bairro C",
                            Rua = "Rua C",
                            NumResidencia = "102",
                            PontoReferencia = "Perto da escola",
                            Status = "Ativo",
                            IdServico = 3,
                            IdCliente = 3},
                    };

            context.AddRange(contratacaos);
            context.SaveChanges();

            contratacaoService = new ContratacaoService(context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            contratacaoService.Create(new Contratacao()
            {
                Id = 4,
                Nome = "Pedro Pintor",
                Data = DateTime.Parse("2024-12-25"),
                Cep = "12345-681",
                Bairro = "Bairro D",
                Rua = "Rua D",
                NumResidencia = "103",
                PontoReferencia = "Ao lado do posto de gasolina",
                Status = "Ativo",
                IdServico = 4,
                IdCliente = 4
            });

            // Assert
            Assert.AreEqual(4, contratacaoService.GetAll().Count());
            var contratacao = contratacaoService.Get(4);
            Assert.AreEqual("Pedro Pintor", contratacao.Nome);
            Assert.AreEqual(DateTime.Parse("2024-12-25"), contratacao.Data);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            contratacaoService.Delete(2);

            // Assert
            Assert.AreEqual(2, contratacaoService.GetAll().Count());
            var autor = contratacaoService.Get(2);
            Assert.AreEqual(null, autor);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var contratacao = contratacaoService.Get(3);
            contratacao.Nome = "Damares que arruma casa";
            contratacao.Data = DateTime.Parse("2024-11-21");
            contratacao.Cep = "98765-432";
            contratacao.Bairro = "Novo Bairro";
            contratacao.Rua = "Nova Rua";
            contratacao.NumResidencia = "200";
            contratacao.Status = "Finalizado";
            contratacaoService.Edit(contratacao);

            //Assert
            contratacao = contratacaoService.Get(3);
            Assert.IsNotNull(contratacao);
            Assert.AreEqual("Damares que arruma casa", contratacao.Nome);
            Assert.AreEqual(DateTime.Parse("2024-11-21"), contratacao.Data);
            Assert.AreEqual("98765-432", contratacao.Cep);
            Assert.AreEqual("Novo Bairro", contratacao.Bairro);
            Assert.AreEqual("Nova Rua", contratacao.Rua);
            Assert.AreEqual("200", contratacao.NumResidencia);
            Assert.AreEqual("Finalizado", contratacao.Status);
        }

        [TestMethod()]
        public void GetTest()
        {
            var contratacao = contratacaoService.Get(2);
            Assert.IsNotNull(contratacao);
            Assert.AreEqual("Dósea do fogão", contratacao.Nome);
            Assert.AreEqual(DateTime.Parse("2024-11-21"), contratacao.Data);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaContratacao = contratacaoService.GetAll();

            // Assert
            Assert.IsInstanceOfType(listaContratacao, typeof(IEnumerable<Contratacao>));
            Assert.IsNotNull(listaContratacao);
            Assert.AreEqual(3, listaContratacao.Count());
            Assert.AreEqual((uint)1, listaContratacao.First().Id);
            Assert.AreEqual("Laila da encanação", listaContratacao.First().Nome);
        }
    }
}