using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ITipoServicoService
    {
        uint Create(Tiposervico tiposervico);

        void Edit(Tiposervico tiposervico);

        void Delete(uint id);

        Tiposervico? Get(uint id);

        IEnumerable<Tiposervico> GetAll();
    }
}
