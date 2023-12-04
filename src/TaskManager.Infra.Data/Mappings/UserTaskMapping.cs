using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Mappings;

public class UserTaskMapping : IEntityTypeConfiguration<UserTask>
{
    public void Configure(EntityTypeBuilder<UserTask> builder)
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
    }
}
