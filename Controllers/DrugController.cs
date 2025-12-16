using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrugInfo.Api.Data;
using DrugInfo.Api.Entities;

namespace DrugInfo.Api.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return Ok(ingredient);
        }
    }

    [ApiController]
    [Route("api/drugs")]
    public class DrugController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DrugController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrugs([FromQuery] string? name)
        {
            IQueryable<Drug> query = _context.Drugs;

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(d => d.Name.Contains(name));
            }

            var drugs = await query.ToListAsync();
            return Ok(drugs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrug(int id)
        {
            var drug = await _context.Drugs
                .Include(d => d.DrugIngredients)
                .ThenInclude(di => di.Ingredient)
                .FirstOrDefaultAsync(d => d.DrugId == id);

            if (drug == null) return NotFound();
            return Ok(drug);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Drug drug)
        {
            _context.Drugs.Add(drug);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetDrug),
                new { id = drug.DrugId },
                drug
            );
        }
    }
}
