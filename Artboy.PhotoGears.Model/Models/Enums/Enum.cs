using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Artboy.PhotoGears.Models
{
    public enum StatusEnum
    {
        [Description("New")]
        [Display(Name ="New Item")]
        AsNew,
        Used,
        [Description("Has Issue")]
        [Display(Name = "Has Issue")]
        HasIssue,
        [Description("As Parts")]
        [Display(Name = "As Parts")]
        AsParts
    }
    public enum MountTypeEnum
    {
        Screw,
        Bayonet,
        [Description("Breech Lock")]
        [Display(Name = "Breech Lock")]
        BreechLock,
        [Description("Double Bayonet")]
        [Display(Name = "Double Bayonet")]
        DoubleBayonet,
        Fixed,
        [Description("Lens Board")]
        [Display(Name = "Lens Board")]
        LensBoard
    }
    public enum FocusingTypeEnum
    {
        Auto,
        Manual,
        [Description("Manual Zone")]
        [Display(Name = "Manual Zone")]
        ManualZone,
        Fixed  
    }
   
    public enum ImageTypeEnum
    {
        [Description("135 Cartridge")]
        [Display(Name = "135 Cartridge")]
        Cartridge_135,
        [Description("126 Cartridge")]
        [Display(Name = "126 Cartridge")]
        Cartridge_126,
        [Description("240 Cartridge")]
        [Display(Name = "240 Cartridge")]
        Cartridge_240,
        [Description("Minolta 16 Cartridge")]
        [Display(Name = "Minolta 16 Cartridge")]
        CartridgeMinolta_16,
        [Description("Super 16 Rollei Cartridge")]
        [Display(Name = "Super 16 Rollei Cartridge")]
        CartridgeSuper_16,
        [Description("Instant Pack Film")]
        [Display(Name = "Instant Pack Film")]
        InstantPackFilm,
        [Description("110 Roll Film")]
        [Display(Name = "110 Roll Film")]
        RollFilm_110,
        [Description("116 Roll Film")]
        [Display(Name = "116 Roll Film")]
        RollFilm_116,
        [Description("120 Roll Film")]
        [Display(Name = "120 Roll Film")]
        RollFilm_120,
        [Description("127 Roll Film")]
        [Display(Name = "127 Roll Film")]
        RollFilm_127,
        [Description("220 Roll Film")]
        [Display(Name = "220 Roll Film")]
        RollFilm_220,
        [Description("616 Roll Film")]
        [Display(Name = "616 Roll Film")]
        RollFilm_616,
        [Description("620 Roll Film")]
        [Display(Name = "620 Roll Film")]
        RollFilm_620,
        [Description("828 Roll Film")]
        [Display(Name = "828 Roll Film")]
        RollFilm_828,
        [Description("Plate Film")]
        [Display(Name = "Plate Film")]
        PlateFilm, 
        [Description("Super 8 Movie Film")]
        [Display(Name = "Super 8 Movie Film")]
        Super_8_MovieFilm,
        [Description("Super 16 Movie Film")]
        [Display(Name = "Super 16 Movie Film")]
        Super_16_MovieFilm,
        CCD,
        CMOS,
        Other
    }
    public enum LensCategoryEnum
    {
        Prime,
        Zoom
    }
    public enum LensTypeEnum
    {
        Standard,
        Macro,
        Telephoto,
        [Description("Wide Angle")]
        [Display(Name = "Wide Angle")]
        WideAngle,
        Specialty,
        Other
    }
    public enum CameraTypeEnum
    {
        [Description("Single Lens Reflex")]
        [Display(Name = "Single Lens Reflex")]
        SingleLensReflex,
        Rangefinder,
        [Description("Folding Rangefinder")]
        [Display(Name = "Folding Rangefinder")]
        RangefinderFolder,
        Viewfinder,
        [Description("Folding Viewfinder")]
        [Display(Name = "Folding Viewfinder")]
        ViewFinderFolder,
        Compact,
        Subminiature,
        Mirrorless,
        [Description("Twin Lens Reflex")]
        [Display(Name = "Twin Lens Reflex")]
        TwinLensReflex,
        Box,
        Stereo,
        [Description("View Camera")]
        [Display(Name = "View Camera")]
        ViewCamera,
        Movie,
        Other
    }
    public enum ImageCategoryEnum
    {
        Camera,
        Lens,
        Accessory,
        Other
    }
    public enum CountriesEnum
    {
        Unknown,
        Argentina,
        Australia, 
        Austria, 
        Belarus,
        Belgium, 
        Brasil, 
        Bulgaria, 
        Canada, 
        China,
        [Description("Czech Republic")]
        [Display(Name = "Czech Republic")]
        CzechRepublic,
        Denmark,
        [Description("East Germany DDR")]
        [Display(Name = "East Germany DDR")]
        EastGermany,
        Finland, 
        France,
        Germany,
        [Description("Great Britain")]
        [Display(Name = "Great Britain")]
        GreatBritain,
        [Description("Hong Kong")]
        [Display(Name = "Hong Kong")]
        HongKong,
        Hungary,
        India,
        Italy, 
        Ireland,
        Japan,
        Latvia, 
        Liechtenstein,
        Monaco,
        Morocco, 
        Mexico, 
        Netherlands,
        [Description("New Zealand")]
        [Display(Name = "New Zealand")]
        NewZealand, 
        Poland,
        Romania, 
        Russia, 
        Singapore,
        Slovakia,
        [Description("South Korea")]
        [Display(Name = "South Korea")]
        SouthKorea, 
        Spain,
        Sweden,
        Switzerland,
        [Description("Taiwan ROC")]
        [Display(Name = "Taiwan Roc")]
        Taiwan, 
        Ukraine, 
        Uruguay,
        [Description("United States of America")]
        [Display(Name = "United States of America")]
        USA,
        [Description("Soviet Union CCCP")]
        [Display(Name = "Soviet Union CCCP")]
        USSR,
        [Description("West Germany")]
        [Display(Name = "West Germany")]
        WestGermany

    }
}