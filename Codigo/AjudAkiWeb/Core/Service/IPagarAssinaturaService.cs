using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPagarAssinaturaService
    {
        uint Create(Pagamentoassinatura pagamentoAssinatura);

        void Edit(Pagamentoassinatura pagamentoaAssinatura);

        void Delete(uint id);

        Pagamentoassinatura? Get(uint id);

        IEnumerable<Pagamentoassinatura> GetAll();
    }
}
