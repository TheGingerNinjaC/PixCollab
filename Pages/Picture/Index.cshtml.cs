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
    public class IndexModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(PixCollab.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Models.Picture> Picture { get;set; }

        public async Task OnGetAsync()
        {
            var userid = _userManager.GetUserAsync(User).Result.Id;

            Picture = await _context.Picture.Where(x => x.OwnerId == userid).Include(u => u.Owner).ToListAsync();
        }
    }
}
