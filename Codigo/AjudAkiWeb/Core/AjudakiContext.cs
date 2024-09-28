using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class AjudakiContext : DbContext
{

    public AjudakiContext()
    {
    }

    public AjudakiContext(DbContextOptions<AjudakiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendum> Agenda { get; set; }

    public virtual DbSet<Areaatuacao> Areaatuacaos { get; set; }

    public virtual DbSet<Assinatura> Assinaturas { get; set; }

    public virtual DbSet<Avaliacao> Avaliacaos { get; set; }

    public virtual DbSet<Contratacao> Contratacaos { get; set; }

    public virtual DbSet<Pagamentoassinatura> Pagamentoassinaturas { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Solicitacaoservico> Solicitacaoservicos { get; set; }

    public virtual DbSet<Tiposervico> Tiposervicos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("agenda");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.DiaOcupado).HasColumnName("diaOcupado");
            entity.Property(e => e.Turno)
                .HasColumnType("enum('MANHÃ','TARDE','NOITE')")
                .HasColumnName("turno");
            entity.Property(e => e.TurnoOcupado).HasColumnName("turnoOcupado");
        });

        modelBuilder.Entity<Areaatuacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("areaatuacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Assinatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assinatura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .HasColumnName("nome");
            entity.Property(e => e.Status)
                .HasColumnType("enum('ATIVA','INATIVA')")
                .HasColumnName("status");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("avaliacao");

            entity.HasIndex(e => e.IdContratacao, "fk_Avaliacao_Contratacao1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario)
                .HasMaxLength(100)
                .HasColumnName("comentario");
            entity.Property(e => e.IdContratacao).HasColumnName("idContratacao");
            entity.Property(e => e.NotaProfissional).HasColumnName("notaProfissional");
            entity.Property(e => e.NotaServico).HasColumnName("notaServico");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdContratacaoNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.IdContratacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Avaliacao_Contratacao1");
        });

        modelBuilder.Entity<Contratacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contratacao");

            entity.HasIndex(e => e.IdCliente, "fk_Contratacao_Pessoa1_idx");

            entity.HasIndex(e => e.IdServico, "fk_Contratacao_Servico1_idx");

            entity.HasIndex(e => e.Nome, "nome_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdServico).HasColumnName("idServico");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.NumResidencia)
                .HasMaxLength(10)
                .HasColumnName("numResidencia");
            entity.Property(e => e.PontoReferencia)
                .HasMaxLength(40)
                .HasColumnName("pontoReferencia");
            entity.Property(e => e.Rua)
                .HasMaxLength(40)
                .HasColumnName("rua");
            entity.Property(e => e.Status)
                .HasColumnType("enum('RECUSADO','ACEITO','PENDENTE','FINALIZADO')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Contratacaos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Contratacao_Pessoa1");

            entity.HasOne(d => d.IdServicoNavigation).WithMany(p => p.Contratacaos)
                .HasForeignKey(d => d.IdServico)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Contratacao_Servico1");
        });

        modelBuilder.Entity<Pagamentoassinatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pagamentoassinatura");

            entity.HasIndex(e => e.IdAssinatura, "fk_PagamentoAssinatura_Assinatura1_idx");

            entity.HasIndex(e => e.IdProfissional, "fk_PagamentoAssinatura_Pessoa1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataPagamento)
                .HasColumnType("datetime")
                .HasColumnName("dataPagamento");
            entity.Property(e => e.IdAssinatura).HasColumnName("idAssinatura");
            entity.Property(e => e.IdProfissional).HasColumnName("idProfissional");
            entity.Property(e => e.NomePlano)
                .HasMaxLength(50)
                .HasColumnName("nomePlano");
            entity.Property(e => e.Status)
                .HasColumnType("enum('ATIVO','ATRASADO','PAGO')")
                .HasColumnName("status");

            entity.HasOne(d => d.IdAssinaturaNavigation).WithMany(p => p.Pagamentoassinaturas)
                .HasForeignKey(d => d.IdAssinatura)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PagamentoAssinatura_Assinatura1");

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.Pagamentoassinaturas)
                .HasForeignKey(d => d.IdProfissional)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_PagamentoAssinatura_Pessoa1");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Cep, "cep_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Cpf, "cpf_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdAssinatura, "fk_Pessoa_Assinatura1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Celular)
                .HasMaxLength(11)
                .HasColumnName("celular");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .HasColumnName("cep");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("date")
                .HasColumnName("dataNascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.IdAssinatura).HasColumnName("idAssinatura");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.NumResidencia)
                .HasMaxLength(10)
                .HasColumnName("numResidencia");
            entity.Property(e => e.PontoReferencia)
                .HasMaxLength(40)
                .HasColumnName("pontoReferencia");
            entity.Property(e => e.Rua)
                .HasMaxLength(40)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .HasColumnName("telefone");
            entity.Property(e => e.TipoPessoa)
                .HasColumnType("enum('CLIENTE','PROFISSIONAL','ADMINISTRADOR')")
                .HasColumnName("tipoPessoa");

            entity.HasOne(d => d.IdAssinaturaNavigation).WithMany(p => p.Pessoas)
                .HasForeignKey(d => d.IdAssinatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pessoa_Assinatura1");

            entity.HasMany(d => d.IdAgenda).WithMany(p => p.IdProfissionals)
                .UsingEntity<Dictionary<string, object>>(
                    "Pessoaagendum",
                    r => r.HasOne<Agendum>().WithMany()
                        .HasForeignKey("IdAgenda")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_Pessoa_has_Agenda_Agenda1"),
                    l => l.HasOne<Pessoa>().WithMany()
                        .HasForeignKey("IdProfissional")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_Pessoa_has_Agenda_Pessoa1"),
                    j =>
                    {
                        j.HasKey("IdProfissional", "IdAgenda").HasName("PRIMARY");
                        j.ToTable("pessoaagenda");
                        j.HasIndex(new[] { "IdAgenda" }, "fk_Pessoa_has_Agenda_Agenda1_idx");
                        j.HasIndex(new[] { "IdProfissional" }, "fk_Pessoa_has_Agenda_Pessoa1_idx");
                        j.IndexerProperty<uint>("IdProfissional").HasColumnName("idProfissional");
                        j.IndexerProperty<uint>("IdAgenda").HasColumnName("idAgenda");
                    });
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("servico");

            entity.HasIndex(e => e.IdAreaAtuacao, "fk_Servico_AreasAtuacao1_idx");

            entity.HasIndex(e => e.IdProfissional, "fk_Servico_Pessoa1_idx");

            entity.HasIndex(e => e.IdTipoServico, "fk_Servico_TiposServico1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdAreaAtuacao).HasColumnName("idAreaAtuacao");
            entity.Property(e => e.IdProfissional).HasColumnName("idProfissional");
            entity.Property(e => e.IdTipoServico).HasColumnName("idTipoServico");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdAreaAtuacaoNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdAreaAtuacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Servico_AreasAtuacao1");

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdProfissional)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Servico_Pessoa1");

            entity.HasOne(d => d.IdTipoServicoNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdTipoServico)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Servico_TiposServico1");
        });

        modelBuilder.Entity<Solicitacaoservico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solicitacaoservico");

            entity.HasIndex(e => e.IdCliente, "fk_SolicitacoesServico_Pessoa1_idx");

            entity.HasIndex(e => e.IdProfissional, "fk_SolicitacoesServico_Pessoa2_idx");

            entity.HasIndex(e => e.IdTipoServico, "fk_SolicitacoesServico_TiposServico1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHoraSolicitacao)
                .HasColumnType("datetime")
                .HasColumnName("dataHoraSolicitacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(300)
                .HasColumnName("descricao");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdProfissional).HasColumnName("idProfissional");
            entity.Property(e => e.IdTipoServico).HasColumnName("idTipoServico");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Status)
                .HasColumnType("enum('RECUSADO','ACEITO','PENDENTE','FINALIZADO')")
                .HasColumnName("status");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.SolicitacaoservicoIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_SolicitacoesServico_Pessoa1");

            entity.HasOne(d => d.IdProfissionalNavigation).WithMany(p => p.SolicitacaoservicoIdProfissionalNavigations)
                .HasForeignKey(d => d.IdProfissional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SolicitacoesServico_Pessoa2");

            entity.HasOne(d => d.IdTipoServicoNavigation).WithMany(p => p.Solicitacaoservicos)
                .HasForeignKey(d => d.IdTipoServico)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_SolicitacoesServico_TiposServico1");
        });

        modelBuilder.Entity<Tiposervico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tiposervico");

            entity.HasIndex(e => e.IdAgenda, "fk_TiposServico_Agenda1_idx");

            entity.HasIndex(e => e.IdAreaAtuacao, "fk_TiposServico_AreasAtuacao1_idx");

            entity.HasIndex(e => e.Nome, "nome_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAgenda).HasColumnName("idAgenda");
            entity.Property(e => e.IdAreaAtuacao).HasColumnName("idAreaAtuacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdAgendaNavigation).WithMany(p => p.Tiposervicos)
                .HasForeignKey(d => d.IdAgenda)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_TiposServico_Agenda1");

            entity.HasOne(d => d.IdAreaAtuacaoNavigation).WithMany(p => p.Tiposervicos)
                .HasForeignKey(d => d.IdAreaAtuacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_TiposServico_AreasAtuacao1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
