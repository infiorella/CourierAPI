using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnionStarAPI.Data;
using UnionStarAPI.Models;

namespace UnionStarAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CotizacionesController : Controller
    {
        private readonly UnionStarContext _db;

        public CotizacionesController(UnionStarContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Cotizacion>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCotizaciones()
        {
            var lista = await _db.Cotizacion.OrderBy(i => i.FechaEmision).ToListAsync();
            return Ok(lista);
        }


        [HttpGet("id/{id}", Name = "GetCotizacion")]
        [ProducesResponseType(200, Type = typeof(Cotizacion))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetCotizacion(string id)
        {
            var obj = await _db.Cotizacion.FirstOrDefaultAsync(i => i.IdCotizacion.Equals(id));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("fecha/{fechaEmision}", Name = "GetCotizacionByDate")]
        [ProducesResponseType(200, Type = typeof(Cotizacion))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetCotizacionByDate(DateTime fechaEmision)
        {
            var obj = await _db.Cotizacion.FirstOrDefaultAsync(i => i.FechaEmision.ToString("u").Equals(fechaEmision));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]  //Error Interno
        public async Task<IActionResult> PostCotizacion([FromBody] Cotizacion cotizacion)
        {
            if (cotizacion == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(cotizacion);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetCotizacion", new { id = cotizacion.IdCotizacion }, cotizacion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotizacion(string id)
        {
            var obj = await _db.Cotizacion.FirstOrDefaultAsync(i => i.IdCotizacion.Equals(id));
            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                obj.Estado = 0;
            }

            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCotizacion(string id, [FromBody] Cotizacion cotizacion)
        {
            if (cotizacion.IdCotizacion != id)
            {
                return BadRequest();
            }
            _db.Entry(cotizacion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Ok();

        }

    }

    
}
