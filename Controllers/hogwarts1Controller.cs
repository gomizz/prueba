using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using howarts1.Models;

namespace howarts1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hogwarts1Controller : ControllerBase
    {
        private readonly UsuariosCTX _context;

        public hogwarts1Controller(UsuariosCTX context)
        {
            _context = context;
        }

        // GET: api/hogwarts1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/hogwarts1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/hogwarts1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
                 if(usuario.casa == "Gryffindor" || usuario.casa == "Hufflepuff" || usuario.casa == "Ravenclaw" || usuario.casa == "Slytherin")
           {
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
           }else{ return BadRequest();}
        }

        // POST: api/hogwarts1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {  
              if(usuario.casa == "Gryffindor" || usuario.casa == "Hufflepuff" || usuario.casa == "Ravenclaw" || usuario.casa == "Slytherin")
           {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
           
            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
           }else{ return NoContent();}
        }

        // DELETE: api/hogwarts1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
