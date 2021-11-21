using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PixCollab.Data;
using PixCollab.Models;

namespace PixCollab.Pages.Picture
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;

        public EditModel(PixCollab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Picture Picture { get; set; }

        [BindProperty]
        public string Longitude { get; set; }
        [BindProperty]
        public string Latitude { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Picture = await _context.Picture.Include(p => p.Metadata).FirstOrDefaultAsync(m => m.ID == id);

            if (Picture == null)
            {
                return NotFound();
            }
            else
            {
                if (_context.PictureMetadata.Any(m => m.PictureId == Picture.ID))
                {
                    if (Picture.Metadata.Geolocation != null && Picture.Metadata.Geolocation != "")
                    {
                        string[] split = Picture.Metadata.Geolocation.Split(' ');

                        Longitude = split[0];
                        Latitude = split[1];
                    }
                }
            }
        
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Picture).State = EntityState.Modified;

            Picture.Metadata.Geolocation = Longitude + " " + Latitude;

            if (_context.PictureMetadata.Any(m => m.PictureId == Picture.ID))
            {
                _context.Attach(Picture.Metadata).State = EntityState.Modified;
            }
            else
            {
                _context.Add(Picture.Metadata);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PictureExists(Picture.ID))
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

        private bool PictureExists(int id)
        {
            return _context.Picture.Any(e => e.ID == id);
        }
    }
}
