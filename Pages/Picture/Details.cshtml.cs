using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PixCollab.Data;
using PixCollab.Models;

namespace PixCollab.Pages.Picture
{
    public class DetailsModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;

        public DetailsModel(PixCollab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Picture Picture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Picture = await _context.Picture.FirstOrDefaultAsync(m => m.ID == id);

            if (Picture == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
