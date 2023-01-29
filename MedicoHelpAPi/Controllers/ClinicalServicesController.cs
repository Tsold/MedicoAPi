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
    public class ClinicalServicesController : ControllerBase
    {
        private readonly MedicoContext _context;

        public ClinicalServicesController(MedicoContext context)
        {
            _context = context;
        }

        // GET: api/ClinicalServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClinicalService>>> GetClinicalService()
        {
            return await _context.ClinicalService.ToListAsync();
        }

        // GET: api/ClinicalServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ClinicalService>>> GetClinicalService(Guid id)
        {
            var clinicalServices = await _context.ClinicalService.Where(s => s.MedicalServiceId == id).ToListAsync();

            if (clinicalServices == null)
            {
                return NotFound();
            }

            return clinicalServices;
        }
        // PUT: api/ClinicalServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinicalService(Guid id, ClinicalService clinicalService)
        {
            if (id != clinicalService.Idservice)
            {
                return BadRequest();
            }

            _context.Entry(clinicalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicalServiceExists(id))
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

        // POST: api/ClinicalServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClinicalService>> PostClinicalService(ClinicalService clinicalService)
        {
            _context.ClinicalService.Add(clinicalService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClinicalServiceExists(clinicalService.Idservice))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClinicalService", new { id = clinicalService.Idservice }, clinicalService);
        }

        // DELETE: api/ClinicalServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClinicalService>> DeleteClinicalService(Guid id)
        {
            var clinicalService = await _context.ClinicalService.FindAsync(id);
            if (clinicalService == null)
            {
                return NotFound();
            }

            _context.ClinicalService.Remove(clinicalService);
            await _context.SaveChangesAsync();

            return clinicalService;
        }

        private bool ClinicalServiceExists(Guid id)
        {
            return _context.ClinicalService.Any(e => e.Idservice == id);
        }
    }
}
