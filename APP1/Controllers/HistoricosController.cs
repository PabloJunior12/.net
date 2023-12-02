using APP1.DbContexts;
using APP1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HistoricosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Historicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historico>>> GetHistoricos()
        {
            return await _context.Historicos.ToListAsync();
        }

        // GET: api/Historicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historico>> GetHistorico(int id)
        {
            var historico = await _context.Historicos.FindAsync(id);

            if (historico == null)
            {
                return NotFound();
            }

            return historico;
        }

        // POST: api/Historicos
        [HttpPost]
        public async Task<ActionResult<Historico>> CreateHistorico(Historico historico)
        {
            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistorico), new { id = historico.Id }, historico);
        }

        // PUT: api/Historicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistorico(int id, Historico historico)
        {
            if (id != historico.Id)
            {
                return BadRequest();
            }

            _context.Entry(historico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoExists(id))
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

        // DELETE: api/Historicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorico(int id)
        {
            var historico = await _context.Historicos.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }

            _context.Historicos.Remove(historico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricoExists(int id)
        {
            return _context.Historicos.Any(e => e.Id == id);
        }
    }

}
