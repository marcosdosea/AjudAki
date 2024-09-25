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
    class ServicoService : IServico
    {
        private readonly AjudakiContext context;

        public ServicoService(AjudakiContext context)
        {
            this.context = context;
        }

        // <summary>
        // Criar um novo serviço na base de dados
        // </summary>
        // <param name="servico"></param>
        // <returns></returns>
        public uint Create(Pessoa servico)
        {
            context.Add(servico);
            context.SaveChanges();
            return servico.Id;
        }

        // <summary>
        // Remover o serviço da base de dados
        // </summary>
        // <param name="idServico"></param>
        public void Delete(uint idServico)
        {
            var servico = context.Servicos.Find(idServico);
            if (servico != null)
            {
                context.Remove(servico);
                context.SaveChanges();
            }
        }

        // <summary>
        // Editar dados do serviço na base de dados
        // </summary>
        // <param name="servico"></param>
        public void Edit(Pessoa servico)
        {
            context.Update(servico);   
            context.SaveChanges();
        }

        // <summary>
        // Buscar um serviço na base de dados
        // </summary>
        // <param name="idServico"></param>
        // <returns></returns>
        public Servico? Get(uint idServico)
        {
            return context.Servicos.Find(idServico);
        }

        // <summary>
        // Buscar todos os serviços cadastrados
        // </summary>
        //<param name = "idServico" ></ param >
        // <returns>Oferta de Serviços</returns>
        // <exception cref="NotImplementedException"></exception>
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

