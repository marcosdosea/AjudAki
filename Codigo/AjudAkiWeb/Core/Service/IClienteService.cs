using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IClienteService
    {
        uint Create(Pessoa cliente);

        void Edit(Pessoa cliente);

        void Delete(uint idCliente);

        Pessoa? Get(uint idCliente);

        IEnumerable<Pessoa> GetAll();
    }
}
