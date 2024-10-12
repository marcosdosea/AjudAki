
namespace Core.Service
{
    public interface ISolicitacaoServicoService
    {
        uint Create(Solicitacaoservico solicitacaoServico);
        void Edit(Solicitacaoservico solicitacaoServico);
        void Delete(uint id);
        Solicitacaoservico? Get(uint id);
        IEnumerable<Solicitacaoservico> GetAll();
        IEnumerable<Solicitacaoservico> GetByNome(string nome);

    }
}
