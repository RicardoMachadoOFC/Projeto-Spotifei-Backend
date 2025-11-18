var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


var usuarios = app.MapGroup("/usuarios");


usuarios.MapGet("", () =>
{
    return new UsuarioController().Listar();
});


usuarios.MapPost("", ([FromBody] Usuario usuario) =>
{
    new UsuarioController().Cadastrar(usuario);
    return Results.Ok(usuario);
});

usuarios.MapPut("", ([FromBody] Usuario usuario) =>
{
    new UsuarioController().Atualizar(usuario);
    return Results.Ok(usuario);
});


usuarios.MapDelete("{id:int}", (int id) =>
{
    var controller = new UsuarioController();
    var usuario = controller.Buscar(id);

    if (usuario == null)
        return Results.NotFound("Usuário não encontrado");

    controller.Excluir(id);
    return Results.Ok("Usuário removido");
});


app.MapPost("/login", (string email, string senha) =>
{
    bool ok = new LoginController().Autenticar(email, senha);

    if (ok)
        return Results.Ok(new { mensagem = "Login OK" });

    return Results.Unauthorized();
});

app.Run();