using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;


namespace Service
{
    /// <summary>
    /// Implementa pagamentos para Pagamentoassinatura
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
        /// <param name="pagamentoAssinatura">dados do cartão</param>
        /// <returns>novo cartão adicionado</returns>
        public uint Create(Pagamentoassinatura pagamentoAssinatura)
        {
            context.Add(pagamentoAssinatura);
            context.SaveChanges();
            return pagamentoAssinatura.Id;
        }

        /// <summary>
        /// Remover um plano da base de dados
        /// </summary>
        /// <param name="id">id do plano</param>
        public void Delete(uint id)
        {
            var pagamentoAssinatura = context.Pagamentoassinaturas.Find(id);
            if (pagamentoAssinatura != null)
            {
                //pagamentoAssinatura.Status = "Cancelada";
                context.Remove(pagamentoAssinatura);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Alterar plano de assinatura na base de dados
        /// </summary>
        /// <param name="pagamentoAssinatura"></param>
        public void Edit(Pagamentoassinatura pagamentoAssinatura)
        {
            context.Update(pagamentoAssinatura);
            context.SaveChanges();
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
