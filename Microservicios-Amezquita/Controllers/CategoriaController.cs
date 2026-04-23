using Microservicios_Amezquita.Data;
using Microservicios_Amezquita.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservicios_Amezquita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoriaController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _db.Categorias.ToListAsync();
            return Ok(categorias);
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _db.Categorias.FindAsync(id); 
            if (categoria == null)
            {
                return NotFound(new { mensaje = "Categoria no encontrada" });
            }
            return Ok(categoria);
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Categorias.Add(categoria);
            await _db.SaveChangesAsync();

            
            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el del cuerpo" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _db.Update(categoria);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Categorias.AnyAsync(c => c.Id == id))
                {
                    return NotFound(new { mensaje = "Categoria no encontrada" });
                }
                throw;
            }

            return NoContent(); 
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _db.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound(new { mensaje = "Categoria no encontrada" });
            }

            _db.Categorias.Remove(categoria);
            await _db.SaveChangesAsync();

            return NoContent(); 
        }
    }
}