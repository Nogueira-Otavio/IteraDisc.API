using IteraDisc.Aplicacao;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Repositorio;
using IteraDisc.Repositorio.Contexto;
using IteraDisc.Repositorio.Interfaces;
using IteraDisc.Servicos.GroqService;
using IteraDisc.Servicos.GroqService.Interfaces;
using IteraDisc.Servicos.GroqService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.Local.json", optional: true, reloadOnChange: true);

builder.Services.Configure<GroqSettings>(
    builder.Configuration.GetSection("GroqSettings"));

// Add services to the container.
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IProdutoAplicao, ProdutoAplicaco>();
builder.Services.AddScoped<IItemVendaAplicacao, ItemVendaAplicacao>();
builder.Services.AddScoped<IVendaAplicacao, VendaAplicacao>();
builder.Services.AddScoped<IGroqServiceAplicacao, GroqServiceAplicacao>();

// Add database interfaces
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IITemVendaRepositorio, ItemVendaRepositorio>();
builder.Services.AddScoped<IVendaRepositorio, VendaRepositorio>();

// Add services
builder.Services.AddHttpClient<IGroqService, GroqService>();

builder.Services.AddControllers();

// Add database services
builder.Services.AddDbContext<IteraDiscContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
