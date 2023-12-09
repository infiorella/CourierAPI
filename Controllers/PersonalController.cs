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
    public class PersonalController : Controller
    {
        private readonly UnionStarContext _db;

        public PersonalController(UnionStarContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Personal>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPersonal()
        {
            var lista = await _db.Personal.OrderBy(i => i.Nombres).ToListAsync();
            return Ok(lista);
        }


        [HttpGet("id/{id}", Name = "GetPersonalById")]
        [ProducesResponseType(200, Type = typeof(Personal))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetPersonalById(string id)
        {
            var obj = await _db.Personal.FirstOrDefaultAsync(i => i.IdPersonal.Equals(id));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }


        [HttpGet("area/{area}", Name = "GetPersonalByArea")]
        [ProducesResponseType(200, Type = typeof(Personal))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetPersonalByArea(string area)
        {
            var obj = await _db.Personal.FirstOrDefaultAsync(i => i.Area.Equals(area));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("email/{email}", Name = "GetPersonalByEmail")]
        [ProducesResponseType(200, Type = typeof(Personal))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //No encontrado
        public async Task<IActionResult> GetPersonalByEmail(string email)
        {
            var obj = await _db.Personal.FirstOrDefaultAsync(i => i.Email.Equals(email));
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }


    }
}
