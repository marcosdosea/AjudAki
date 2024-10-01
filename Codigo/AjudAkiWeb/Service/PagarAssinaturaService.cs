using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa pagamentos para Pagamentoassinatura.
    /// </summary>
    class PagarAssinaturaService : IPagarAssinaturaService
    {
        private readonly AjudakiContext context;

        public PagarAssinaturaService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adicionar um novo cartão na base de dados
        /// </summary>
        /// <param name="pagamentoassinatura">dados do cartão</param>
        /// <returns>novo cartão adicionado</returns>
        public uint Create(Pagamentoassinatura pagamentoassinatura)
        {
            context.Add(pagamentoassinatura);
            context.SaveChanges();
            return pagamentoassinatura.Id;
        }

        /// <summary>
        /// Remover um plano da base de dados
        /// </summary>
        /// <param name="id">id do plano</param>
        public void Delete(uint id)
        {
            var pagamentoassinatura = context.Pagamentoassinaturas.Find(id);
            if (pagamentoassinatura != null)
            {
                //pagamentoassinatura.Status = "Cancelada";
                context.Remove(pagamentoassinatura);
                context.SaveChanges();
            }
        }

        public void Edit(Pagamentoassinatura pagamentoassinatura)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buscar um pagamento na base de dados
        /// </summary>
        /// <param name="id">id do pagamento</param>
        /// <returns>dados do pagamento</returns>
        public Pagamentoassinatura? Get(uint id)
        {
            return context.Pagamentoassinaturas.Find(id);
        }

        /// <summary>
        /// Buscar todos os pagamentos cadastradas
        /// </summary>
        /// <returns>lista de assinaturas</returns>
        public IEnumerable<Pagamentoassinatura> GetAll()
        {
            return context.Pagamentoassinaturas.AsNoTracking();
        }
    }
}
