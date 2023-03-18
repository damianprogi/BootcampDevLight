using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly RestoAppContext _context;

        public ReservationController(RestoAppContext context)
        {
            _context = context;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationEntity>>> GetReservations()
        {
          if (_context.Reservations == null)
          {
              return NotFound();
          }
            return await _context.Reservations.ToListAsync();
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationEntity>> GetReservationEntity(int id)
        {
          if (_context.Reservations == null)
          {
              return NotFound();
          }
            var reservationEntity = await _context.Reservations.FindAsync(id);

            if (reservationEntity == null)
            {
                return NotFound();
            }

            return reservationEntity;
        }

        // PUT: api/Reservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationEntity(int id, ReservationEntity reservationEntity)
        {
            if (id != reservationEntity.ReservationId)
            {
                return BadRequest();
            }

            _context.Entry(reservationEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationEntityExists(id))
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

        // POST: api/Reservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationEntity>> PostReservationEntity(ReservationEntity reservationEntity)
        {
          if (_context.Reservations == null)
          {
              return Problem("Entity set 'RestoAppContext.Reservations'  is null.");
          }
            _context.Reservations.Add(reservationEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationEntity", new { id = reservationEntity.ReservationId }, reservationEntity);
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationEntity(int id)
        {
            if (_context.Reservations == null)
            {
                return NotFound();
            }
            var reservationEntity = await _context.Reservations.FindAsync(id);
            if (reservationEntity == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservationEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationEntityExists(int id)
        {
            return (_context.Reservations?.Any(e => e.ReservationId == id)).GetValueOrDefault();
        }
    }
}
