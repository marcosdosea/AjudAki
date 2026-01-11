using Core;
using Core.Dto;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa Serviços para manter avaliação
    /// </summary>
    public class AvaliarService : IAvaliarService
    {
        private readonly AjudakiContext context;
        private char nome;

        public AvaliarService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar uma nova avaliacao para o profissional
        /// </summary>
        /// <param name="avaliar"></param>
        /// <returns>id do avaliar profissional</returns>
        /// <exception cref="NotImplementedException"></exception>
        public uint Create(Avaliacao avaliar)
        {
            context.Add(avaliar);
            context.SaveChanges();
            return avaliar.Id;
        }

        /// <summary>
        /// Busca uma Avaliacao profissional
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Avaliacao profissional</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Avaliacao? Get(uint id)
        {
            return context.Avaliacaos.Find(id);
        }

        /// <summary>
        /// Buscar todas as  avaliacao de profissionais cadastradas
        /// </summary>
        /// <returns>lista de avaliacoes de profissionais</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Avaliacao> GetAll()
        {
            return context.Avaliacaos.AsNoTracking();
        }

        /// <summary>
        /// Buscar status iniciando com o nome
        /// </summary>
        /// <param name="nome">nome do status</param>
        /// <returns>lista de status que inicia com o nome</returns>
        public IEnumerable<AvalicaoDTO> ObterPorNomeOrdemdescrecente(uint id)
        {
            var query = from status in context.Pessoas
                        where status.Nome.StartsWith(nome)
                        orderby status.Nome
                        select new ClienteDTO
                        {
                            Id = status.Id,
                            Nome = status.Nome
                        };
            return (IEnumerable<AvalicaoDTO>)query.AsNoTracking().ToList();
        }
    }
}
