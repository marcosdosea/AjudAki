
namespace Core.Service
{
    public interface IAreaAtuacaoService
    {
        uint Create(Areaatuacao areaatuacao);
        void Edit(Areaatuacao areaatuacao);
        void Delete(uint id);
        Areaatuacao? Get(uint id);
        IEnumerable<Areaatuacao> GetAll();


    }
}
