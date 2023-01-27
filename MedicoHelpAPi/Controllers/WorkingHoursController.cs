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
    public class WorkingHoursController : ControllerBase
    {
        private readonly MedicoContext _context;

        public WorkingHoursController(MedicoContext context)
        {
            _context = context;
        }

        // GET: api/WorkingHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkingHours>>> GetWorkingHours()
        {
            return await _context.WorkingHours.ToListAsync();
        }

        // GET: api/WorkingHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkingHours>> GetWorkingHours(Guid id)
        {
            var workingHours = await _context.WorkingHours.FindAsync(id);

            if (workingHours == null)
            {
                return NotFound();
            }

            return workingHours;
        }

        // PUT: api/WorkingHours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingHours(Guid id, WorkingHours workingHours)
        {
            if (id != workingHours.IdavailableTimeFrame)
            {
                return BadRequest();
            }

            _context.Entry(workingHours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingHoursExists(id))
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

        // POST: api/WorkingHours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkingHours>> PostWorkingHours(WorkingHours workingHours)
        {
            _context.WorkingHours.Add(workingHours);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkingHoursExists(workingHours.IdavailableTimeFrame))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorkingHours", new { id = workingHours.IdavailableTimeFrame }, workingHours);
        }

        // DELETE: api/WorkingHours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkingHours>> DeleteWorkingHours(Guid id)
        {
            var workingHours = await _context.WorkingHours.FindAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }

            _context.WorkingHours.Remove(workingHours);
            await _context.SaveChangesAsync();

            return workingHours;
        }

        private bool WorkingHoursExists(Guid id)
        {
            return _context.WorkingHours.Any(e => e.IdavailableTimeFrame == id);
        }
    }
}
