using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests
{
    [TestClass()]
    public class ProfissionalServiceTests
    {
        private AjudakiContext context;
        private IProfissionalService profissionalService;

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

            // Criação da lista de profissionais com todas as propriedades obrigatórias
            var profissionais = new List<Pessoa>
            {
                new()
                {
                    Id = 1,
                    Nome = "Pedro de Assis",
                    DataNascimento = DateTime.Parse("2000-12-31"),
                    Bairro = "Centro",
                    Celular = "999999999",
                    Cep = "49000-000",
                    Cpf = "12345678901",
                    Email = "pedro@example.com",
                    NumResidencia = "123",
                    Rua = "Rua Exemplo",
                    TipoPessoa = "Cliente"
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Ian S. Sommervile",
                    DataNascimento = DateTime.Parse("1935-12-31"),
                    Bairro = "Bairro A",
                    Celular = "888888888",
                    Cep = "49000-001",
                    Cpf = "98765432100",
                    Email = "ian@example.com",
                    NumResidencia = "456",
                    Rua = "Rua Exemplo 2",
                    TipoPessoa = "Cliente"
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Laila Esterfane",
                    DataNascimento = DateTime.Parse("1998-11-20"),
                    Bairro = "Bairro B",
                    Celular = "777777777",
                    Cep = "49000-002",
                    Cpf = "11122333444",
                    Email = "laila@example.com",
                    NumResidencia = "789",
                    Rua = "Rua Exemplo 3",
                    TipoPessoa = "Profissional"
                },
            };

            context.AddRange(profissionais);
            context.SaveChanges();

            profissionalService = new ProfissionalService(context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var novaPessoa = new Pessoa()
            {
                Id = 4,
                Nome = "Pedro Ramos",
                DataNascimento = DateTime.Parse("2003-12-25"),
                Bairro = "Bairro C",
                Celular = "666666666",
                Cep = "49000-003",
                Cpf = "22233344555",
                Email = "pedroramos@example.com",
                NumResidencia = "321",
                Rua = "Rua Exemplo 4",
                TipoPessoa = "Profissional"
            };

            profissionalService.Create(novaPessoa);

            // Assert
            Assert.AreEqual(4, profissionalService.GetAll().Count());
            var profissional = profissionalService.Get(4);

            Assert.AreEqual("Pedro Ramos", profissional.Nome);
            Assert.AreEqual(DateTime.Parse("2003-12-25"), profissional.DataNascimento);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            profissionalService.Delete(2);

            // Assert
            Assert.AreEqual(2, profissionalService.GetAll().Count());

            var profissional = profissionalService.Get(2);
            Assert.IsNull(profissional);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act 
            var profissional = profissionalService.Get(3);

            profissional.Nome = "Paulo Lima";
            profissional.DataNascimento = DateTime.Parse("1993-11-21");
            profissionalService.Edit(profissional);

            // Assert
            profissional = profissionalService.Get(3);

            Assert.IsNotNull(profissional);
            Assert.AreEqual("Paulo Lima", profissional.Nome);
            Assert.AreEqual(DateTime.Parse("1993-11-21"), profissional.DataNascimento);
        }

        [TestMethod()]
        public void GetTest()
        {
            var profissional = profissionalService.Get(1);

            Assert.IsNotNull(profissional);
            Assert.AreEqual("Pedro de Assis", profissional.Nome); // Corrigido o nome para coincidir com a inicialização
            Assert.AreEqual(DateTime.Parse("2000-12-31"), profissional.DataNascimento);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaProfissional = profissionalService.GetAll();

            // Assert
            Assert.IsInstanceOfType(listaProfissional, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaProfissional);
            Assert.AreEqual(3, listaProfissional.Count());
            Assert.AreEqual((uint)1, listaProfissional.First().Id);
            Assert.AreEqual("Pedro de Assis", listaProfissional.First().Nome); // Corrigido o nome para coincidir com a inicialização
        }
        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var profissionais = profissionalService.GetByNome("Pedro");
            //Assert
            Assert.IsNotNull(profissionais);
            Assert.AreEqual(1, profissionais.Count());
            Assert.AreEqual("Pedro de Assis", profissionais.First().Nome);
        }
    }
}
