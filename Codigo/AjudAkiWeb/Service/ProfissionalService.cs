﻿using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class ProfissionalService : IProfissionalService
    {
        private readonly AjudakiContext context;
        public ProfissionalService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar um novo profissional na base de dados
        /// </summary>
        /// <param name="profissional"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public uint Create(Pessoa profissional)
        {
            context.Add(profissional);
            context.SaveChanges();
            return profissional.Id;
        }

        /// <summary>
        /// Remover o profissional da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int id)
        {
            var profissional = context.Pessoas.Find(id);
            if (profissional != null)
            {
                context.Remove(profissional);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do profissional na base de dados
        /// </summary>
        /// <param name="profissional"></param>
        /// <exception cref="ServiceException"></exception>
        public void Edit(Pessoa profissional)
        {
            if (profissional.TipoPessoa != "PROFISSIONAL")
            {
                throw new ServiceException("Somente usuários do tipo PROFISSIONAL podem ser editados por este serviço.");
            }
            context.Update(profissional);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar um profissional na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Pessoa? Get(int id)
        {
            return context.Pessoas.Find(id);
        }

        /// <summary>
        /// Buscar todos os profissionais cadastrados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }

        /// <summary>
        /// Buscar profissional iniciando com o nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Pessoa> GetByNome(string nome)
        {
            return (IEnumerable<Pessoa>)context.Pessoas.Where(Pessoa => Pessoa.Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}