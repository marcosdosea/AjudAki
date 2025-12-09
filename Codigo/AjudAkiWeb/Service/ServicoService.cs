using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviços para manter o ofertar serviço.
    /// </summary>
    public class ServicoService : IServicoService
    {
        private readonly AjudakiContext context;

        public ServicoService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar um novo serviço na base de dados
        /// </summary>
        /// <param name="servico">Objeto do serviço a ser criado.</param>
        /// <returns>Id do serviço recém-criado.</returns>
        public uint Create(Servico servico)
        {
            context.Add(servico);
            context.SaveChanges();
            return servico.Id;
        }

        /// <summary>
        /// Remover o serviço da base de dados
        /// </summary>
        /// <param name="id">Id do serviço a ser removido.</param>
        public void Delete(uint id)
        {
            var servico = context.Servicos.Find(id);
            if (servico != null)
            {
                context.Remove(servico);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do serviço na base de dados
        /// </summary>
        /// <param name="servico">Objeto do serviço com os novos dados.</param>
        public void Edit(Servico servico)
        {
            context.Update(servico);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar um serviço na base de dados
        /// </summary>
        /// <param name="id">Id do serviço a ser buscado.</param>
        /// <returns>Objeto do serviço encontrado ou null, caso não exista.</returns>
        public Servico? Get(uint id)
        {
            return context.Servicos.Find(id);
        }

        /// <summary>
        /// Buscar todos os serviços cadastrados
        /// </summary>
        /// <returns>Coleção de serviços cadastrados.</returns>
        public IEnumerable<Servico> GetAll()
        {
            return context.Servicos.AsNoTracking();
        }

        /// <summary>
        /// Buscar todos os serviços cadastrados na página inicial
        /// </summary>
        /// <returns>Coleção de serviços cadastrados.</returns>
        public IEnumerable<Servico> BuscarPorFiltro(uint? idTipoServico, uint? idAreaAtuacao, uint? idProfissional)
        {
            var query = context.Servicos
                .AsNoTracking()
                .Include(s => s.IdProfissionalNavigation)
                .AsQueryable();

            if (idTipoServico.HasValue)
            {
                query = query.Where(s => s.IdTipoServico == idTipoServico.Value);
            }

            if (idAreaAtuacao.HasValue)
            {
                query = query.Where(s => s.IdAreaAtuacao == idAreaAtuacao.Value);
            }

            if (idProfissional.HasValue)
            {
                query = query.Where(s => s.IdProfissionalNavigation.Id == idProfissional.Value);
            }

            return query.ToList();
        }
    }
}

