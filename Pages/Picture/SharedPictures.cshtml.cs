using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PixCollab.Data;
using PixCollab.Models;

namespace PixCollab.Pages.Picture
{
    [Authorize]
    public class SharedPicturesModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SharedPicturesModel(PixCollab.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Models.Picture> Picture { get; set; }

        public async Task OnGetAsync()
        {
            var userid = _userManager.GetUserAsync(User).Result.Id;

            string qry = string.Format(@"SELECT p.* FROM dbo.Picture p
left outer join dbo.PictureAccess pa
on pa.PhotoId = p.ID
where pa.UserId = '{0}'", userid);

            Picture = await _context.Picture
                .FromSqlRaw(qry).Include(x => x.Owner).ToListAsync();
        }
    }
}
