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
        public int ID { get; set; }

        public string UserId { get; set; }
        public UserInfo User { get; set; }
        
        public int PhotoId { get; set; }
        public Picture Photo { get; set; }

        
    }
}
