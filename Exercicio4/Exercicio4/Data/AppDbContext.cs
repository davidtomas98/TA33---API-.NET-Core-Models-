using Exercicio4.Models; // Importa las clases de modelos
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        // Constructor que recibe opciones de contexto y configuración
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // DbSet para las entidades Articulo y Fabricante
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        // Método para configurar relaciones y restricciones en el modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sala>()
                .HasOne(s => s.Pelicula)
                .WithMany(p => p.Salas)
                .HasForeignKey(s => s.PeliculaCodigo);
        }

        // Método para configurar opciones de conexión a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Obtiene la cadena de conexión de la configuración
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

            // Configura el uso de MySQL con la cadena de conexión y versión del servidor
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
