using AloDoutor.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AloDoutor.Configuration;

public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("Medico");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("INT")
            .UseIdentityColumn();
        builder.Property(u => u.Nome)
            .HasColumnType("VARCHAR(50)");
        builder.Property(u => u.Cpf)
            .HasColumnType("INT")
            .IsRequired();
        builder.Property(u => u.Cep)
            .HasColumnType("INT");
        builder.Property(u => u.Endereco)
            .HasColumnType("VARCHAR(100)");
        builder.Property(u => u.Estado)
            .HasColumnType("VARCHAR(20)");
        builder.Property(u => u.Crm)
            .HasColumnType("INT")
            .IsRequired();
        builder.Property(u => u.Telefone)
            .HasColumnType("INT");
        builder.HasOne(u => u.Especialidade)
            .WithMany()
            .HasForeignKey(u => u.EspecialidadeId); 
    }
}
