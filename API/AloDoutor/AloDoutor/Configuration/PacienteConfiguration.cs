using AloDoutor.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AloDoutor.Configuration;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Paciente");
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
        builder.Property(u => u.Idade)
            .HasColumnType("INT");
        builder.Property(u => u.Telefone)
            .HasColumnType("INT");
    }
}
