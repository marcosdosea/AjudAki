using System;
using System.Collections.Generic;

namespace Core;

public partial class Tiposervico
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int IdAgenda { get; set; }

    public int IdAreaAtuacao { get; set; }

    public virtual Agendum IdAgendaNavigation { get; set; } = null!;

    public virtual Areaatuacao IdAreaAtuacaoNavigation { get; set; } = null!;

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();

    public virtual ICollection<Solicitacaoservico> Solicitacaoservicos { get; set; } = new List<Solicitacaoservico>();
}
