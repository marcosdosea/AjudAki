using System;
using System.Collections.Generic;

namespace Core;

public partial class Avaliacao
{
    public uint Id { get; set; }

    public sbyte NotaServico { get; set; }

    public sbyte NotaProfissional { get; set; }

    public int Status { get; set; }

    public string? Comentario { get; set; }

    public uint IdContratacao { get; set; }

    public virtual Contratacao IdContratacaoNavigation { get; set; } = null!;
}
