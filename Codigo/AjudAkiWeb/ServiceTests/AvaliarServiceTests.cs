﻿using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests
{
    [TestClass()]
    public class AvaliarServiceTests
    {
        private AjudakiContext context;
        private IAvaliarService avaliarService;

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

            var avaliacoes = new List<Avaliacao>
            {
                new() { Id = 1, NotaServico = 2, NotaProfissional = 2, Status = 1, Comentario = "Ótimo serviço", IdContratacao = 101 },
                new() { Id = 2, NotaServico = 3, NotaProfissional = 3, Status = 2, Comentario = "Serviço razoável", IdContratacao = 102 },
                new() { Id = 3, NotaServico = 4, NotaProfissional = 4, Status = 1, Comentario = "Profissional abaixo da média", IdContratacao = 103 },
            };

            context.Avaliacaos.AddRange(avaliacoes);
            context.SaveChanges();

            avaliarService = new AvaliarService(context);
        }
        public void GetTest()
        {
            var avaliacao = avaliarService.Get(2); 
            Assert.IsNotNull(avaliacao);  
            Assert.AreEqual("Serviço razoável", avaliacao.Comentario); 
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            avaliarService.Create(new Avaliacao() { Id = 4, NotaServico = 2, NotaProfissional = 4, Status = 1, Comentario = "Excelente", IdContratacao = 104 });
            // Assert
            Assert.AreEqual(4, avaliarService.GetAll().Count());
            var avaliacao = avaliarService.Get(4);
            Assert.AreEqual("Excelente", avaliacao.Comentario);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAvaliacoes = avaliarService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAvaliacoes, typeof(IEnumerable<Avaliacao>));
            Assert.IsNotNull(listaAvaliacoes);
            Assert.AreEqual(3, listaAvaliacoes.Count());
            Assert.AreEqual((uint)1, listaAvaliacoes.First().Id);
            Assert.AreEqual("Ótimo serviço", listaAvaliacoes.First().Comentario);
        }
    }
}