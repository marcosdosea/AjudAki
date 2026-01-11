using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAvaliarService
    {
        uint Create(Avaliacao avaliar);
        Avaliacao? Get(uint id);
        IEnumerable<Avaliacao> GetAll();
        IEnumerable<AvalicaoDTO> ObterPorNomeOrdemdescrecente (uint id);
    }
}
