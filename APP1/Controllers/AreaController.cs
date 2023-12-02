using APP1.DbContexts;
using APP1.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace APP1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        private readonly AppDbContext _context;

        public AreaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return await _context.areas.ToListAsync();
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _context.areas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        // POST: api/Areas
        [HttpPost]
        public async Task<ActionResult<Area>> CreateArea(Area area)
        {
            _context.areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArea), new { id = area.Id }, area);
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var area = await _context.areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.areas.Remove(area);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaExists(int id)
        {
            return _context.areas.Any(e => e.Id == id);
        }

        [HttpPost("login")]
        public IActionResult Login(string nombre, string password)
        {
            var area = _context.areas.FirstOrDefault(a => a.Nombre == nombre && a.Password == password);

            if (area == null)
            {
                return Unauthorized("Credenciales inválidas");
            }

            return Ok(new { area = area.Id });
        }
    }
}
