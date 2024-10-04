namespace Core.Service
{
    public interface IAgendaService
    {
        uint Create(Agendum agenda);

        void Edit(Agendum agenda);

        void Delete(uint id);

        Agendum? Get(uint id);

        IEnumerable<Agendum> GetAll();
    }
}
