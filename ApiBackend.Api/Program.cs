using ApiBackend.Application.Interfaces;
using ApiBackend.Application.Services;
using ApiBackend.Core.Interfaces;
using ApiBackend.Infrastructure.Persistence.Contexts;
using ApiBackend.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//CONFIGURACI�N DE SERVICIOS (Dependency Injection)

//Controladores de la API
builder.Services.AddControllers();

//Explorador de endpoints para Swagger
builder.Services.AddEndpointsApiExplorer();

//Documentaci�n Swagger/OpenAPI
builder.Services.AddSwaggerGen();

//Configuraci�n del DbContext con cadena de conexi�n
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDConnection")));

//Servicios de aplicaci�n
builder.Services.AddScoped<IPedidoService, PedidoService>();

//Repositorios
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// Clientes HTTP para APIs externas
// builder.Services.AddHttpClient<INotificacionApi, NotificacionApi>();

// Configurar autenticaci�n/autorizaci�n (JWT, OAuth, etc.)
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

//CONFIGURACI�N DEL PIPELINE HTTP

if (app.Environment.IsDevelopment())
{
    //Swagger solo en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Redirecci�n HTTPS
app.UseHttpsRedirection();

//Autenticaci�n (si la configuras)
app.UseAuthentication();

//Autorizaci�n
app.UseAuthorization();

//Mapeo de rutas de controladores
app.MapControllers();

//Inicio de la aplicaci�n
app.Run();
