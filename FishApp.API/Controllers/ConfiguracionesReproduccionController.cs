using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishApp.API.Data;
using FishApp.API.Models;

namespace FishApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionesReproduccionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConfiguracionesReproduccionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracionReproduccion>>> GetConfiguraciones()
        {
            return await _context.ConfiguracionesReproduccion
                                 .Include(c => c.Especie)
                                 .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracionReproduccion>> GetConfiguracion(int id)
        {
            var config = await _context.ConfiguracionesReproduccion
                                       .Include(c => c.Especie)
                                       .FirstOrDefaultAsync(c => c.Id == id);
            if (config == null)
                return NotFound();
            return config;
        }

        [HttpPost]
        public async Task<ActionResult<ConfiguracionReproduccion>> PostConfiguracion(ConfiguracionReproduccion config)
        {
            _context.ConfiguracionesReproduccion.Add(config);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetConfiguracion), new { id = config.Id }, config);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracion(int id, ConfiguracionReproduccion config)
        {
            if (id != config.Id)
                return BadRequest();
            _context.Entry(config).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracion(int id)
        {
            var config = await _context.ConfiguracionesReproduccion.FindAsync(id);
            if (config == null)
                return NotFound();
            _context.ConfiguracionesReproduccion.Remove(config);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
