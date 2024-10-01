using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAvaliarService
    {
        uint Create(Avaliacao avaliar);

        void Delete(uint id);

        IEnumerable<Avaliacao> GetAll();
    }
}
