using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Identity;

namespace AjudAkiWeb.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UsuarioIdentity class
public class UsuarioIdentity : IdentityUser
{
    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string? Telefone { get; set; }

    public DateTime DataNascimento { get; set; }

    public string Cep { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string NumResidencia { get; set; } = null!;

    public string? PontoReferencia { get; set; }

    public string TipoPessoa { get; set; } = null!;

    public uint IdAssinatura { get; set; }

    public virtual ICollection<Contratacao> Contratacaos { get; set; } = new List<Contratacao>();

    public virtual Assinatura IdAssinaturaNavigation { get; set; } = null!;

    public virtual ICollection<Pagamentoassinatura> Pagamentoassinaturas { get; set; } = new List<Pagamentoassinatura>();

    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();

    public virtual ICollection<Solicitacaoservico> SolicitacaoservicoIdClienteNavigations { get; set; } = new List<Solicitacaoservico>();

    public virtual ICollection<Solicitacaoservico> SolicitacaoservicoIdProfissionalNavigations { get; set; } = new List<Solicitacaoservico>();

    public virtual ICollection<Agendum> IdAgenda { get; set; } = new List<Agendum>();
}

