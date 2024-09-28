using System;
using System.Collections.Generic;

namespace Core;

public partial class Pagamentoassinatura
{
    public uint Id { get; set; }

    public DateTime DataPagamento { get; set; }

    public string NomePlano { get; set; } = null!;

    public string Status { get; set; } = null!;

    public uint IdProfissional { get; set; }

    public uint IdAssinatura { get; set; }

    public virtual Assinatura IdAssinaturaNavigation { get; set; } = null!;

    public virtual Pessoa IdProfissionalNavigation { get; set; } = null!;
}
