using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Artboy.PhotoGears.Web.Models
{
    public class GearImage
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a url")]
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }
        public ImageCategoryEnum ImageCategory { get; set; }
        public bool IsUsed { get; set; }
    }
}
