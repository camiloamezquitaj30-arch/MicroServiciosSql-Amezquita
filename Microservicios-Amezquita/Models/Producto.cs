using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservicios_Amezquita.Models
{
    public class Producto
    {

        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los caracteres")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage ="El precio no puede ser negativo")]
        [Column  (TypeName ="decimal(18,2)")]

        public decimal Price { get; set; }
        public Categoria? Category { get; set; }

    }
}
