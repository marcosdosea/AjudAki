using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviços para manter tipos de serviço.
    /// </summary>
    public class TipoServicoService : ITipoServicoService
    {
        private readonly AjudakiContext context;

        public TipoServicoService(AjudakiContext context)
        {
            this.context = context;
        }

        // <summary>
        // Criar um novo tipo de serviço na base de dados
        // </summary>
        // <param name="tiposervico">Tipo de Serviço</param>
        // <returns>Id do tipo do serviço criado.</returns>
        public uint Create(Tiposervico tipoServico)
        {
            context.Add(tipoServico);
            context.SaveChanges();
            return tipoServico.Id;
        }

        // <summary>
        // Remover o tipo de serviço da base de dados
        // </summary>
        // <param name="id">Id do tipo de serviço a ser removido.</param>
        public void Delete(uint id)
        {
            var tipoServico = context.Tiposervicos.Find(id);
            if (tipoServico != null)
            {
                context.Remove(tipoServico);
                context.SaveChanges();
            }
        }

        // <summary>
        // Editar dados do tipo de serviço na base de dados
        // </summary>
        // <param name="tiposervico">Objeto do tipo de serviço com os novos dados.</param>
        public void Edit(Tiposervico tipoServico)
        {
            context.Update(tipoServico);
            context.SaveChanges();
        }

        // <summary>
        // Buscar um  tipo de serviço na base de dados
        // </summary>
        // <param name="id">Id do tipo de serviço a ser buscado.</param>
        // <returns>Objeto do tipo de serviço encontrado ou null, caso não exista.</returns>
        public Tiposervico? Get(uint id)
        {
            return context.Tiposervicos.Find(id);
        }

        // <summary>
        // Buscar todos os tipos de serviços cadastrados
        // </summary>
        // <returns>Coleção dos tipos de serviços cadastrados.</returns>
        public IEnumerable<Tiposervico> GetAll()
        {
            return context.Tiposervicos.AsNoTracking();
        }
    }
}
