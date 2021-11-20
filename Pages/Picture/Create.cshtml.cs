using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PixCollab.Data;
using PixCollab.Models;

namespace PixCollab.Pages.Picture
{
    public class CreateModel : PageModel
    {
        private readonly PixCollab.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public CreateModel(PixCollab.Data.ApplicationDbContext context, 
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Picture Picture { get; set; }

        [BindProperty]
        [Required]
        public IFormFileCollection Files { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string connectionStr = "DefaultEndpointsProtocol=https;" +
                "AccountName=pixcollab;" +
                "AccountKey=5j1CnNQLMLd+UVhGdTbH7nLRUz9bjFAG7kru+VTniDiYIfF7Zb3QKD0W+peOsyF8+BWYPfiG1PAwNC2RNLdimw==;" +
                "EndpointSuffix=core.windows.net";
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionStr);

            string containerName = "pictures";

            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);

            foreach (var item in Files)
            {
                string localFilePath = Path.Combine(_env.WebRootPath, "temp", item.FileName);

                Picture.OwnerId = _userManager.GetUserAsync(User).Result.Id;
                Picture.DateAdded = DateTime.Now;
                Picture.URL = "https://pixcollab.blob.core.windows.net/pictures/" + item.FileName;

                using (var fileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    item.CopyTo(fileStream);
                }

                BlobClient blobClient = new BlobClient(
                    connectionString: connectionStr,
                    blobContainerName: containerName,
                    blobName: item.FileName
                    );

                Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

                // Upload data from the local file
                await blobClient.UploadAsync(localFilePath, true);
                _context.Picture.Add(Picture);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
