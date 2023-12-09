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
    [ApiController]
    [Route("[controller]")]
    public class ServiciosController : Controller
    {
        private readonly UnionStarContext _db;

        public ServiciosController(UnionStarContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Servicio>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetServicios()
        {
            var lista = await _db.Servicio.OrderBy(i => i.IdServicio).ToListAsync();
            return Ok(lista);
        }


        [HttpGet("id/{id}", Name = "GetServicio")]
        [ProducesResponseType(200, Type = typeof(Servicio))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetServicio(string id)
        {
            var obj = await _db.Servicio.FirstOrDefaultAsync(i => i.IdServicio.Equals(id));
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
        public async Task<IActionResult> PostServicio([FromBody] Servicio servicio)
        {
            if (servicio == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(servicio);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetServicio", new { id = servicio.IdServicio}, servicio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(string id)
        {
            var obj = await _db.Servicio.FirstOrDefaultAsync(i => i.IdServicio.Equals(id));
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
        public async Task<IActionResult> ActualizarServicio(string id, [FromBody] Servicio servicio)
        {
            if (servicio.IdServicio != id)
            {
                return BadRequest();
            }
            _db.Entry(servicio).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Ok();

        }

        [HttpGet("tipo/{tipo}", Name = "GetServicioByTipo")]
        [ProducesResponseType(200, Type = typeof(Servicio))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetServicioByTipo(string tipo)
        {
            var obj = await _db.Servicio.FirstOrDefaultAsync(i => i.Tipo.Equals(tipo));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
    }

}
