using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tienda_comics.Data_Entities;

namespace tienda_comics.Data_Context
{
    public class TiendaComics : DbContext
    {
        public TiendaComics()
        {
            
        }

        public TiendaComics(DbContextOptions<TiendaComics> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region dbset
        public virtual DbSet<CatalogoEntity> Catalogos { get; set;}
        #endregion
    }
}
