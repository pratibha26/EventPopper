using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventPopper.Models;

namespace EventPopper.Pages.Coupons
{
    public class EditModel : PageModel
    {
        private readonly EventPopper.Models.AppDbContext _context;

        public EditModel(EventPopper.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coupon Coupon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coupon = await _context.Coupon
                .Include(c => c.Event).FirstOrDefaultAsync(m => m.Id == id);

            if (Coupon == null)
            {
                return NotFound();
            }
           ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(Coupon.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CouponExists(int id)
        {
            return _context.Coupon.Any(e => e.Id == id);
        }
    }
}
