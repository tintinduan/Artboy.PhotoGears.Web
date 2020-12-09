using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Web.Models
{
    public class Camera : PhotoGear
    {
        [Key]
        public long Id { get; set; }
        public CameraTypeEnum CameraType { get; set; }
        public string FrameSize { get; set; }
        public ImageTypeEnum ImageType { get; set; }
        public string IsoRange { get; set; }
        public string SpeedRange { get; set; }
        public int MountId { get; set; }
        public Mount LensMount { get; set; }
        public FocusingTypeEnum FocusingType { get; set; }
        public string ExposureMode { get; set; }
        public string ExposureCompensation { get; set; }
        public string PowerSource { get; set; }
        public bool HasInterchangeableLens { get; set; }
        public bool IsDigital { get; set; }
        public long? LensId { get; set; }
        public Lens AssociatedLens { get; set; }

    }
}
