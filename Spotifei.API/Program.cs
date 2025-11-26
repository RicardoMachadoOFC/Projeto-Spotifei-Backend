using Microsoft.EntityFrameworkCore;
using Spotifei.Model;
using Spotifei.Controller;
using Spotifei.DAO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpotifeiContext>();
builder.Services.AddScoped<UsuarioDAO>();
builder.Services.AddScoped<PlaylistDAO>();
builder.Services.AddScoped<UsuarioController>();
builder.Services.AddScoped<LoginController>();
builder.Services.AddScoped<PlaylistController>();

var app = builder.Build();

app.MapGet("/", () => "Spotifei API rodando!");

app.MapGet("/usuarios", (UsuarioController controller) => controller.Listar());
app.MapPost("/usuarios", (UsuarioController controller, Usuario u) =>
{
    controller.Cadastrar(u);
    return Results.Ok(u);
});

app.MapPost("/login", (LoginController login, string email, string senha) =>
{
    bool ok = login.Autenticar(email, senha);
    return ok ? Results.Ok("Login OK") : Results.Unauthorized();
});

app.MapGet("/usuarios/{usuarioId}/playlists", (PlaylistController controller, int usuarioId) =>
{
    return controller.Listar(usuarioId);
});

app.MapPost("/usuarios/{usuarioId}/playlists", (PlaylistController controller, int usuarioId, Playlist p) =>
{
    p.UsuarioId = usuarioId;
    controller.Cadastrar(p);
    return Results.Ok(p);
});

app.MapPost("/playlists/{playlistId}/musicas/{musicaId}", (PlaylistController controller, int playlistId, int musicaId) =>
{
    controller.AdicionarMusica(playlistId, musicaId);
    return Results.Ok();
});

app.Run();
