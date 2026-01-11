using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviço para manter assinaturas.
    /// </summary>
    public class AssinaturaService : IAssinaturaService
    {
        private readonly AjudakiContext context;

        public AssinaturaService(AjudakiContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Criar uma nova assinatura na base de dados
        /// </summary>
        /// <param name="assinatura">dados da assinatura</param>
        /// <returns>ID da assinatura criada</returns>
        /// <exception cref="ArgumentNullException">Quando assinatura é null</exception>
        public uint Create(Assinatura assinatura)
        {
            if (assinatura == null)
                throw new ArgumentNullException(nameof(assinatura));

            try
            {
                context.Add(assinatura);
                context.SaveChanges();
                return assinatura.Id;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Erro ao criar assinatura na base de dados.", ex);
            }
        }

        /// <summary>
        /// Remover assinatura da base de dados
        /// </summary>
        /// <param name="id">id da assinatura</param>
        /// <exception cref="InvalidOperationException">Quando assinatura não é encontrada</exception>
        public void Delete(uint id)
        {
            var assinatura = context.Assinaturas.Find(id);
            if (assinatura == null)
                throw new InvalidOperationException($"Assinatura com ID {id} não encontrada.");

            try
            {
                context.Remove(assinatura);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Erro ao remover assinatura da base de dados.", ex);
            }
        }

        /// <summary>
        /// Editar dados da assinatura na base de dados
        /// </summary>
        /// <param name="assinatura">dados da assinatura a ser atualizada</param>
        /// <exception cref="ArgumentNullException">Quando assinatura é null</exception>
        /// <exception cref="InvalidOperationException">Quando assinatura não é encontrada</exception>
        public void Edit(Assinatura assinatura)
        {
            if (assinatura == null)
                throw new ArgumentNullException(nameof(assinatura));

            var assinaturaExistente = context.Assinaturas.Find(assinatura.Id);
            if (assinaturaExistente == null)
                throw new InvalidOperationException($"Assinatura com ID {assinatura.Id} não encontrada.");

            try
            {
                context.Entry(assinaturaExistente).CurrentValues.SetValues(assinatura);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Erro ao atualizar assinatura na base de dados.", ex);
            }
        }

        /// <summary>
        /// Buscar uma assinatura na base de dados
        /// </summary>
        /// <param name="id">id da assinatura</param>
        /// <returns>dados da assinatura ou null se não encontrada</returns>
        public Assinatura? Get(uint id)
        {
            return context.Assinaturas.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// Buscar todas as assinaturas cadastradas
        /// </summary>
        /// <returns>lista de assinaturas</returns>
        public IEnumerable<Assinatura> GetAll()
        {
            return context.Assinaturas.AsNoTracking().ToList();
        }
    }
}
