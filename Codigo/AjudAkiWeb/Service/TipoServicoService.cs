using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{

    /// <summary>
    /// Implementa serviços para manter tipos de serviço.
    /// </summary>
    public class TipoServicoService : ITipoServicoService
    {
        private readonly AjudakiContext context;

        public TipoServicoService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar um novo tipo de serviço na base de dados
        /// </summary>
        /// <param name="tiposervico">Tipo de Serviço</param>
        /// <returns>Id do tipo do serviço criado.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public uint Create(Tiposervico tipoServico)
        {
            context.Add(tipoServico);
            context.SaveChanges();
            return tipoServico.Id;
        }

        /// <summary>
        /// Remover o tipo de serviço da base de dados
        /// </summary>
        /// <param name="id">Id do tipo de serviço a ser removido.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(uint id)
        {
            var tipoServico = context.Tiposervicos.Find(id);
            if (tipoServico != null)
            {
                context.Remove(tipoServico);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do tipo de serviço na base de dados
        /// </summary>
        /// <param name="tiposervico">Objeto do tipo de serviço com os novos dados.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Edit(Tiposervico tipoServico)
        {
            context.Update(tipoServico);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar um  tipo de serviço na base de dados
        /// </summary>
        /// <param name="id">Id do tipo de serviço a ser buscado.</param>
        /// <returns>Objeto do tipo de serviço encontrado ou null, caso não exista.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Tiposervico? Get(uint id)
        {
            return context.Tiposervicos
                .Include(t => t.IdAreaAtuacaoNavigation)
                .Include(t => t.IdAgendaNavigation)
                .FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Buscar todos os tipos de serviços cadastrados
        /// </summary>
        /// <returns>Coleção dos tipos de serviços cadastrados.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Tiposervico> GetAll()
        {
            // Use AsNoTracking for read-only queries to improve performance
            return context.Tiposervicos
                .Include(t => t.IdAreaAtuacaoNavigation)
                .Include(t => t.IdAgendaNavigation)
                .AsNoTracking();
        }

        /// <summary>
        /// Buscar tipos de serviço por nome em ordem crescente
        /// </summary>
        /// <param name="nome">Nome do tipo de serviço</param>
        /// <returns>Coleção de tipos de serviço.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Tiposervico> ObterPorNomeOrdemCrescente(string nome)
        {
            var query = from ts in context.Tiposervicos
                        where ts.Nome.StartsWith(nome)
                        orderby ts.Nome ascending
                        select ts;
            return query.AsNoTracking().ToList();
        }
    }
}
