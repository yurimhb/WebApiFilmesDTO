using FilmesApi.Model;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> dbContextOptions) : base (dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Endereco>()
                .HasOne(x => x.Cinema)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Cinema>(c => c.EnderecoId);

            modelBuilder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId);

            modelBuilder.Entity<Sessao>()
                .HasOne(se => se.Cinema)
                .WithMany(ci => ci.Sessoes)
                .HasForeignKey(se => se.CinemaId);

            modelBuilder.Entity<Sessao>()
                .HasOne(se => se.Filme)
                .WithMany(fi => fi.Sessoes)
                .HasForeignKey(se => se.FilmeId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Gerente> Gerentes { get; set; }

        public DbSet<Sessao> Sessoes { get; set; }
    }
}
