using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PixCollab.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixCollab.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Picture> Picture { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<PictureMetadata> PictureMetadata { get; set; }
        public DbSet<PictureAccess> PictureAccess { get; set; }
    }
}
