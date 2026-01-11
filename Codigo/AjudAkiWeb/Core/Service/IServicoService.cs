using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace Core.Service
{
    public interface IServicoService
    {
        uint Create(Servico servico);

        void Edit(Servico servico);

        void Delete(uint id);

        Servico? Get(uint id);

        IEnumerable<Servico> GetAll();

        IEnumerable<Servico> BuscarPorFiltro(uint? idTipoServico, uint? idAreaAtuacao, uint? idProfissional);

        // Busca serviços por termo (nome do serviço, nome do tipo de serviço ou nome do profissional)
        IEnumerable<Servico> Buscar(string? termo, uint? idTipoServico, uint? idAreaAtuacao, uint? idProfissional);
    }
}
