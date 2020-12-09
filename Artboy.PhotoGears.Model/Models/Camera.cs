using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models
{
    public class Camera : PhotoGear
    {
        [Key]
        public long Id { get; set; }
        [JsonPropertyName("Camera Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CameraTypeEnum CameraType { get; set; }
        [JsonPropertyName("Frame Size")]
        public string FrameSize { get; set; }
        [JsonPropertyName("Image Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ImageTypeEnum ImageType { get; set; }
        [JsonPropertyName("Iso Range")]
        public string IsoRange { get; set; }
        [JsonPropertyName("Speed Range")]
        public string SpeedRange { get; set; }
        public string Shutter { get; set; }
        [JsonIgnore]
        public int MountId { get; set; }
        [JsonPropertyName("Lens Mount")]
        public Mount LensMount { get; set; }
        [JsonPropertyName("Focusing Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FocusingTypeEnum FocusingType { get; set; }
        [JsonPropertyName("Exposure Mode")]
        public string ExposureMode { get; set; }
        [JsonPropertyName("Exposure Compensation")]
        public string ExposureCompensation { get; set; }
        [JsonPropertyName("Power Source")]
        public string PowerSource { get; set; }
        [JsonPropertyName("Has Interchangeable Lens")]
        public bool HasInterchangeableLens { get; set; }
        [JsonPropertyName("Is Digital")]
        public bool IsDigital { get; set; }
        [JsonIgnore]
        public long? LensId { get; set; }
        [JsonPropertyName("Associated Lens")]
        public Lens AssociatedLens { get; set; }

    }
}
