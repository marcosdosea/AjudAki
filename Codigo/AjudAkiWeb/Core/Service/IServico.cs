using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace Core.Service
{
    public interface IServico
    {
        uint Create(Servico servico);

        void Edit(Servico servico);

        void Delete(uint idServico);

        Pessoa? Get(uint idServico);

        IEnumerable<Servico> GetAll();
        Servico? Get(uint id);
    }
}
