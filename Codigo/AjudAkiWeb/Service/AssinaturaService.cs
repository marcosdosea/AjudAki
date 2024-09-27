using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa assinatura para manter assinaturas.
    /// </summary>
    public class AssinaturaService : IAssinaturaService
    {
        private readonly AjudakiContext context;

        public AssinaturaService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar uma nova assinatura na base de dados
        /// </summary>
        /// <param name="assinatura">dados da assinatura</param>
        /// <returns>nova assinatura criada</returns>
        public uint Create(Assinatura assinatura)
        {
            context.Add(assinatura);
            context.SaveChanges();
            return assinatura.Id;
        }

        /// <summary>
        /// Remover assinatura da base de dados
        /// </summary>
        /// <param name="id">id da assinatura</param>
        public void Delete(uint id)
        {
            var assinatura = context.Assinaturas.Find(id);
            if (assinatura != null)
            {
                context.Remove(assinatura);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados da assiantura na base de dados
        /// </summary>
        /// <param name="assinatura"></param>
        public void Edit(Assinatura assinatura)
        {
            context.Update(assinatura);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar uma assinatura na base de dados
        /// </summary>
        /// <param name="id">id da assinatura</param>
        /// <returns>dados da assinatura</returns>
        public Assinatura? Get(uint id)
        {
            return context.Assinaturas.Find(id);
        }

        /// <summary>
        /// Buscar todas as assinaturas cadastradas
        /// </summary>
        /// <returns>lista de assinaturas</returns>
        public IEnumerable<Assinatura> GetAll()
        {
            return context.Assinaturas.AsNoTracking();
        }
    }
}
