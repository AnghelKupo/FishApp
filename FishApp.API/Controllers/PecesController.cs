using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishApp.API.Data;
using FishApp.API.Models;

namespace FishApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PecesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pez>>> GetPeces()
        {
            return await _context.Peces.Include(p => p.Especie)
                                       .Include(p => p.PecesEstanques)
                                       .ThenInclude(pe => pe.Estanque)
                                       .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pez>> GetPez(int id)
        {
            var pez = await _context.Peces.Include(p => p.Especie)
                                          .Include(p => p.PecesEstanques)
                                          .ThenInclude(pe => pe.Estanque)
                                          .FirstOrDefaultAsync(p => p.Id == id);

            if (pez == null)
                return NotFound();

            return pez;
        }

        [HttpPost]
        public async Task<ActionResult<Pez>> PostPez(CrearPezRequest request)
        {
            var pez = new Pez
            {
                Codigo = request.Codigo,
                Sexo = request.Sexo,
                FechaRegistro = request.FechaRegistro,
                FechaUltimaReproduccion = request.FechaRegistro,
                EspecieId = request.EspecieId
            };

            _context.Peces.Add(pez);
            await _context.SaveChangesAsync();

            var pezEstanque = new PezEstanque
            {
                IdPez = pez.Id,
                IdEstanque = request.IdEstanque,
                FechaEntrada = request.FechaEntrada
            };

            _context.PecesEstanques.Add(pezEstanque);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPez), new { id = pez.Id }, pez);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPez(int id, Pez pez)
        {
            if (id != pez.Id)
                return BadRequest();

            _context.Entry(pez).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePez(int id)
        {
            var pez = await _context.Peces.FindAsync(id);
            if (pez == null)
                return NotFound();

            _context.Peces.Remove(pez);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
