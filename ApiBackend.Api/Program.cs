using ApiBackend.Application.Interfaces;
using ApiBackend.Application.Services;
using ApiBackend.Core.Interfaces;
using ApiBackend.Infrastructure.Persistence.Contexts;
using ApiBackend.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//CONFIGURACIÓN DE SERVICIOS (Dependency Injection)

//Controladores de la API
builder.Services.AddControllers();

//Explorador de endpoints para Swagger
builder.Services.AddEndpointsApiExplorer();

//Documentación Swagger/OpenAPI
builder.Services.AddSwaggerGen();

//Configuración del DbContext con cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDConnection")));

//Servicios de aplicación
builder.Services.AddScoped<IPedidoService, PedidoService>();

//Repositorios
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// Clientes HTTP para APIs externas
// builder.Services.AddHttpClient<INotificacionApi, NotificacionApi>();

// Configurar autenticación/autorización (JWT, OAuth, etc.)
// builder.Services.AddAuthentication(...);
// builder.Services.AddAuthorization(...);

// Validadores con FluentValidation
// builder.Services.AddValidatorsFromAssemblyContaining<AddPedidoDtoValidator>();

// Configurar logging estructurado (ej. Serilog)
// builder.Host.UseSerilog((context, config) => { ... });

// Manejo global de excepciones
// builder.Services.AddTransient<ExceptionMiddleware>();
// app.UseMiddleware<ExceptionMiddleware>();

var app = builder.Build();

//CONFIGURACIÓN DEL PIPELINE HTTP

if (app.Environment.IsDevelopment())
{
    //Swagger solo en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Redirección HTTPS
app.UseHttpsRedirection();

//Autenticación (si la configuras)
app.UseAuthentication();

//Autorización
app.UseAuthorization();

//Mapeo de rutas de controladores
app.MapControllers();

//Inicio de la aplicación
app.Run();
