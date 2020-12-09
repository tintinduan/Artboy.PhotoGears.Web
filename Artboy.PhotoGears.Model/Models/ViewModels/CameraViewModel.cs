using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models.ViewModels
{
    public class CameraViewModel
    {
        public Camera Camera { get; set; }
        public string Action { get; set; } = "Get";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
        public Lens AssociatedLens { get; set; }
        public Mount Mount { get; set; }
        public IEnumerable<GearImage> Images { get; set; }
            = Enumerable.Empty<GearImage>();
    }
}
