using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishApp.API.Data;
using FishApp.API.Models;

namespace FishApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstanquesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstanquesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estanque>>> GetEstanques()
        {
            return await _context.Estanques.Include(e => e.PecesEstanques)
                                           .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estanque>> GetEstanque(int id)
        {
            var estanque = await _context.Estanques.Include(e => e.PecesEstanques)
                                                   .FirstOrDefaultAsync(e => e.Id == id);

            if (estanque == null)
                return NotFound();

            return estanque;
        }

        [HttpPost]
        public async Task<ActionResult<Estanque>> PostEstanque(Estanque estanque)
        {
            _context.Estanques.Add(estanque);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstanque), new { id = estanque.Id }, estanque);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstanque(int id, Estanque estanque)
        {
            if (id != estanque.Id)
                return BadRequest();

            _context.Entry(estanque).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstanque(int id)
        {
            var estanque = await _context.Estanques.FindAsync(id);
            if (estanque == null)
                return NotFound();

            _context.Estanques.Remove(estanque);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
