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
    }
}
