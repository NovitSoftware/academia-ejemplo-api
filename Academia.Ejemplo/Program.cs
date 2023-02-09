using Academia.Ejemplo.Middleware;
using Academia.Ejemplo.Persistence;
using Academia.Ejemplo.Persistence.Repositories;
using Academia.Ejemplo.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuracion CORS mediante politica
builder.Services.AddCors(options => 
    options.AddPolicy("Novit", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

//configuracion de la base de datos
string connectionString = builder.Configuration.GetConnectionString("AcademiaEjemplo");

builder.Services.AddDbContext<AplicacionDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<DbContext, AplicacionDbContext>();

builder.Services.AddTransient<JugadorRepository>();
builder.Services.AddTransient<AldeanoRepository>();
builder.Services.AddTransient<EdificioRepository>();

builder.Services.AddTransient<JugadorService>();
builder.Services.AddTransient<AldeanoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//implementacion CORS
app.UseCors("Novit");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Use(async (context, next) =>
//{
//    app.Logger.LogInformation($"Method: {context.Request.Method}, URL: {context.Request.GetDisplayUrl()}");
//    await next.Invoke();
//    app.Logger.LogInformation($"Status code: {context.Response.StatusCode}, Content-Type: {context.Response.ContentType}");
//});

//app.UseMiddleware<LoggerJuegoMiddleware>();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/Edificio"), appBuilder =>
{
    appBuilder.UseMiddleware<LoggerJuegoMiddleware>();
});

app.Run();
