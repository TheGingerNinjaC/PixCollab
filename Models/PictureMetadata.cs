using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PixCollab.Models
{
    public class PictureMetadata
    {
        [Key]
        public int PictureId { get; set; }
        public string Geolocation { get; set; }
        public string Tags { get; set; }
        [Display(Name = "Captured by")]
        public string CapturedBy { get; set; }
        [Display(Name = "Captured date")]
        [DataType(DataType.Date)]
        public DateTime CapturedDate { get; set; }
    }
}
