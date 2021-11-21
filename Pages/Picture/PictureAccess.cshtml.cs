using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PixCollab.Pages.Picture
{
    [Authorize]
    public class PictureAccessModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PictureAccessModel(PixCollab.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Models.Picture Picture { get; set; }
        public IList<Models.PictureAccess> PictureAccess { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Picture = await _context.Picture.Include(u => u.Owner).FirstOrDefaultAsync(m => m.ID == id);

            if (Picture == null)
            {
                return NotFound();
            }

            if (Picture.OwnerId != _userManager.GetUserId(User))
            {
                return NotFound();
            }

            PictureAccess = await _context.PictureAccess.Where(x => x.PhotoId == Picture.ID).Include(u => u.User).ToListAsync();

            return Page();
        }

        [BindProperty]
        public string useremail { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string userid = _context.UserInfo.Where(x => x.Email == useremail).FirstOrDefault().UserId;

            if (userid != null && userid != "")
            {
                var access = new Models.PictureAccess { PhotoId = Picture.ID, UserId = userid };

                _context.PictureAccess.Add(access);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./PictureAccess", new { id = Picture.ID });
        }

        public async Task<IActionResult> OnPostDeleteAsync(string uid)
        {
            var picaccess = _context.PictureAccess.Where(x => x.UserId == uid && x.PhotoId == Picture.ID).FirstOrDefault();

            if (picaccess != null)
            {
               _context.PictureAccess.Remove(picaccess);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./PictureAccess", new { id = Picture.ID });
        }
    }
}
