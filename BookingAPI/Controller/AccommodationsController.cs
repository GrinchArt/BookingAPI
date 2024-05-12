using BookingAPI.Data;
using BookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationsController : ControllerBase
    {
        private readonly BookingDbContext _context;
        public AccommodationsController(BookingDbContext context)
        {
            _context = context;
        }



        //GET: api/Accommodations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetAllAccommodations()
        {
            return await _context.Accommodations.ToListAsync();
        }

        //GET: api/Accommodations
        [HttpGet("{id}")]
        public async Task<ActionResult<Accommodation>> GetAccommodationById(int id)
        {
            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation == null)
            {
                return NotFound();
            }
            return accommodation;
        }

        //POST: api/Accommodations
        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostAccommodation(Accommodation accommodation)
        {
            _context.Accommodations.Add(accommodation);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllAccommodations",new { id=accommodation.Id},accommodation);
        }


        //PUT: api/Accommodations/5
        [HttpPut]
        public async Task<IActionResult> PutAccommodation(int id,Accommodation accommodation)
        {
            if (id != accommodation.Id)
            {
                return BadRequest();
            }
            _context.Entry(accommodation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Accommodations.Any(e=>e.Id==id))
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


        //DELETE: api/Accommodations/5
        [HttpDelete]
        public async Task<IActionResult> DeleteAccommodation(int id)
        {
            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation==null)
            {
                return NotFound();
            }

            _context.Accommodations.Remove(accommodation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
