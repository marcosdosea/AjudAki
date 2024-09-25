using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
