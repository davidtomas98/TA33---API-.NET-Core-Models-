using Exercicio3.Models; // Importa las clases de modelos
using Microsoft.EntityFrameworkCore;

namespace Exercicio3.Data
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
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Caja> Cajas { get; set; }

        // Método para configurar relaciones y restricciones en el modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>()
                .HasMany(a => a.Cajas)
                .WithOne(c => c.Almacen)
                .HasForeignKey(c => c.AlmacenCodigo);
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
