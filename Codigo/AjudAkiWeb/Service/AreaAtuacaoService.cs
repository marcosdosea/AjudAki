using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AreaAtuacaoService : IAreaAtuacaoService
    {
        private readonly AjudakiContext context;

        public AreaAtuacaoService(AjudakiContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Criar uma nova área de atuação na base de dados
        /// </summary>
        /// <param name="areaAtuacao">dados da área de atuação</param>
        /// <returns>id da área de atuação criada</returns>
        /// <exception cref="NotImplementedException"></exception>
        public uint Create(Areaatuacao areaAtuacao)
        {
            context.Add(areaAtuacao);
            context.SaveChanges();
            return areaAtuacao.Id;
        }

        /// <summary>
        /// Remover área de atuação da base de dados
        /// </summary>
        /// <param name="id">id da área de atuação</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(uint id)
        {
            var areaAtuacao = context.Areaatuacaos
                .Include(a => a.Tiposervicos)
                .FirstOrDefault(a => a.Id == id);

            if (areaAtuacao != null)
            {
                if (areaAtuacao.Tiposervicos != null && areaAtuacao.Tiposervicos.Any())
                {
                    context.Tiposervicos.RemoveRange(areaAtuacao.Tiposervicos);
                }
                context.Remove(areaAtuacao);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados da área de atuação na base de dados
        /// </summary>
        /// <param name="areaAtuacao">dados da área de atuação a ser atualizada</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Edit(Areaatuacao areaAtuacao)
        {
            context.Update(areaAtuacao);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar uma área de atuação na base de dados
        /// </summary>
        /// <param name="id">id da área de atuação</param>
        /// <returns>dados da área de atuação ou null se não encontrada</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Areaatuacao? Get(uint id)
        {
            return context.Areaatuacaos.Find(id);
        }

        /// <summary>
        /// Buscar todas as áreas de atuação cadastradas
        /// </summary>
        /// <returns>lista de áreas de atuação</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Areaatuacao> GetAll()
        {
            return context.Areaatuacaos
                .Include(a => a.Tiposervicos)
                .ThenInclude(t => t.IdAgendaNavigation)
                .AsNoTracking();
        }

        /// <summary>
        /// Buscar áreas de atuação iniciando com o nome
        /// </summary>
        /// <param name="nome">nome da área de atuação</param>
        /// <returns>lista de áreas de atuação que inicia com o nome</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Areaatuacao> ObterPorNomeOrdemdescrecente(string nome)
        {
            var query = from area in context.Areaatuacaos
                        where area.Nome.StartsWith(nome)
                        orderby area.Nome descending
                        select area;
            return query.AsNoTracking().ToList();
        }
    }
}
