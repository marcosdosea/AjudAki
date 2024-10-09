using Core;
using Core.Dto;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviços para manter dados do cliente
    /// </summary>
    public class ClienteService : IClienteService
    {
        private readonly AjudakiContext context;

        public ClienteService(AjudakiContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Criar um novo Cliente na base de dados
        /// </summary>
        /// <param name="cliente">dados do cliente</param>
        /// <returns>id do cliente</returns>
        public uint Create(Pessoa cliente)
        {
            context.Add(cliente);
            context.SaveChanges();
            return cliente.Id;
        }

        /// <summary>
        /// Remover o cliente da base de dados
        /// </summary>
        /// <param name="id">id do cliente</param>
        public void Delete(uint id)
        {
            var cliente = context.Pessoas.Find(id);
            if (cliente != null)
            {
                context.Remove(cliente);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edita dados do cliente na base de dados
        /// </summary>
        /// <param name="cliente"></param>
        public void Edit(Pessoa cliente)
        {
            context.Update(cliente);
            context.SaveChanges();
        }

        /// <summary>
        /// Busca um cliente na base de dados
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns>dados do cliente</returns>
        public Pessoa? Get(uint id)
        {
            return context.Pessoas.Find(id);
        }

        /// <summary>
        /// Buscar todos os clientes cadastrados
        /// </summary>
        /// <returns>lista de clientes</returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }

        /// <summary>
        /// Buscar clientes iniciando com o nome
        /// </summary>
        /// <param name="nome">nome do cliente</param>
        /// <returns>lista de clientes que inicia com o nome</returns>
        public IEnumerable<ClienteDTO> GetByNome(string nome)
        {
            var query = from cliente in context.Pessoas
                        where cliente.Nome.StartsWith(nome)
                        orderby cliente.Nome
                        select new ClienteDTO
                        {
                            Id = cliente.Id,
                            Nome = cliente.Nome
                        };
            return query.AsNoTracking().ToList();
        }
    }
}
