using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Web.Models
{
    public class Accessory : PhotoGear
    {
        [Key]
        public long Id { get; set; }
        public string AccessoryType { get; set; }
        public string AccessoryDetail { get; set; }

    }
}
