using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Web.Models
{
    public class Lens : PhotoGear
    {
        [Key]
        public long Id { get; set; }
        public LensCategoryEnum LensCategory { get; set; }
        public LensTypeEnum LensType { get; set; }
        public FocusingTypeEnum FocusingType { get; set; }
        [Required]
        [Range(1,Int32.MaxValue,ErrorMessage ="Please Select a lens mount")]
        public int MountId { get; set; }
        public Mount LensMount { get; set; }
        public string FocalLength { get; set; }
        public string ApertureRange { get; set; }
        public decimal? CloseFocusingDistance { get; set; }
        public decimal? FilterSize { get; set; }
        public string LensConstruction { get; set; }
        public decimal? MaxReproductionRatio { get; set; }
        public int? DiaphragmBlades { get; set; }
        public bool IsAttachedToCamera { get; set; } = false;


    }
}
