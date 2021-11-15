using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PixCollab.Models
{
    public class PictureAccess
    {
        [Key]
        public string UserId { get; set; }

        public int PhotoId { get; set; }

        public Picture Picture { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
