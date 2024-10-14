using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    /// <summary>
    /// Implementa serviços para manter area de atuação
    /// </summary>
    public class AreaAtuacaoService : IAreaAtuacaoService
    {

        private readonly AjudakiContext context;
        public AreaAtuacaoService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria uma nova área de atuação na base de dados
        /// </summary>
        /// <param name="areaAtuacao">Nome da área</param>
        /// <returns>id da área de atuação</returns>
        public uint Create(Areaatuacao areaAtuacao)
        {
            context.Add(areaAtuacao);
            context.SaveChanges();

            return areaAtuacao.Id;
        }

        /// <summary>
        /// Remove a área de atuação da base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var areaAtuacao = context.Areaatuacaos.Find(id);
            if (areaAtuacao != null)
            {
                context.Remove(areaAtuacao);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edita a área de atuação
        /// </summary>
        /// <param name="areaAtuacao"></param>
        public void Edit(Areaatuacao areaAtuacao)
        {
            context.Update(areaAtuacao);
            context.SaveChanges();
        }

        /// <summary>
        /// Busca uma área de atuação
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Área de atuação</returns>
        public Areaatuacao? Get(uint id)
        {
            return context.Areaatuacaos.Find(id);
        }

        /// <summary>
        /// Busca as áreas de atuação
        /// </summary>
        /// <returns>Lista de Áreas de atuação</returns>
        public IEnumerable<Areaatuacao> GetAll()
        {
            return context.Areaatuacaos.AsNoTracking();
        }
    }
}
