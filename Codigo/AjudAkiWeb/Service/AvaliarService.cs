using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
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
        /// Remover a avaliacao do profissional da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(uint id)
        {
            var avaliar = context.Avaliacaos.Find(id);
            if (avaliar != null)
            {
                context.Remove(avaliar);
                context.SaveChanges();
            }
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
