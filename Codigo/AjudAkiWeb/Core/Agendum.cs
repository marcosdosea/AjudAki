﻿using System;
using System.Collections.Generic;

namespace Core;

public partial class Agendum
{
    public uint Id { get; set; }

    public DateTime Data { get; set; }

    public string Turno { get; set; } = null!;

    public bool TurnoOcupado { get; set; }

    public bool DiaOcupado { get; set; }

    public virtual ICollection<Tiposervico> Tiposervicos { get; set; } = new List<Tiposervico>();

    public virtual ICollection<Pessoa> IdPessoas { get; set; } = new List<Pessoa>();
}
