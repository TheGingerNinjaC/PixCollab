using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixCollab.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string URL { get; set; }

        public string OwnerId { get; set; }
        public UserInfo Owner { get; set; }
    }
}
