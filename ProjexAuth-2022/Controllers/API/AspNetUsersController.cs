﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjexAuth_2022.Models;

namespace ProjexAuth_2022.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetUsersController : ControllerBase
    {
        private readonly ProjexDbFinalContext _context;

        public AspNetUsersController(ProjexDbFinalContext context)
        {
            _context = context;
        }

        // GET: api/AspNetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
        {
            return await _context.AspNetUsers.ToListAsync();
        }

        // GET: api/AspNetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUser == null)
            {
                return NotFound();
            }

            return aspNetUser;
        }

        // PUT: api/AspNetUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUser(string id, AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
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

        // POST: api/AspNetUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostAspNetUser(AspNetUser aspNetUser)
        {
            _context.AspNetUsers.Add(aspNetUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(aspNetUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUser", new { id = aspNetUser.Id }, aspNetUser);
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetUser(string id)
        {
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserExists(string id)
        {
            return _context.AspNetUsers.Any(e => e.Id == id);
        }
    }
}
