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
    public class MedicalServicesController : ControllerBase
    {
        private readonly MedicoContext _context;

        public MedicalServicesController(MedicoContext context)
        {
            _context = context;
        }

        // GET: api/MedicalServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalService>>> GetMedicalService()
        {
            return await _context.MedicalService.ToListAsync();
        }
        // GET: api/MedicalServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MedicalService>>> GetMedicalService(Guid id)
        {
            var medicalServices = await _context.MedicalService.Where(s => s.SubcategoryId == id).ToListAsync();

            if (medicalServices == null)
            {
                return NotFound();
            }

            return medicalServices;
        }

        // PUT: api/MedicalServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalService(Guid id, MedicalService medicalService)
        {
            if (id != medicalService.IdmedicalService)
            {
                return BadRequest();
            }

            _context.Entry(medicalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalServiceExists(id))
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

        // POST: api/MedicalServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MedicalService>> PostMedicalService(MedicalService medicalService)
        {
            _context.MedicalService.Add(medicalService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicalServiceExists(medicalService.IdmedicalService))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicalService", new { id = medicalService.IdmedicalService }, medicalService);
        }

        // DELETE: api/MedicalServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalService>> DeleteMedicalService(Guid id)
        {
            var medicalService = await _context.MedicalService.FindAsync(id);
            if (medicalService == null)
            {
                return NotFound();
            }

            _context.MedicalService.Remove(medicalService);
            await _context.SaveChangesAsync();

            return medicalService;
        }

        private bool MedicalServiceExists(Guid id)
        {
            return _context.MedicalService.Any(e => e.IdmedicalService == id);
        }
    }
}
