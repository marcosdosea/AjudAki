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
    class Servico : IServico
    {
        private readonly AjudakiContext context;

        public Servico(AjudakiContext context)
        {
            this.context = context;
        }

        // <summary>
        // Criar um novo serviço na base de dados
        // </summary>
        // <param name="profissional"></param>
        // <returns></returns>
        public uint Create(Pessoa profissional)
        {
            context.Add(profissional);
            context.SaveChanges();
            return profissional.Id;
        }

        // <summary>
        // Remover o serviço da base de dados
        // </summary>
        // <param name="id"></param>
        public void Delete(uint id)
        {
            var profissional = context.Pessoas.Find(id);
            if (profissional != null)
            {
                context.Remove(profissional);
                context.SaveChanges();
            }
        }

        // <summary>
        // Editar dados do serviço na base de dados
        // </summary>
        // <param name="profissional"></param>
        public void Edit(Pessoa profissional)
        {
            context.Update(profissional);   
            context.SaveChanges();
        }

        // <summary>
        // Buscar um serviço na base de dados
        // </summary>
        // <param name="id"></param>
        // <returns></returns>
        public Pessoa? Get(uint id)
        {
            return context.Pessoas.Find(id);
        }

        // <summary>
        // Buscar todos os serviços cadastrados
        // </summary>
        // <returns></returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return context.Pessoas.AsNoTracking();
        }
    }
}

