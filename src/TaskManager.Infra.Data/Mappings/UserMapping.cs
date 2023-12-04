using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.DataCriacao)
            .IsRequired();

        builder.Property(x => x.DataUltimaAtualizacao);

        builder.Property(x => x.DataUltimoLogin);

        builder.Property(x => x.Ativo)
            .IsRequired();

        builder.Property(x => x.Excluido)
            .IsRequired();

        builder.HasMany(x => x.Projetos)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId);
    }
}
