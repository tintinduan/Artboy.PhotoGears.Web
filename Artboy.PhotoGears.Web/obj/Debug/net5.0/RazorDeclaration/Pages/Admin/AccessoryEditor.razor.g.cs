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
    public partial class AccessoryEditor : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 137 "C:\CodeBase\Projects\Artboy.PhotoGears.Web\Artboy.PhotoGears.Web\Pages\Admin\AccessoryEditor.razor"
       
    [Inject]
    public IAccessoryRepository AccessoryRepository { get; set; }
    [Inject]
    public NavigationManager NavManager { get; set; }
    [Parameter]
    public long Id { get; set; } = 0;
    public Accessory Accessory { get; set; } = new Accessory();
    [Parameter]
    public IEnumerable<Mount> Mounts { get; set; }
    [Parameter]
    public IEnumerable<GearImage> Images { get; set; }


    public bool ShowDialog
    {
        get;
        set;
    }
    public void Show()
    {
        InitDialog();
        ShowDialog = true;
        StateHasChanged();
    }
    public void Close()
    {
        ResetDialog();

        ShowDialog = false;
        StateHasChanged();
    }
    private void InitDialog()
    {
        if (Id == 0)
        {
            Accessory = new Accessory();
        }
    }
    private void ResetDialog()
    {
        AccessoryRepository.RejectChanges();

    }
  
    protected void ImageCheckChanged(MouseEventArgs e, GearImage image)
    {
        if (!image.IsUsed)
        {
            if (Accessory.Images == null)
            {
                Accessory.Images = new List<GearImage>();
            }
            Accessory.Images.Add(image);
        }
    }

    protected async override Task OnParametersSetAsync()
    {
        if (Id != 0)
        {
            Accessory = await AccessoryRepository.GetAccessory(Id);
        }

    }
    protected async Task SaveAccessory()
    {
        if (Accessory.Images != null && Accessory.Images.Count > 0)
        {
            foreach (GearImage img in Accessory.Images)
            {
                if (img.IsUsed == false)
                {
                    Accessory.Images.Remove(img);
                }
            }
        }
        if (Id == 0)
        {
            await AccessoryRepository.CreateAccessory(Accessory);
        }
        else
        {
            await AccessoryRepository.UpdateAccessory(Accessory);
        }

        ShowDialog = false;
        StateHasChanged();
        NavManager.NavigateTo("/admin/accessories", true);
    }

    public string ThemeColor => Id == 0 ? "primary" : "warning";
    public string TitleText => Id == 0 ? "Create" : "Edit";

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
