using System;
using System.Collections.Generic;

namespace Core;

public partial class Agendum
{
    public int Id { get; set; }

    public DateTime Data { get; set; }

    public string Turno { get; set; } = null!;

    public sbyte TurnoOcupado { get; set; }

    public sbyte DiaOcupado { get; set; }

    public virtual ICollection<Tiposervico> Tiposervicos { get; set; } = new List<Tiposervico>();

    public virtual ICollection<Pessoa> IdProfissionals { get; set; } = new List<Pessoa>();
}
