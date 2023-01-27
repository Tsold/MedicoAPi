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
    public class WeekDaysController : ControllerBase
    {
        private readonly MedicoContext _context;

        public WeekDaysController(MedicoContext context)
        {
            _context = context;
        }

        // GET: api/WeekDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeekDays>>> GetWeekDays()
        {
            return await _context.WeekDays.ToListAsync();
        }

        // GET: api/WeekDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeekDays>> GetWeekDays(Guid id)
        {
            var weekDays = await _context.WeekDays.FindAsync(id);

            if (weekDays == null)
            {
                return NotFound();
            }

            return weekDays;
        }

        // PUT: api/WeekDays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeekDays(Guid id, WeekDays weekDays)
        {
            if (id != weekDays.IdweekDays)
            {
                return BadRequest();
            }

            _context.Entry(weekDays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeekDaysExists(id))
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

        // POST: api/WeekDays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WeekDays>> PostWeekDays(WeekDays weekDays)
        {
            _context.WeekDays.Add(weekDays);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeekDaysExists(weekDays.IdweekDays))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWeekDays", new { id = weekDays.IdweekDays }, weekDays);
        }

        // DELETE: api/WeekDays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeekDays>> DeleteWeekDays(Guid id)
        {
            var weekDays = await _context.WeekDays.FindAsync(id);
            if (weekDays == null)
            {
                return NotFound();
            }

            _context.WeekDays.Remove(weekDays);
            await _context.SaveChangesAsync();

            return weekDays;
        }

        private bool WeekDaysExists(Guid id)
        {
            return _context.WeekDays.Any(e => e.IdweekDays == id);
        }
    }
}
