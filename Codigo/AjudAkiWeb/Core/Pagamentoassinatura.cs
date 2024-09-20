using System;
using System.Collections.Generic;

namespace Core;

public partial class Pagamentoassinatura
{
    public int Id { get; set; }

    public DateTime DataPagamento { get; set; }

    public string NomePlano { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int IdProfissional { get; set; }

    public int IdAssinatura { get; set; }

    public virtual Assinatura IdAssinaturaNavigation { get; set; } = null!;

    public virtual Pessoa IdProfissionalNavigation { get; set; } = null!;
}
