using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnionStarAPI.Models
{
    public class Servicio
    {
        [Key]
        public string IdServicio { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string DetalleTitulo { get; set; }
        [Required]
        public string DetalleDescripcion { get; set; }
        public string Encargado { get; set; }

        public int Estado { get; set; }
    }
}
