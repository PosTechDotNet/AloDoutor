using AloDoutor.Entity;
using Microsoft.EntityFrameworkCore;

namespace AloDoutor.Repository;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<Paciente> Paciente { get; set; }
    public DbSet<Medico> Medico { get; set; }
    public DbSet<EspecialidadeMedico> EspecialidadeMedico { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration
            .GetValue<string>("ConnectionStrings:ConnectionString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
