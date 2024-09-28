using System;
using System.Collections.Generic;

namespace Core;

public partial class Solicitacaoservico
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataHoraSolicitacao { get; set; }

    public string Status { get; set; } = null!;

    public float? Valor { get; set; }

    public string? Descricao { get; set; }

    public uint IdCliente { get; set; }

    public uint IdProfissional { get; set; }

    public uint IdTipoServico { get; set; }

    public virtual Pessoa IdClienteNavigation { get; set; } = null!;

    public virtual Pessoa IdProfissionalNavigation { get; set; } = null!;

    public virtual Tiposervico IdTipoServicoNavigation { get; set; } = null!;
}
