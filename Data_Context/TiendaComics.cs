using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tienda_comics.Data_Entities;

namespace tienda_comics.Data_Context
{
    public class TiendaComics : DbContext
    {
        private readonly ILogger<TiendaComics> _logger;

        public TiendaComics(DbContextOptions<TiendaComics> options, ILogger<TiendaComics> logger) : base(options)
        {
            this._logger = logger;
            _logger.LogDebug("El contexto de base de datos TiendaComics.cs ha sido cargado");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        #region dbset
        public DbSet<CatalogoEntity> Catalogos { get; set;}
        #endregion
    }
}
