using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models.ViewModels
{
    public class LensViewModel
    {
        public Lens Lens { get; set; }
        public string Action { get; set; } = "Get";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
        public Mount Mount { get; set; }
        public IEnumerable<GearImage> Images { get; set; }
            = Enumerable.Empty<GearImage>();
    }
}
