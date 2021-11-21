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
    public class DeleteModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;

        public DeleteModel(PixCollab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Picture Picture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Picture = await _context.Picture.Include(u => u.Metadata).FirstOrDefaultAsync(m => m.ID == id);

            if (Picture == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Picture = await _context.Picture.FindAsync(id);

            if (Picture != null)
            {
                var access = await _context.PictureAccess.Where(x => x.PhotoId == Picture.ID).ToListAsync();

                foreach (var item in access)
                {
                    _context.PictureAccess.Remove(item);
                }

                var meta = await _context.PictureMetadata.FindAsync(Picture.ID);

                _context.PictureMetadata.Remove(meta);

                _context.Picture.Remove(Picture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
