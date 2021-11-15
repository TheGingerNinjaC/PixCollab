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
        public string PictureId { get; set; }
        public string Geolocation { get; set; }
        public string Tags { get; set; }
        public string CapturedBy { get; set; }
        public DateTime CapturedDate { get; set; }
    }
}
