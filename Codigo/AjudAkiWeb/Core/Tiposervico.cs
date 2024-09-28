using System;
using System.Collections.Generic;

namespace Core;

public partial class Tiposervico
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public uint IdAgenda { get; set; }

    public uint IdAreaAtuacao { get; set; }

    public virtual Agendum IdAgendaNavigation { get; set; } = null!;

    public virtual Areaatuacao IdAreaAtuacaoNavigation { get; set; } = null!;

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();

    public virtual ICollection<Solicitacaoservico> Solicitacaoservicos { get; set; } = new List<Solicitacaoservico>();
}
