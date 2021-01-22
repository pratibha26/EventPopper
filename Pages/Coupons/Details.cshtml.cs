using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPopper.Models;

namespace EventPopper.Pages.Coupons
{
    public class DetailsModel : PageModel
    {
        private readonly EventPopper.Models.AppDbContext _context;

        public DetailsModel(EventPopper.Models.AppDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
