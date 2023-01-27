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
    public class MeetingsController : ControllerBase
    {
        private readonly MedicoContext _context;

        public MeetingsController(MedicoContext context)
        {
            _context = context;
        }

        // GET: api/Meetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeeting()
        {
            return await _context.Meeting.ToListAsync();
        }

        // GET: api/Meetings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(string id)
        {
            var meeting = await _context.Meeting.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            return meeting;
        }

        // PUT: api/Meetings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeeting(string id, Meeting meeting)
        {
            if (id != meeting.MeetingId)
            {
                return BadRequest();
            }

            _context.Entry(meeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(id))
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

        // POST: api/Meetings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Meeting>> PostMeeting(Meeting meeting)
        {
            _context.Meeting.Add(meeting);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeetingExists(meeting.MeetingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeeting", new { id = meeting.MeetingId }, meeting);
        }

        // DELETE: api/Meetings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meeting>> DeleteMeeting(string id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();

            return meeting;
        }

        private bool MeetingExists(string id)
        {
            return _context.Meeting.Any(e => e.MeetingId == id);
        }
    }
}
