using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tienda_comics.Data_Entities
{
    [Table("catalogo")]
    public class CatalogoEntity
    {
        [Key]
        [Column("id_catalogo")]
        public String Id { get; set; } = String.Empty;
        [Column("descripcion")]
        public String descripcion { get; set; } = String.Empty;
    }
}
