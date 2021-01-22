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
    public class IndexModel : PageModel
    {
        private readonly EventPopper.Models.AppDbContext _context;

        public IndexModel(EventPopper.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Coupon> Coupon { get;set; }

        public async Task OnGetAsync()
        {
            Coupon = await _context.Coupon
                .Include(c => c.Event).ToListAsync();
        }
    }
}
