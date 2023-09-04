using Exercicio1.Models; // Importa las clases de modelos
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Data
{
    public class APIContext : DbContext
    {
        private readonly IConfiguration configuration;

        // Constructor que recibe opciones de contexto y configuración
        public APIContext(DbContextOptions<APIContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // DbSet para las entidades Articulo y Fabricante
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        // Método para configurar relaciones y restricciones en el modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la relación uno a muchos entre Articulo y Fabricante
            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.Fabricante)
                .WithMany(f => f.Articulos)
                .HasForeignKey(a => a.FabricanteCodigo);
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
