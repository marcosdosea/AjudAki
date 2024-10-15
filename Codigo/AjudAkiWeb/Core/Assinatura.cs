using System;
using System.Collections.Generic;

namespace Core;

public partial class Assinatura
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Status { get; set; } = null!;

    public decimal? Valor { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Pagamentoassinatura> Pagamentoassinaturas { get; set; } = new List<Pagamentoassinatura>();

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
}
