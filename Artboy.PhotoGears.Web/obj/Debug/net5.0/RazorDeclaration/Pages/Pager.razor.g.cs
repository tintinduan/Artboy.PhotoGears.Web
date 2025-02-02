// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Artboy.PhotoGears.Web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Artboy.PhotoGears.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Artboy.PhotoGears.Models.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\_Imports.razor"
using Artboy.PhotoGears.Web.Pages;

#line default
#line hidden
#nullable disable
    public partial class Pager : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Pager.razor"
       
    [Parameter]
    public PagedResultBase Result { get; set; }

    [Parameter]
    public Action<int> PageChanged { get; set; }

    protected int StartIndex { get; private set; } = 0;
    protected int FinishIndex { get; private set; } = 0;

    protected override void OnParametersSet()
    {
        StartIndex = Math.Max(Result.CurrentPage - 5, 1);
        FinishIndex = Math.Min(Result.CurrentPage + 5, Result.PageCount);

        base.OnParametersSet();
    }

    protected void PagerButtonClicked(int page)
    {
        PageChanged?.Invoke(page);
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
