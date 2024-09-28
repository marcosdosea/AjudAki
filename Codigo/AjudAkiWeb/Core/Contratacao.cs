using System;
using System.Collections.Generic;

namespace Core;

public partial class Contratacao
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime Data { get; set; }

    public string Cep { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string NumResidencia { get; set; } = null!;

    public string? PontoReferencia { get; set; }

    public string Status { get; set; } = null!;

    public uint IdServico { get; set; }

    public uint IdCliente { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual Pessoa IdClienteNavigation { get; set; } = null!;

    public virtual Servico IdServicoNavigation { get; set; } = null!;
}
