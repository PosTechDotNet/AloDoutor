using AloDoutor.Api.Configuration;
using Identidade.API.Configuration;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSerilogConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddApiConfig(builder.Configuration);

var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        IdentityConfig.CreateUserDefault(services);
    }
    catch (Exception ex)
    {
        // Lide com erros, registre-os ou tome medidas apropriadas.
    }
}*/

// Configure the HTTP request pipeline.
app.UseSwaggerConfiguration();

app.UseApiConfigurationAsync(app.Environment);

app.Run();
