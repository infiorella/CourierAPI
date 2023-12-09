using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnionStarAPI.Models
{
    public class Personal
    {
        [Key]
        public string IdPersonal { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string FechaNacimiento { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Rol { get; set; }
        public int Estado { get; set; }
    }
}
