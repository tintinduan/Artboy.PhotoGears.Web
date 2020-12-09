using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Artboy.PhotoGears.Models
{
    public class GearImage
    {
        [Key]
        [JsonIgnore]
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a url")]
        [DisplayName("Image Url")]
        [JsonPropertyName("Image Url")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("Image Category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ImageCategoryEnum ImageCategory { get; set; }
        [JsonIgnore]
        public bool IsUsed { get; set; }
    }
}
