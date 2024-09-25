using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAssinaturaService
    {
        uint Create(Assinatura assinatura);

        void Edit(Assinatura assinatura); 

        void Delete(uint id);

        Assinatura? Get(uint id);

        IEnumerable<Assinatura> GetAll();

    }
}
