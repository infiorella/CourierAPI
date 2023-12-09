using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnionStarAPI.Models
{
    public class Objeto
    {
        [Key]
        public string IdObjeto { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public string IdInteresado { get; set; }
        [Required]
        public string IdServicio { get; set; }
        [Required]
        public Decimal Peso { get; set; }
        [Required]
        public string LugarEnvio { get; set; }
        [Required]
        public string LugarLlegada { get; set; }
        [Required]
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaEspecificadaEntrega { get; set; }
        [Required]
        public string Estado { get; set; }
        public int status { get; set; }

    }
}
