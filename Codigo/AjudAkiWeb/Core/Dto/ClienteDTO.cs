using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class ClienteDTO
    {
        public uint Id { get; set; }

        public string Nome { get; set; } = null!;

        public string TipoPessoa { get; set; } = null!;

        public string? NomeAssinatura { get; set; }
    }
}
