using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Artboy.PhotoGears.Web.Models
{
    public abstract class PhotoGear
    {
        public CountriesEnum MadeInCountry { get; set; }
        public string Maker { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Comment { get; set; }
        public StatusEnum Status { get; set; }
        public string SerialNumber { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public ICollection<GearImage> Images { get; set; }

    }
}
