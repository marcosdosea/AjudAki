using System;
using System.Collections.Generic;

namespace Core;
    
public partial class Servico
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime Data { get; set; }

    public uint IdTipoServico { get; set; }

    public uint IdAreaAtuacao { get; set; }

    public uint IdProfissional { get; set; }

    public virtual ICollection<Contratacao> Contratacaos { get; set; } = new List<Contratacao>();

    public virtual Areaatuacao IdAreaAtuacaoNavigation { get; set; } = null!;

    public virtual Pessoa IdProfissionalNavigation { get; set; } = null!;

    public virtual Tiposervico IdTipoServicoNavigation { get; set; } = null!;
}
