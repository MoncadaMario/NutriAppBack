using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NutriAppBackEnd.Data;
using NutriAppBackEnd.Services;

var builder = WebApplication.CreateBuilder(args);

//Configurar conexion a DB 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API del proyecto",
        Version = "v1.0",
        Description = "Documentacion de API para Proyecto de clase"
    });
}
    );

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ConsultaService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.Run();