using Core.Dto;
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

        void Delete(uint id);

        Pessoa? Get(uint id);

        IEnumerable<Pessoa> GetAll();

        IEnumerable<ClienteDTO> GetByNome(string nome);
    }
}
