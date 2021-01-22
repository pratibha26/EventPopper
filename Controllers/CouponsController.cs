using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventPopper.Models;

namespace EventPopper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CouponsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Coupons
        [HttpGet]
        public IEnumerable<Coupon> GetCoupon()
        {
            return _context.Coupon;
        }

        // GET: api/Coupons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoupon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coupon = await _context.Coupon.FindAsync(id);

            if (coupon == null)
            {
                return NotFound();
            }

            return Ok(coupon);
        }

        // PUT: api/Coupons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoupon([FromRoute] int id, [FromBody] Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupon.Id)
            {
                return BadRequest();
            }

            _context.Entry(coupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
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

        // POST: api/Coupons
        [HttpPost]
        public async Task<IActionResult> PostCoupon([FromBody] Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coupon.Add(coupon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoupon", new { id = coupon.Id }, coupon);
        }

        // DELETE: api/Coupons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coupon = await _context.Coupon.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }

            _context.Coupon.Remove(coupon);
            await _context.SaveChangesAsync();

            return Ok(coupon);
        }

        private bool CouponExists(int id)
        {
            return _context.Coupon.Any(e => e.Id == id);
        }

    }
}