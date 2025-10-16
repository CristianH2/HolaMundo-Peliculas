using Microsoft.EntityFrameworkCore;
using Peliculas.Entities;

namespace Peliculas.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<MovieEntity> Movie { get; set; }

        public AppDbContext()
        {
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PeliculasDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
