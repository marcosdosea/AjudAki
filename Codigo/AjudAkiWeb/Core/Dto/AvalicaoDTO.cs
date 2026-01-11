using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class AvalicaoDTO
    {
        public uint Id { get; set; }

        public sbyte NotaServico { get; set; }

        public String NomeStatus { get; set; }

        public sbyte NotaProfissional { get; set; }
    }
}
