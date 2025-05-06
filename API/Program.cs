using Microsoft.EntityFrameworkCore;
using PagosCQRSDDD.Infrastructure.Persistence;
using PagosCQRSDDD.Application.Commands;
using PagosCQRSDDD.Domain.Interfaces;
using PagosCQRSDDD.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pagos API CQRS-DDD", Version = "v1" });
});


builder.Services.AddDbContext<PagosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPagoRepository, PagoRepository>();
builder.Services.AddScoped<PagarCommandHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pagos API CQRS-DDD v1"));
}

app.MapControllers();
app.Run();

