using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviços para contratar serviço
    /// </summary>
    public class ContratacaoService : IContratacaoService
    {
        private readonly AjudakiContext context;

        public ContratacaoService(AjudakiContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Criar uma nova contratação na base de dados
        /// </summary>
        /// <param name="contratacao">dados da contratação</param>
        /// <returns>id da contratação</returns>
        public uint Create(Contratacao contratacao)
        {
            context.Add(contratacao);
            context.SaveChanges();
            return contratacao.Id;
        }

        /// <summary>
        /// Remover a contratação da base de dados
        /// </summary>
        /// <param name="id">id da contratação</param>
        public void Delete(uint id)
        {
            var contratacao = context.Contratacaos.Find(id);
            if (contratacao != null)
            {
                context.Remove(contratacao);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados da contratação na base de dados
        /// </summary>
        /// <param name="contratacao"></param>
        public void Edit(Contratacao contratacao)
        {
            context.Update(contratacao);
            context.SaveChanges();
        }

        /// <summary>
        /// Buscar uma contratação na base de dados
        /// </summary>
        /// <param name="id">id contratação</param>
        /// <returns>dados da contratação</returns>
        public Contratacao? Get(uint id)
        {
            return context.Contratacaos.Find(id);
        }

        /// <summary>
        /// Buscar todos as contratações cadastradas
        /// </summary>
        /// <returns>lista de contratações</returns>
        public IEnumerable<Contratacao> GetAll()
        {
            return context.Contratacaos.AsNoTracking();
        }
    }
}
