#pragma checksum "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\Shared\_GearBasicPhysicalSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fc5a89d5bd7ee4f44591fbdd1ff34f2ae9d4c5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GearBasicPhysicalSummary), @"mvc.1.0.view", @"/Views/Shared/_GearBasicPhysicalSummary.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\_ViewImports.cshtml"
using Artboy.PhotoGears.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\_ViewImports.cshtml"
using Artboy.PhotoGears.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\_ViewImports.cshtml"
using Artboy.PhotoGears.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\_ViewImports.cshtml"
using Artboy.PhotoGears.Web.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\_ViewImports.cshtml"
using Artboy.PhotoGears.Models.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fc5a89d5bd7ee4f44591fbdd1ff34f2ae9d4c5e", @"/Views/Shared/_GearBasicPhysicalSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7d36ea2e02773bcd681b46c72e1c4292b4a7092", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__GearBasicPhysicalSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PhotoGear>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col\">\r\n            <label class=\"font-weight-bolder\">Dimensions: </label> <a>");
#nullable restore
#line 5 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\Shared\_GearBasicPhysicalSummary.cshtml"
                                                                 Write(Model.Dimensions);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        </div>\r\n        <div class=\"col\">\r\n            <label class=\"font-weight-bolder\">Wight: </label> <a>");
#nullable restore
#line 8 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\Shared\_GearBasicPhysicalSummary.cshtml"
                                                            Write(Model.Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        </div>\r\n        <div class=\"col\">\r\n            <label class=\"font-weight-bolder\">Status: </label> <a>");
#nullable restore
#line 11 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\Shared\_GearBasicPhysicalSummary.cshtml"
                                                             Write(Model.Status.GetDescription());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col\">\r\n            <label class=\"font-weight-bolder\">Comments: </label>\r\n            <p>\r\n                <textarea cols=\"120\" disabled>");
#nullable restore
#line 18 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Views\Shared\_GearBasicPhysicalSummary.cshtml"
                                         Write(Model.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</textarea>\r\n            </p>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PhotoGear> Html { get; private set; }
    }
}
#pragma warning restore 1591
