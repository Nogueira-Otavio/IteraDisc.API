using IteraDisc.Aplicacao;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Repositorio;
using IteraDisc.Repositorio.Contexto;
using IteraDisc.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IProdutoAplicao, ProdutoAplicaco>();
builder.Services.AddScoped<IItemVendaAplicacao, ItemVendaAplicacao>();

// Add database interfaces
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IITemVendaRepositorio, ItemVendaRepositorio>();

// Add services

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
