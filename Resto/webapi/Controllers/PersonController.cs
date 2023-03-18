using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using webapi.Context;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly RestoAppContext _context;

        public PersonController(RestoAppContext context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonEntity>>> GetPersons()
        {
          if (_context.Persons == null)
          {
              return NotFound();
          }
            return await _context.Persons.ToListAsync();
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonEntity>> GetPersonEntity(int id)
        {
          if (_context.Persons == null)
          {
              return NotFound();
          }
            var personEntity = await _context.Persons.FindAsync(id);

            if (personEntity == null)
            {
                return NotFound();
            }

            return personEntity;
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonEntity(int id, PersonEntity personEntity)
        {
            if (id != personEntity.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonEntityExists(id))
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

        // POST: api/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonEntity>> PostPersonEntity(PersonEntity personEntity)
        {
          if (_context.Persons == null)
          {
              return Problem("Entity set 'RestoAppContext.Persons'  is null.");
          }
            _context.Persons.Add(personEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonEntity", new { id = personEntity.PersonId }, personEntity);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonEntity(int id)
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }
            var personEntity = await _context.Persons.FindAsync(id);
            if (personEntity == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(personEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonEntityExists(int id)
        {
            return (_context.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
