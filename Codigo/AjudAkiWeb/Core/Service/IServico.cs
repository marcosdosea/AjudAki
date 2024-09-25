using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace Core.Service
{
    public interface IServico
    {
        uint Create(Pessoa servico);

        void Edit(Pessoa servico);

        void Delete(uint idServico);

        Pessoa? Get(uint idServico);

        IEnumerable<Servico> GetAll();

    }
}
