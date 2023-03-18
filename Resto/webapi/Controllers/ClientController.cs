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
    public class ClientController : ControllerBase
    {
        private readonly RestoAppContext _context;

        public ClientController(RestoAppContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientEntity>>> GetClients()
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientEntity>> GetClientEntity(int id)
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            var clientEntity = await _context.Clients.FindAsync(id);

            if (clientEntity == null)
            {
                return NotFound();
            }

            return clientEntity;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientEntity(int id, ClientEntity clientEntity)
        {
            if (id != clientEntity.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(clientEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientEntityExists(id))
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

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientEntity>> PostClientEntity(ClientEntity clientEntity)
        {
          if (_context.Clients == null)
          {
              return Problem("Entity set 'RestoAppContext.Clients'  is null.");
          }
            _context.Clients.Add(clientEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientEntity", new { id = clientEntity.ClientId }, clientEntity);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientEntity(int id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var clientEntity = await _context.Clients.FindAsync(id);
            if (clientEntity == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clientEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientEntityExists(int id)
        {
            return (_context.Clients?.Any(e => e.ClientId == id)).GetValueOrDefault();
        }
    }
}
