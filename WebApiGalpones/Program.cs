using Abstraciones.Repositorios;
using MediatR;
using Negocios.Comandos;
using Negocios.Procesos;
using Repotorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddScoped(typeof(IVerificateLogin), typeof(VerificateLogin));
builder.Services.AddScoped(typeof(IVentaRepository), typeof(VentaRepository));
builder.Services.AddScoped(typeof(IDatabaseConectionFactory), typeof(DatabaseConnectionFactory));
builder.Services.AddScoped<IRequestHandler<LoginCommand, LoginResponse>, LoginHandler>();
builder.Services.AddScoped<IRequestHandler<VentaCommand, VentaCommandResponse>, VentaHandler>();
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
