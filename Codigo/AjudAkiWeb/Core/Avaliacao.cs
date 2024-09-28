using System;
using System.Collections.Generic;

namespace Core;

public partial class Avaliacao
{
    public uint Id { get; set; }

    public bool NotaServico { get; set; }

    public bool NotaProfissional { get; set; }

    public uint Status { get; set; }

    public string? Comentario { get; set; }

    public uint IdContratacao { get; set; }

    public virtual Contratacao IdContratacaoNavigation { get; set; } = null!;
}
