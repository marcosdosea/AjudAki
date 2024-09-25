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
    class OfertarServicoService : IServico
    {
        private readonly AjudakiContext context;

        public OfertarServicoService(AjudakiContext context)
        {
            this.context = context;
        }

        // <summary>
        // Criar um novo serviço na base de dados
        // </summary>
        // <param name="servico">Objeto do serviço a ser criado.</param>
        // <returns>Id do serviço recém-criado.</returns>
        public uint Create(Servico servico)
        {
            context.Add(servico);
            context.SaveChanges();
            return servico.Id;
        }

        // <summary>
        // Remover o serviço da base de dados
        // </summary>
        // <param name="id">Id do serviço a ser removido.</param>
        // <returns>Void. Nenhum valor é retornado.</returns>
        public void Delete(uint id)
        {
            var servico = context.Servicos.Find(id);
            if (servico != null)
            {
                context.Remove(servico);
                context.SaveChanges();
            }
        }

        // <summary>
        // Editar dados do serviço na base de dados
        // </summary>
        // <param name="servico">Objeto do serviço com os novos dados.</param>
        // <returns>Void. Nenhum valor é retornado.</returns>
        public void Edit(Servico servico)
        {
            context.Update(servico);
            context.SaveChanges();
        }

        // <summary>
        // Buscar um serviço na base de dados
        // </summary>
        // <param name="id">Id do serviço a ser buscado.</param>
        // <returns>Objeto do serviço encontrado ou null, caso não exista.</returns>
        public Servico? Get(uint id)
        {
            return context.Servicos.Find(id);
        }

        // <summary>
        // Buscar todos os serviços cadastrados
        // </summary>
        // <returns>Coleção de serviços cadastrados.</returns>
        public IEnumerable<Servico> GetAll()
        {
            return context.Servicos.AsNoTracking();
        }

        Pessoa? IServico.Get(uint idServico)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Servico> IServico.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

