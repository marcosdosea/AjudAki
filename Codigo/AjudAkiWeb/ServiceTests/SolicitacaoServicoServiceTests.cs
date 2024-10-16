using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Service.Tests
{
    [TestClass()]
    public class SolicitacaoServicoServiceTests
    {
        private AjudakiContext context;
        private ISolicitacaoServicoService solicitacaoServicoService;

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
            var solicitacoesServicos = new List<Solicitacaoservico>
                {
                    new()
                    {
                        Id = 1,
                        Nome = "Banho nos cachorros",
                        DataHoraSolicitacao = DateTime.Parse("2024-08-20"),
                        Status ="RECUSADO",
                        Valor = 530m,
                        Descricao = "Preciso que alguém dê banho nós meus 2 cachorros dóceis de porte grande"
                    },
                    new Solicitacaoservico
                    {
                        Id = 2,
                        Nome = "Conserto de notebook",
                        DataHoraSolicitacao = DateTime.Parse("2024-05-03"),
                        Status ="ACEITO",
                        Valor = 150m,
                        Descricao = "O notebook não está dando tela nem nenhum outro sinal de vida"
                    },
                    new Solicitacaoservico
                    {
                        Id = 3,
                        Nome = "Fazer atividade da faculdade de Sistemas de informação",
                        DataHoraSolicitacao = DateTime.Parse("2024-08-10"),
                        Status ="PENDENTE",
                        Valor = 200m,
                        Descricao = "Preciso fazer um TCC"
                    }
                };

            context.AddRange(solicitacoesServicos);
            context.SaveChanges();

            solicitacaoServicoService = new SolicitacaoServicoService(context);
        }



        [TestMethod()]
        public void CreateTest()
        {
            // Act
            solicitacaoServicoService.Create(new Solicitacaoservico()
            {
                Id = 4,
                Nome = "Preciso do pacote office",
                DataHoraSolicitacao = DateTime.Parse("2024-03-10"),
                Status = "ACEITO",
                Valor = 300m,
                Descricao = "O meu notebook não tem word, powerpoint e excel"
            });
            // Assert
            Assert.AreEqual(4, solicitacaoServicoService.GetAll().Count());
            var solicitacaoServico = solicitacaoServicoService.Get(4);
            Assert.AreEqual("Preciso do pacote office", solicitacaoServico.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            solicitacaoServicoService.Delete(2);

            // Assert
            Assert.AreEqual(2, solicitacaoServicoService.GetAll().Count());
            var solicitacaoServico = solicitacaoServicoService.Get(2);
            Assert.AreEqual(null, solicitacaoServico);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var solicitacaoServico = solicitacaoServicoService.Get(3);
            solicitacaoServico.Nome = "Fazer exercício da faculdade de Sistemas de informação";
            solicitacaoServicoService.Edit(solicitacaoServico);

            //Assert
            solicitacaoServico = solicitacaoServicoService.Get(3);
            Assert.IsNotNull(solicitacaoServico);
            Assert.AreEqual("Fazer exercício da faculdade de Sistemas de informação", solicitacaoServico.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var solicitacaoServico = solicitacaoServicoService.Get(1);
            Assert.IsNotNull(solicitacaoServico);
            Assert.AreEqual("Banho nos cachorros", solicitacaoServico.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaSolicitacaoServico = solicitacaoServicoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaSolicitacaoServico, typeof(IEnumerable<Solicitacaoservico>));
            Assert.IsNotNull(listaSolicitacaoServico);
            Assert.AreEqual(3, listaSolicitacaoServico.Count());
            Assert.AreEqual((uint)1, listaSolicitacaoServico.First().Id);
            Assert.AreEqual("Banho nos cachorros", listaSolicitacaoServico.First().Nome);
        }
    }
}
