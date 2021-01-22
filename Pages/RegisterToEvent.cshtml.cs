using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventPopper.Models;

namespace EventPopper.Pages
{
    public class RegisterToEventModel : PageModel
    {

        private AppDbContext _context;
        
        public RegisterToEventModel(AppDbContext context) {
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}