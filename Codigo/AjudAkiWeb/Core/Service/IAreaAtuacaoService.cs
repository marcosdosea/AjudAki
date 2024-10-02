
namespace Core.Service
{
    public interface IAreaAtuacaoService
    {
        uint Create(Areaatuacao areaAtuacao);
        void Edit(Areaatuacao areaAtuacao);
        void Delete(uint id);
        Areaatuacao? Get(uint id);
        IEnumerable<Areaatuacao> GetAll();


    }
}
