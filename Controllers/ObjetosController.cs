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
    public class ObjetosController : Controller
    {
        private readonly UnionStarContext _db;

        public ObjetosController(UnionStarContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Objeto>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetObjetos()
        {
            var lista = await _db.Objeto.OrderBy(i => i.IdObjeto).ToListAsync();
            return Ok(lista);
        }


        [HttpGet("id/{id}", Name = "GetObjeto")]
        [ProducesResponseType(200, Type = typeof(Objeto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetObjeto(string id)
        {
            var obj = await _db.Objeto.FirstOrDefaultAsync(i => i.IdObjeto.Equals(id));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("interesado/{id}", Name = "GetObjetoByInteresado")]
        [ProducesResponseType(200, Type = typeof(Objeto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetObjetoByInteresado(string id)
        {
            var obj = await _db.Objeto.FirstOrDefaultAsync(i => i.IdInteresado.Equals(id));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("estado/{estado}", Name = "GetObjetoByStatus")]
        [ProducesResponseType(200, Type = typeof(Objeto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetObjetoByStatus(string estado)
        {
            var obj = await _db.Objeto.FirstOrDefaultAsync(i => i.Estado.Equals(estado));
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
        public async Task<IActionResult> PostObjeto([FromBody] Objeto objeto)
        {
            if (objeto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(objeto);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetObjeto", new { id = objeto.IdObjeto }, objeto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjeto(string id)
        {
            var obj = await _db.Objeto.FirstOrDefaultAsync(i => i.IdObjeto.Equals(id));
            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                obj.status = 0;
            }

            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarObjetos(string id, [FromBody] Objeto objeto)
        {
            if (objeto.IdObjeto != id)
            {
                return BadRequest();
            }
            _db.Entry(objeto).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Ok();

        }
    }

    public enum Estado
    {
        Completado,
        Pendiente,
        Enviado,
        Recibido
    }
}
