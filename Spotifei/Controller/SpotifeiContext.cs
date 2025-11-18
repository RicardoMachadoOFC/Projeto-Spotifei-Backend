using Microsoft.EntityFrameworkCore;
using Spotifei.Model;
class SpotifeiContext : DbContext
{
    private string stringConexao = 
        "Server=localhost;Port=3306;Database=SpotifeiDB;Uid=root;Pwd=xrtornado";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Album> Albuns { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<PlaylistMusica> PlaylistsMusicas { get; set; }
    public DbSet<Historico> Historicos { get; set; }
    public DbSet<Conteudo> Conteudos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Historicos)
            .WithOne(h => h.Usuario)
            .HasForeignKey(h => h.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

     
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Playlists)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Artista>()
            .HasMany(a => a.Albuns)
            .WithOne(al => al.Artista)
            .HasForeignKey(al => al.ArtistaId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Album>()
            .HasMany(a => a.Musicas)
            .WithOne(m => m.Album)
            .HasForeignKey(m => m.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<PlaylistMusica>()
            .HasKey(pm => new { pm.PlaylistId, pm.MusicaId });

        modelBuilder.Entity<PlaylistMusica>()
            .HasOne(pm => pm.Playlist)
            .WithMany(p => p.PlaylistsMusicas)
            .HasForeignKey(pm => pm.PlaylistId);

        modelBuilder.Entity<PlaylistMusica>()
            .HasOne(pm => pm.Musica)
            .WithMany(m => m.PlaylistsMusicas)
            .HasForeignKey(pm => pm.MusicaId);

        modelBuilder.Entity<Conteudo>()
            .HasMany(c => c.Historicos) // Conteudo tem muitos Historicos
            .WithOne(h => h.Conteudo)  // Historico tem um Conteudo
            .HasForeignKey(h => h.ConteudoId) // Chave estrangeira em Historico
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Email).IsRequired();

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Nome).IsRequired();

        modelBuilder.Entity<Artista>()
            .Property(a => a.Nome).IsRequired();

        modelBuilder.Entity<Album>()
            .Property(a => a.Titulo).IsRequired();

        modelBuilder.Entity<Musica>()
            .Property(m => m.Titulo).IsRequired();
    }
}
