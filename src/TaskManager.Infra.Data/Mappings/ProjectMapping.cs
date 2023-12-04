﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Mappings;

public class ProjectMapping : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(x => x.DataCriacao)
            .IsRequired();

        builder.Property(x => x.DataUltimaAtualizacao);

        builder.Property(x => x.Ativo)
            .IsRequired();

        builder.Property(x => x.Excluido)
            .IsRequired();

        builder.HasMany(x => x.Tarefas)
            .WithOne(x => x.Projeto)
            .HasForeignKey(x => x.ProjetoId);
    }
}