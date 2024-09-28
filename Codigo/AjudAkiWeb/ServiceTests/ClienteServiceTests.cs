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
    public class ClienteServiceTests
    {
        private AjudakiContext context;
        private IClienteService clienteService;

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
            var clientes = new List<Pessoa>
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

            context.AddRange(clientes);
            context.SaveChanges();

            clienteService = new ClienteService(context);
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

            clienteService.Create(novaPessoa);

            // Assert
            Assert.AreEqual(4, clienteService.GetAll().Count());
            var cliente = clienteService.Get(4);

            Assert.AreEqual("Pedro Ramos", cliente.Nome);
            Assert.AreEqual(DateTime.Parse("2003-12-25"), cliente.DataNascimento);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            clienteService.Delete(2);

            // Assert
            Assert.AreEqual(2, clienteService.GetAll().Count());

            var cliente = clienteService.Get(2);
            Assert.IsNull(cliente);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act 
            var cliente = clienteService.Get(3);

            cliente.Nome = "Paulo Lima";
            cliente.DataNascimento = DateTime.Parse("1993-11-21");
            clienteService.Edit(cliente);

            // Assert
            cliente = clienteService.Get(3);

            Assert.IsNotNull(cliente);
            Assert.AreEqual("Paulo Lima", cliente.Nome);
            Assert.AreEqual(DateTime.Parse("1993-11-21"), cliente.DataNascimento);
        }

        [TestMethod()]
        public void GetTest()
        {
            var cliente = clienteService.Get(1);

            Assert.IsNotNull(cliente);
            Assert.AreEqual("Pedro de Assis", cliente.Nome); // Corrigido o nome para coincidir com a inicialização
            Assert.AreEqual(DateTime.Parse("2000-12-31"), cliente.DataNascimento);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaCliente = clienteService.GetAll();

            // Assert
            Assert.IsInstanceOfType(listaCliente, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaCliente);
            Assert.AreEqual(3, listaCliente.Count());
            Assert.AreEqual((uint)1, listaCliente.First().Id);
            Assert.AreEqual("Pedro de Assis", listaCliente.First().Nome); // Corrigido o nome para coincidir com a inicialização
        }
    }
}
