using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishApp.API.Data;
using FishApp.API.Models;

namespace FishApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecesEstanquesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PecesEstanquesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PezEstanque>>> GetPecesEstanques()
        {
            return await _context.PecesEstanques.Include(pe => pe.Pez)
                                                .Include(pe => pe.Estanque)
                                                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PezEstanque>> GetPezEstanque(int id)
        {
            var pezEstanque = await _context.PecesEstanques.Include(pe => pe.Pez)
                                                          .Include(pe => pe.Estanque)
                                                          .FirstOrDefaultAsync(pe => pe.Id == id);

            if (pezEstanque == null)
                return NotFound();

            return pezEstanque;
        }

        [HttpPost]
        public async Task<ActionResult<PezEstanque>> PostPezEstanque(PezEstanque pezEstanque)
        {
            _context.PecesEstanques.Add(pezEstanque);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPezEstanque), new { id = pezEstanque.Id }, pezEstanque);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPezEstanque(int id, PezEstanque pezEstanque)
        {
            if (id != pezEstanque.Id)
                return BadRequest();

            _context.Entry(pezEstanque).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePezEstanque(int id)
        {
            var pezEstanque = await _context.PecesEstanques.FindAsync(id);
            if (pezEstanque == null)
                return NotFound();

            _context.PecesEstanques.Remove(pezEstanque);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
