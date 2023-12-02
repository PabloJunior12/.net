using APP1.DbContexts;
using APP1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramiteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TramiteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tramites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tramite>>> GetTramites()
        {
            return await _context.tramites.ToListAsync();
        }

        // GET: api/Tramites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tramite>> GetTramite(int id)
        {
            var tramite = await _context.tramites.FindAsync(id);

            if (tramite == null)
            {
                return NotFound();
            }

            return tramite;
        }

        // POST: api/Tramites
        [HttpPost]
        public async Task<ActionResult<Tramite>> CreateTramite(Tramite tramite)
        {
            _context.tramites.Add(tramite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTramite), new { id = tramite.Id }, tramite);
        }

        // PUT: api/Tramites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTramite(int id, Tramite tramite)
        {
            if (id != tramite.Id)
            {
                return BadRequest();
            }

            _context.Entry(tramite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TramiteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Tramites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTramite(int id)
        {
            var tramite = await _context.tramites.FindAsync(id);
            if (tramite == null)
            {
                return NotFound();
            }

            _context.tramites.Remove(tramite);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool TramiteExists(int id)
        {
            return _context.tramites.Any(e => e.Id == id);
        }

        // GET: api/Tramites/ByDestinoId/5
        [HttpGet("ByDestinoId/{destinoId}")]
        public async Task<ActionResult<IEnumerable<Tramite>>> GetTramitesByDestinoId(int destinoId)
        {
            var tramites = await _context.tramites.Where(t => t.DestinoId == destinoId).ToListAsync();

            if (!tramites.Any())
            {
                return NotFound();
            }

            return tramites;
        }

        // GET: api/Tramites/ByDestinoId/5
        [HttpGet("origen/{origenId}")]
        public async Task<ActionResult<IEnumerable<Tramite>>> GetTramitesOrigenId(int origenId)
        {
            var tramites = await _context.tramites.Where(t => t.OrigenId == origenId).ToListAsync();

            return tramites.Any() ? tramites : new List<Tramite>();
        }

    }

}
