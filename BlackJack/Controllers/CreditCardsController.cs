using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackJack.Data;
using BlackJack.Models;

namespace BlackJack.Controllers
{
    public class CreditCardsController : Controller
    {
        private readonly BlackJackContext _context;

        public CreditCardsController(BlackJackContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult<CreditCard>> PostCreditCard(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CreditCard.Add(creditCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCreditCard), new { id = creditCard.Id }, creditCard);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCard>> GetCreditCard(int id)
        {
            var creditCard = await _context.CreditCard.FindAsync(id);

            if (creditCard == null)
            {
                return NotFound();
            }

            return creditCard;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditCard(int id, CreditCard creditCard)
        {
            if (id != creditCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(creditCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            var creditCard = await _context.CreditCard.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            _context.CreditCard.Remove(creditCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditCardExists(int id)
        {
            return _context.CreditCard.Any(e => e.Id == id);
        }
    }
}