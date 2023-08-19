using System.ComponentModel.DataAnnotations;

namespace tienda_comics.Data_Entities
{
    public class CatalogoEntity
    {
        [Key] 
        public int idCatalogo { get; set; }
        public String descripcion { get; set; } = String.Empty;
    }
}
