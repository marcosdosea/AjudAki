
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Service
{
    /// <summary>
    /// Implementa serviçoes para o manter solicitação serviço
    /// </summary>
    public class SolicitacaoServicoService : ISolicitacaoServicoService
    {
        private readonly AjudakiContext context;

        public SolicitacaoServicoService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria uma nova solicitação de serviço na base de dados
        /// </summary>
        /// <param name="solicitacaoServico"></param>
        /// <returns>dados da solicitação</returns>
        public uint Create(Solicitacaoservico solicitacaoServico)
        {
            context.Add(solicitacaoServico);
            context.SaveChanges();

            return solicitacaoServico.Id;
        }

        /// <summary>
        /// Deleta uma solicitação de serviço da base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var solicitacaoServico = context.Solicitacaoservicos.Find(id);
            if (solicitacaoServico != null)
            {
                context.Remove(solicitacaoServico);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edita uma solicitação de serviço
        /// </summary>
        /// <param name="solicitacaoServico"></param>
        public void Edit(Solicitacaoservico solicitacaoServico)
        {
            context.Update(solicitacaoServico);
            context.SaveChanges();
        }

        /// <summary>
        /// Busca uma solicitação de serviço
        /// </summary>
        /// <param name="id"></param>
        /// <returns>dados da solicitação</returns>
        public Solicitacaoservico? Get(uint id)
        {
            return context.Solicitacaoservicos
                .AsNoTracking()
                .FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Busca todas as solicitações de serviços
        /// </summary>
        /// <returns>lista de solicitações</returns>
        public IEnumerable<Solicitacaoservico> GetAll()
        {
            return context.Solicitacaoservicos.AsNoTracking();
        }

        /// <summary>
        /// Busca uma solicitação por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>lista de solicitações com o nome informado</returns>
        public IEnumerable<Solicitacaoservico> GetByNome(string nome)
        {
            return context.Solicitacaoservicos.Where(Solicitacaoservico => Solicitacaoservico.
                                                     Nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
