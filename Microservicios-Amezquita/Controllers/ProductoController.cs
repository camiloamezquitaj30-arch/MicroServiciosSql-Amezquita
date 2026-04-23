using Microservicios_Amezquita.Data;
using Microservicios_Amezquita.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservicios_Amezquita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductoController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var productos = await _db.Productos.ToListAsync();
            return Ok(productos);
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await _db.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound(new { mensaje = "Producto no encontrado" });
            }
            return Ok(producto);
        }

        // POST: api/Producto
        [HttpPost]
        public async Task<ActionResult<Producto>> Post([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Productos.Add(producto);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        // PUT: api/Producto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el del cuerpo" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _db.Update(producto);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Productos.AnyAsync(p => p.Id == id))
                {
                    return NotFound(new { mensaje = "Producto no encontrado" });
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _db.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound(new { mensaje = "Producto no encontrado" });
            }

            _db.Productos.Remove(producto);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}