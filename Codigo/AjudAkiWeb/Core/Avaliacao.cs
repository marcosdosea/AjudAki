using System;
using System.Collections.Generic;

namespace Core;

public partial class Avaliacao
{
    public int Id { get; set; }

    public bool NotaServico { get; set; }

    public bool NotaProfissional { get; set; }

    public int Status { get; set; }

    public string? Comentario { get; set; }

    public int IdContratacao { get; set; }

    public virtual Contratacao IdContratacaoNavigation { get; set; } = null!;
}
