using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnionStarAPI.Models
{
    public class Interesado
    {
        [Key]
        public string IdInteresado { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public DateTime FechaContacto { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Direccion { get; set; }

        public int Estado { get; set; }
        
    }
}
