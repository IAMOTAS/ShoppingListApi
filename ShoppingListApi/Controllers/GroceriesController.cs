﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Data;
using ShoppingListApi.Models;

namespace ShoppingListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly ShoppingListApiContext _context;

        public GroceriesController(ShoppingListApiContext context)
        {
            _context = context;
        }

        // GET: api/Groceries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grocery>>> GetGrocery()
        {
            return await _context.Grocery.ToListAsync();
        }

        // GET: api/Groceries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grocery>> GetGrocery(int id)
        {
            var grocery = await _context.Grocery.FindAsync(id);

            if (grocery == null)
            {
                return NotFound();
            }

            return grocery;
        }

        // PUT: api/Groceries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrocery(int id, Grocery grocery)
        {
            if (id != grocery.Id)
            {
                return BadRequest();
            }

            _context.Entry(grocery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(id))
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

        // POST: api/Groceries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grocery>> PostGrocery(Grocery grocery)
        {
            _context.Grocery.Add(grocery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrocery", new { id = grocery.Id }, grocery);
        }

        // DELETE: api/Groceries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrocery(int id)
        {
            var grocery = await _context.Grocery.FindAsync(id);
            if (grocery == null)
            {
                return NotFound();
            }

            _context.Grocery.Remove(grocery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroceryExists(int id)
        {
            return _context.Grocery.Any(e => e.Id == id);
        }
    }
}