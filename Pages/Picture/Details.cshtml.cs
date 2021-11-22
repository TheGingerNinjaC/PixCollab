using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PixCollab.Data;
using PixCollab.Models;

namespace PixCollab.Pages.Picture
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(PixCollab.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Models.Picture Picture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("NotFound");
            }

            Picture = await _context.Picture.Include(u => u.Owner).Include(p => p.Metadata).FirstOrDefaultAsync(m => m.ID == id);

            if (Picture == null)
            {
                return RedirectToPage("NotFound");
            }

            if (Picture.OwnerId != _userManager.GetUserId(User))
            {
                var checkaccess = await _context.PictureAccess.Where(x => x.UserId == _userManager.GetUserId(User) && x.PhotoId == Picture.ID).FirstOrDefaultAsync();

                if (checkaccess == null)
                {
                    return RedirectToPage("AccessDenied");
                }
            }

            return Page();
        }
    }
}
