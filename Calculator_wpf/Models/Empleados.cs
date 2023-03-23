using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator_wpf.Models
{
    [Table("EstaEsLaTabla", Schema = "EsteEsquema")]
    public class Empleados
    {
        public int  Id { get; set; }
        public string? nombre { get; set; }
    }
}
