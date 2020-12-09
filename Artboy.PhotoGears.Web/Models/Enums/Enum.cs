using System;
using System.ComponentModel;

namespace Artboy.PhotoGears.Web.Models
{
    public enum StatusEnum
    {
        [Description("New")]
        AsNew,
        Used,
        [Description("Has Issue")]
        HasIssue,
        [Description("As Parts")]
        AsParts
    }
    public enum MountTypeEnum
    {
        Screw,
        Bayonet,
        [Description("Breech Lock")]
        BreechLock,
        [Description("Double Bayonet")]
        DoubleBayonet,
        Fixed
    }
    public enum FocusingTypeEnum
    {
        Auto,
        Manual,
        [Description("Manual Zone")]
        ManualZone,
        Fixed  
    }
   
    public enum ImageTypeEnum
    {
        [Description("Roll Film")]
        RollFilm,
        [Description("Plate Film")]
        PlateFilm,
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
        WideAngle,
        Specialty,
        Other
    }
    public enum CameraTypeEnum
    {
        [Description("Single Lens Reflex")]
        SingleLensReflex,
        Rangefinder,
        Viewfinder,
        Compact,
        Miniature,
        Mirrorless,
        [Description("Twin Lens Reflex")]
        TwinLensReflex,
        Stereo,
        Plate,
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
        CzechRepublic,
        Denmark,
        [Description("East Germany DDR")]
        EastGermany,
        Finland, 
        France,
        Germany,
        [Description("Great Britian")]
        GreatBritian,
        [Description("Hong Kong")]
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
        NewZealand, 
        Poland,
        Romania, 
        Russia, 
        Singapore,
        Slovakia,
        [Description("South Korea")]
        SouthKorea, 
        Spain,
        Sweden,
        Switzerland,
        [Description("Taiwan ROC")]
        Taiwan, 
        Ukraine, 
        Uruguay,
        [Description("United States of America")]
        USA,
        [Description("Soviet Union CCCP")]
        USSR,
        [Description("West Germany")]
        WestGermany

    }
}