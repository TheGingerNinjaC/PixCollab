using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixCollab.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PixCollab.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IList<Models.Picture> Picture { get; set; }
        public string loggedInUser { get; set; }

        public async Task OnGetAsync()
        {
            var userid = _userManager.GetUserAsync(User).Result.Id;

            string qry = string.Format(@"SELECT * FROM dbo.Picture 
where OwnerId = '{0}'
union
select p.* from dbo.Picture p
left outer join dbo.PictureAccess pa
on  p.ID = pa.PhotoId
where pa.UserId = '{0}'", userid);

            Picture = await _context.Picture
                .FromSqlRaw(qry).Include(x => x.Owner).ToListAsync();

            loggedInUser = userid;
        }
    }
}
