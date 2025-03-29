using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NutriAppBackEnd.Data;
using NutriAppBackEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexión a la base de datos
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin() // Permitir cualquier origen
            .AllowAnyMethod() // Permitir cualquier método (GET, POST, etc.)
            .AllowAnyHeader()); // Permitir cualquier encabezado
});

// Agregar servicios de controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API del proyecto",
        Version = "v1.0",
        Description = "Documentación de API para Proyecto de clase"
    });
});

// Agregar servicios personalizados
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ConsultaService>();

var app = builder.Build();

// Usar CORS antes de la autorización y el mapeo de controladores
app.UseCors("AllowAll");

// Configurar el middleware de autorización
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

// Configurar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API del proyecto v1");
    c.RoutePrefix = string.Empty; // Esto hace que Swagger UI esté disponible en la raíz
});

// Ejecutar la aplicación
app.Run();