using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PixCollab.Models
{
    public class Picture
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string URL { get; set; }

        public string OwnerId { get; set; }
        public UserInfo Owner { get; set; }
        public PictureMetadata Metadata { get; set; }
        public PictureAccess PictureAccess { get; set; }
    }
}
