using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class AreaAtuacaoService : IAreaAtuacaoService
    {

        private readonly AjudakiContext context;
        public AreaAtuacaoService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria uma nova área de atuação na base de dados
        /// </summary>
        /// <param name="areaatuacao">Nome da área</param>
        /// <returns>id da área de atuação</returns>
        /// <exception cref="NotImplementedException"></exception>

        public uint Create(Areaatuacao areaatuacao)
        {
            context.Add(areaatuacao);
            context.SaveChanges();
            return areaatuacao.Id;
        }

        /// <summary>
        /// Remove a área de atuação da base de dados
        /// </summary>
        /// <param name="idAreaAtuacao"></param>
        /// <exception cref="NotImplementedException"></exception>

        public void Delete(uint idAreaAtuacao)
        {
            var areaatuacao = context.Areaatuacaos.Find(idAreaAtuacao);
            if (areaatuacao != null)
            {
                context.Remove(areaatuacao);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edita a área de atuação
        /// </summary>
        /// <param name="areaatuacao"></param>

        public void Edit(Areaatuacao areaatuacao)
        {
            context.Update(areaatuacao);
            context.SaveChanges();
        }

        /// <summary>
        /// Busca uma área de atuação
        /// </summary>
        /// <param name="idAreaAtuacao"></param>
        /// <returns>Área de atuação</returns>
        /// <exception cref="NotImplementedException"></exception>

        public Areaatuacao? Get(uint idAreaAtuacao)
        {
            return context.Areaatuacaos.Find(idAreaAtuacao);
        }

        /// <summary>
        /// Busca as áreas de atuação
        /// </summary>
        /// <returns>Lista de Áreas de atuação</returns>
        
        public IEnumerable<Areaatuacao> GetAll()
        {
            return context.Areaatuacaos.AsNoTracking();
        }
    }
}
