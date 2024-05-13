using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlackJack.Data;
using BlackJack.Models;

namespace BlackJack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketsController : ControllerBase
    {
        private readonly BlackJackContext _context;

        public SupportTicketsController(BlackJackContext context)
        {
            _context = context;
        }

        // GET: api/SupportTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportTicket>>> GetSupportTickets()
        {
            return await _context.SupportTicket.ToListAsync();
        }

        // GET: api/SupportTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportTicket>> GetSupportTicket(int id)
        {
            var supportTicket = await _context.SupportTicket.FindAsync(id);

            if (supportTicket == null)
            {
                return NotFound();
            }

            return supportTicket;
        }

        // PUT: api/SupportTickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportTicket(int id, SupportTicket supportTicket)
        {
            if (id != supportTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(supportTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportTicketExists(id))
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

        // POST: api/SupportTickets
        [HttpPost]
        public async Task<ActionResult<SupportTicket>> PostSupportTicket(SupportTicket supportTicket)
        {
            _context.SupportTicket.Add(supportTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupportTicket", new { id = supportTicket.Id }, supportTicket);
        }

        // DELETE: api/SupportTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportTicket(int id)
        {
            var supportTicket = await _context.SupportTicket.FindAsync(id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            _context.SupportTicket.Remove(supportTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportTicketExists(int id)
        {
            return _context.SupportTicket.Any(e => e.Id == id);
        }
    }
}
