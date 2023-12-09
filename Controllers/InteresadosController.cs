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
    public class InteresadosController : Controller
    {
        private readonly UnionStarContext _db;

        public InteresadosController(UnionStarContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Interesado>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetInteresados()
        {
            var lista = await _db.Interesado.OrderBy(i => i.Nombre).ToListAsync();
            return Ok(lista);
        }


        [HttpGet("id/{id}", Name = "GetInteresado")]
        [ProducesResponseType(200, Type = typeof(Interesado))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetInteresado(string id)
        {
            var obj = await _db.Interesado.FirstOrDefaultAsync(i => i.IdInteresado.Equals(id));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("email/{email}", Name = "GetInteresadoByEmail")]
        [ProducesResponseType(200, Type = typeof(Interesado))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetInteresadoByEmail(string email)
        {
            var obj = await _db.Interesado.FirstOrDefaultAsync(i => i.Email.Equals(email));
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
        public async Task<IActionResult> PostInteresado([FromBody] Interesado interesado)
        {
            if (interesado == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(interesado);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetInteresado", new { id = interesado.IdInteresado }, interesado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInteresado(string id)
        {
            var obj = await _db.Interesado.FirstOrDefaultAsync(i => i.IdInteresado.Equals(id));
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

        [HttpPut("{id}", Name = "ActualizarInteresado")]
        public async Task<IActionResult> ActualizarInteresado(string id, [FromBody]Interesado interesado)
        {
            if (interesado.IdInteresado != id)
            {
                return BadRequest();
            }
            _db.Entry(interesado).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Ok();

        }
    }
}
