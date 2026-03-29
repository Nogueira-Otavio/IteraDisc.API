using System.Text;
using IteraDisc.Aplicacao;
using IteraDisc.Aplicacao.Interfaces;
using IteraDisc.Api.Services;
using IteraDisc.Repositorio;
using IteraDisc.Repositorio.Contexto;
using IteraDisc.Repositorio.Interfaces;
using IteraDisc.Servicos.GroqService;
using IteraDisc.Servicos.GroqService.Interfaces;
using IteraDisc.Servicos.GroqService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.Local.json", optional: true, reloadOnChange: true);

// Groq
builder.Services.Configure<GroqSettings>(builder.Configuration.GetSection("GroqSettings"));

// Aplicação
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IProdutoAplicao, ProdutoAplicaco>();
builder.Services.AddScoped<IItemVendaAplicacao, ItemVendaAplicacao>();
builder.Services.AddScoped<IVendaAplicacao, VendaAplicacao>();
builder.Services.AddScoped<IGroqServiceAplicacao, GroqServiceAplicacao>();

// Repositórios
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IITemVendaRepositorio, ItemVendaRepositorio>();
builder.Services.AddScoped<IVendaRepositorio, VendaRepositorio>();

// Serviços
builder.Services.AddHttpClient<IGroqService, GroqService>();
builder.Services.AddScoped<TokenService>();

// JWT Authentication
var jwtKey = builder.Configuration["Jwt:SecretKey"];
var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<IteraDiscContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication(); // <-- ANTES do UseAuthorization
app.UseAuthorization();
app.MapControllers();
app.Run();