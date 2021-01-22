using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventPopper.Models;

namespace EventPopper.Pages.Coupons
{
    public class CreateModel : PageModel
    {
        private readonly EventPopper.Models.AppDbContext _context;

        public CreateModel(EventPopper.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EventId"] = new SelectList(_context.Event, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Coupon Coupon { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Coupon.Add(Coupon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}