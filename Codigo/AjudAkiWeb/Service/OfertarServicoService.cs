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
        // <param name="servico"></param>
        // <returns></returns>
        public uint Create(Servico servico)
        {
            context.Add(servico);
            context.SaveChanges();
            return servico.Id;
        }

        // <summary>
        // Remover o serviço da base de dados
        // </summary>
        // <param name="id"></param>
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
        // <param name="servico"></param>


        public void Edit(Servico servico)
        {
            context.Update(servico);
            context.SaveChanges();
        }

        // <summary>
        // Buscar um serviço na base de dados
        // </summary>
        // <param name="id"></param>
        // <returns></returns>
        public Servico? Get(uint id)
        {
            return context.Servicos.Find(id);
        }

        // <summary>
        // Buscar todos os serviços cadastrados
        // </summary>
        //<param name = "id" ></ param >
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

