using System;
using System.Collections.Generic;

namespace Core;

public partial class Assinatura
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Status { get; set; }

    public float? Valor { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Pagamentoassinatura> Pagamentoassinaturas { get; set; } = new List<Pagamentoassinatura>();

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
}
