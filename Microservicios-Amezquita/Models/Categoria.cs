using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Timers;

namespace Microservicios_Amezquita.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [MaxLength (100, ErrorMessage ="El nombre no puede superar los caracteres")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los caracteres")]
        public string Description {  get; set; }

        [JsonIgnore]
        public ICollection <Producto> Productos { get; set; } = new List<Producto> ();
    }
}
