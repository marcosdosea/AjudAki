using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="idCliente">id do cliente</param>
        public void Delete(uint idCliente)
        {
            var cliente = context.Pessoas.Find(idCliente);
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
        /// <param name="idCliente">id do cliente</param>
        /// <returns>dados do cliente</returns>
        public Pessoa? Get(uint idCliente)
        {
            return context.Pessoas.Find(idCliente);
        }

        /// <summary>
        /// Buscar todos os clientes cadastrados
        /// </summary>
        /// <returns>lista de clientes</returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }
    }
}
