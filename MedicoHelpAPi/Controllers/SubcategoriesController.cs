using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicoHelpAPi.Models;

namespace MedicoHelpAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private readonly MedicoContext _context;

        public SubcategoriesController(MedicoContext context)
        {
            _context = context;
        }

        // GET: api/Subcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategory()
        {
            return await _context.Subcategory.ToListAsync();
        }

        // GET: api/Subcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Subcategory>>> GetSubcategory(Guid id)
        {
            var subcategories = await _context.Subcategory.Where(s => s.CategoryId == id).ToListAsync();

            if (subcategories == null)
            {
                return NotFound();
            }

            return subcategories;
        }

        // PUT: api/Subcategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcategory(Guid id, Subcategory subcategory)
        {
            if (id != subcategory.Idsubcategory)
            {
                return BadRequest();
            }

            _context.Entry(subcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcategoryExists(id))
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

        // POST: api/Subcategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subcategory>> PostSubcategory(Subcategory subcategory)
        {
            _context.Subcategory.Add(subcategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubcategoryExists(subcategory.Idsubcategory))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubcategory", new { id = subcategory.Idsubcategory }, subcategory);
        }

        // DELETE: api/Subcategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subcategory>> DeleteSubcategory(Guid id)
        {
            var subcategory = await _context.Subcategory.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            _context.Subcategory.Remove(subcategory);
            await _context.SaveChangesAsync();

            return subcategory;
        }

        private bool SubcategoryExists(Guid id)
        {
            return _context.Subcategory.Any(e => e.Idsubcategory == id);
        }
    }
}
