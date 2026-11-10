using System.Text.Json.Serialization;   // Ya está puesto: lo usa el HUECO 1
using TiendaApi.Options;
using TiendaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ===== HUECO 1 · Enums como texto =====
// Reemplaza la línea de abajo por:
//   builder.Services.AddControllers()
//       .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddControllers();

builder.Services.AddOptions<TiendaOptions>()
    .Bind(builder.Configuration.GetSection(TiendaOptions.Seccion))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton<IProductoRepository, ProductoRepositoryMemoria>();
builder.Services.AddScoped<IContextoSolicitud, ContextoSolicitud>();

var app = builder.Build();

app.MapControllers();
app.Run();
