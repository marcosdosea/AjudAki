using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviços para manter avaliação
    /// </summary>
    public class AvaliarService : IAvaliarService
    {
        private readonly AjudakiContext context;
        public AvaliarService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar um novo avaliar profissional na base de dados
        /// </summary>
        /// <param name="avaliar"></param>
        /// <returns>id do avalair profissional</returns>
        /// <exception cref="NotImplementedException"></exception>
        public uint Create(Avaliacao avaliar)
        {
            context.Add(avaliar);
            context.SaveChanges();
            return avaliar.Id;
        }

        /// <summary>
        /// Busca uma Avaliar profissional
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Avaliar profissional</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Avaliacao? Get(uint id)
        {
            return context.Avaliacaos.Find(id);
        }

        /// <summary>
        /// Buscar todas as  avaliacao de profissionais cadastradas
        /// </summary>
        /// <returns>lista de avaliar profissional</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Avaliacao> GetAll()
        {
            return context.Avaliacaos.AsNoTracking();
        }
    }
}
