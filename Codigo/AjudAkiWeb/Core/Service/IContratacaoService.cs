using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IContratacaoService
    {
        uint Create(Contratacao contratacao);
        void Edit(Contratacao contratacao);
        void Delete(uint id);
        Contratacao? Get(uint id);
        IEnumerable<Contratacao> GetAll();
    }
}
