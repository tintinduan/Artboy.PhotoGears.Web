using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models
{
    public class Accessory : PhotoGear
    {
        [Key]
        public long Id { get; set; }
        [JsonPropertyName("Accessory Type")]
        public string AccessoryType { get; set; }
        [JsonPropertyName("Accessory Detail")]
        public string AccessoryDetail { get; set; }

    }
}
