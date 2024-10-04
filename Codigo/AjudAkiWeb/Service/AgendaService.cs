
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AgendaService : IAgendaService
    {
        private readonly AjudakiContext context;
        public AgendaService(AjudakiContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria uma nova agenda na base de dados
        /// </summary>
        /// <param name="agenda"></param>
        /// <returns>id da nova agenda</returns>
        /// <exception cref="NotImplementedException"></exception>
        public uint Create(Agendum agenda)
        {
            context.Add(agenda);
            context.SaveChanges();

            return agenda.Id;
        }

        /// <summary>
        /// Remove a agenda da base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(uint id)
        {
            var agenda = context.Agenda.Find(id);
            if (agenda != null)
            {
                context.Remove(agenda);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edita a agenda na base de dados
        /// </summary>
        /// <param name="agenda"></param>
        public void Edit(Agendum agenda)
        {
            context.Update(agenda);
            context.SaveChanges();
        }

        /// <summary>
        /// Busca uma agenda na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dados da agenda caso não seja igual a null</returns>
        public Agendum? Get(uint id)
        {
            return context.Agenda.Find(id);
        }

        /// <summary>
        /// Busca todas as agendas cadastradas na base de dados
        /// </summary>
        /// <returns>Lista de agendas</returns>
        public IEnumerable<Agendum> GetAll()
        {
            return context.Agenda.AsNoTracking();
        }
    }
}
