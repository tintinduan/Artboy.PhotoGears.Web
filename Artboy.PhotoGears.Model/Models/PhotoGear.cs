using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Artboy.PhotoGears.Models
{
    public abstract class PhotoGear
    {
        [JsonPropertyName("Made In Country")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CountriesEnum MadeInCountry { get; set; }
        public string Maker { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Comment { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusEnum Status { get; set; }
        [JsonPropertyName("Serial Number")]
        public string SerialNumber { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public ICollection<GearImage> Images { get; set; }
        [JsonIgnore]
        public bool IsForSale { get; set; }

    }
}
