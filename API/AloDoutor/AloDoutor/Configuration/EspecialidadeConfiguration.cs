using AloDoutor.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AloDoutor.Configuration;

public class EspecialidadeConfiguration : IEntityTypeConfiguration<EspecialidadeMedico>
{
    public void Configure(EntityTypeBuilder<EspecialidadeMedico> builder)
    {
        builder.ToTable("Especialidade");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("INT")
            .UseIdentityColumn();
        builder.Property(u => u.EspecialidadeId)
            .HasColumnType("INT");
        builder.Property(u => u.EspecialidadeNome)
            .HasColumnType("VARCHAR(50)");
    }
}
