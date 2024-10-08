﻿using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IProfissionalService
    {
        uint Create(Pessoa profissional);

        void Edit(Pessoa profissional);

        void Delete(uint id);

        Pessoa? Get(uint id);

        IEnumerable<Pessoa> GetAll();

        IEnumerable<Pessoa> GetByNome(string nome);

    }
}
