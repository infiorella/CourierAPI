using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnionStarAPI.Models
{
    public class Cotizacion
    {
        [Key]
        public string IdCotizacion { get; set; }
        [Required]
        public string Concepto { get; set; }
        [Required]
        public Decimal Importe { get; set; }
        [Required]
        public string ModoPago { get; set; }
        [Required]
        public string IdInteresado { get; set; }
        [Required]
        public string IdObjeto { get; set; }
        [Required]
        public DateTime FechaEmision { get; set; }
        [Required]
        public DateTime PlazoEntrega { get; set; }
        public string CondicionesEntrega { get; set; }
        public string Comentarios { get; set; }
        public string EmpresaTitulo { get; set; }
        public string EmpresaDireccion { get; set; }
        [Required]
        public string IdPersonal { get; set; }
        [Required]
        public string IdServicio { get; set; }
        public int Estado { get; set; }
    }
}
