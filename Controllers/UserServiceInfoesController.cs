using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceBookingJwt.Models;

namespace ServiceBookingJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServiceInfoesController : ControllerBase
    {
        private readonly ServiceBookingContext _context;

        public UserServiceInfoesController(ServiceBookingContext context)
        {
            _context = context;
        }

        // GET: api/UserServiceInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserServiceInfo>>> GetUserServiceInfos()
        {
            return await _context.UserServiceInfos.ToListAsync();
        }

        // GET: api/UserServiceInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserServiceInfo>> GetUserServiceInfo(string id)
        {
            var userServiceInfo = await _context.UserServiceInfos.FindAsync(id);

            if (userServiceInfo == null)
            {
                return NotFound();
            }

            return userServiceInfo;
        }

        // PUT: api/UserServiceInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserServiceInfo(string id, UserServiceInfo userServiceInfo)
        {
            if (id != userServiceInfo.Usid)
            {
                return BadRequest();
            }

            _context.Entry(userServiceInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserServiceInfoExists(id))
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

        // POST: api/UserServiceInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserServiceInfo>> PostUserServiceInfo(UserServiceInfo userServiceInfo)
        {
            _context.UserServiceInfos.Add(userServiceInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserServiceInfoExists(userServiceInfo.Usid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserServiceInfo", new { id = userServiceInfo.Usid }, userServiceInfo);
        }

        // DELETE: api/UserServiceInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserServiceInfo(string id)
        {
            var userServiceInfo = await _context.UserServiceInfos.FindAsync(id);
            if (userServiceInfo == null)
            {
                return NotFound();
            }

            _context.UserServiceInfos.Remove(userServiceInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserServiceInfoExists(string id)
        {
            return _context.UserServiceInfos.Any(e => e.Usid == id);
        }
    }
}
