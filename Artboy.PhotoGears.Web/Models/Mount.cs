using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Web.Models
{
    public class Mount
    {
        [Key]
        public int MountId { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Flange Focal Distance")]
        public decimal FlangeFocalDistance { get; set; }
        public decimal? ThreadDiameter { get; set; }
        public MountTypeEnum MountType { get; set; }
    }
}
