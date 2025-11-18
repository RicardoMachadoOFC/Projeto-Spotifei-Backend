using Microsoft.EntityFrameworkCore;
using Spotifei.Model;
using Spotifei.Controller;
using Spotifei.DAO;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpotifeiContext>();
builder.Services.AddScoped<UsuarioDAO>();
builder.Services.AddScoped<UsuarioController>();
builder.Services.AddScoped<LoginController>();

var app = builder.Build();

app.MapGet("/", () => "Spotifei API rodando!");

// lista
app.MapGet("/usuarios", (UsuarioController controller) =>
{
    return controller.Listar();
});

// cadastro
app.MapPost("/usuarios", (UsuarioController controller, Usuario u) =>
{
    controller.Cadastrar(u);
    return Results.Ok(u);
});

// login
app.MapPost("/login", (LoginController login, string email, string senha) =>
{
    bool ok = login.Autenticar(email, senha);
    return ok ? Results.Ok("Login OK") : Results.Unauthorized();
});

app.Run();
