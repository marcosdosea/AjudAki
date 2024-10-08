using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    internal class PagarAssinaturaDTO
    {
        public uint Id { get; set; }

        public DateTime DataPagamento { get; set; }

        public string NomePlano { get; set; } = null!;
    }
}
