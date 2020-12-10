using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models
{
    public class Mount
    {
        [Key]
        [JsonIgnore]
        public long MountId { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Flange Focal Distance")]
        [JsonPropertyName("Flange Focal Distance")]
        public decimal FlangeFocalDistance { get; set; }
        [JsonPropertyName("Thresd Diameter (mm)")]
        public decimal? ThreadDiameter { get; set; }
        [JsonPropertyName("Mount Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MountTypeEnum MountType { get; set; }
    }
}
