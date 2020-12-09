using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models
{
    public class Lens : PhotoGear
    {
        [Key]
        public long Id { get; set; }
        [JsonPropertyName("Lens Catsgory")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LensCategoryEnum LensCategory { get; set; }
        [JsonPropertyName("Lens Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LensTypeEnum LensType { get; set; }
        [JsonPropertyName("Focusing Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FocusingTypeEnum FocusingType { get; set; }
        [Required]
        [Range(1,Int32.MaxValue,ErrorMessage ="Please Select a lens mount")]
        [JsonIgnore]
        public int MountId { get; set; }
        [JsonPropertyName("Lens Mount")]
        public Mount LensMount { get; set; }
        [JsonPropertyName("Focal Length")]
        public string FocalLength { get; set; }
        [JsonPropertyName("Aperture Range")]
        public string ApertureRange { get; set; }
        [JsonPropertyName("Close Focusing Distance (m)")]
        public decimal? CloseFocusingDistance { get; set; }
        [JsonPropertyName("Filter Size (mm)")]
        public decimal? FilterSize { get; set; }
        [JsonPropertyName("Lens Construction")]
        public string LensConstruction { get; set; }
        [JsonPropertyName("Max Reproduction Ratio")]
        public decimal? MaxReproductionRatio { get; set; }
        [JsonPropertyName("Diaphragm Blades")]
        public int? DiaphragmBlades { get; set; }
        [JsonIgnore]
        public bool IsAttachedToCamera { get; set; } = false;


    }
}
