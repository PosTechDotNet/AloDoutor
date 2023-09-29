using AloDoutor.Entity;
using AloDoutor.Interface;
using AloDoutor.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<Paciente> ,EFRepository<Paciente>>();
builder.Services.AddScoped<IRepository<Medico>, EFRepository<Medico>>();
builder.Services.AddScoped<IRepository<EspecialidadeMedico>, EFRepository<EspecialidadeMedico>>();
builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
