// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Artboy.PhotoGears.Web.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Artboy.PhotoGears.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Artboy.PhotoGears.Models.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Artboy.PhotoGears.Web.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/mounts/")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/mounts/page/{Page:int}")]
    public partial class MountsList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\MountsList.razor"
       
    [Inject]
    public IMountRepository Repository { get; set; }
    [Inject]
    public NavigationManager NavManager { get; set; }
    [Parameter]
    public int Page { get; set; } = 1;
    public PageResult<Mount> MountData { get; set; } = new PageResult<Mount>();
    public Mount SelectedMount { get; set; } = new Mount();
    public MountEditor EditorDialog { get; set; }
    public Confirm ConfirmDialog { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Page = (Page == 0) ? 1 : Page;
        await UpdateData();
    }
    public async Task UpdateData()
    {
        MountData = await Repository.ListMounts(Page,10);
    }
    protected async Task EditMount(MouseEventArgs e, int mountId)
    {
        if (mountId != 0)
        {
            SelectedMount = await Repository.GetMount(mountId);
        }
        else
        {
            SelectedMount = new Mount();
        }
        EditorDialog.Show();
    }
    protected async Task Delete_Click(MouseEventArgs e, int mountId)
    {
        SelectedMount = await Repository.GetMount(mountId);
        ConfirmDialog.Show();
    }
    public async Task ConfirmDelete_Click(bool deleteConfirmed)
    {
        if (deleteConfirmed)
        {
            await Repository.DeleteMount(SelectedMount);
            await UpdateData();
        }
    }
    protected void PagerPageChanged(int page)
    {
        NavManager.NavigateTo("/admin/mounts/page/" + page,true);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
