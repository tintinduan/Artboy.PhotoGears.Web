using Artboy.PhotoGears.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models.ViewModels
{
    public static class ViewModelFactory
    {
        public static CameraViewModel CameraDetails(Camera camera) => new CameraViewModel
        {
            Camera = camera,
            Action = "Details",
            ReadOnly = true,
            Theme = "info",
            ShowAction = false,
            Mount = camera == null ? new Mount()
                    : camera.LensMount,
            Images = camera == null ? Enumerable.Empty<GearImage>()
                    : camera.Images,
            AssociatedLens = camera == null ? new Lens() : 
                (camera.AssociatedLens == null ? new Lens() : camera.AssociatedLens)
        };
        public static LensViewModel LensDetails(Lens lens) => new LensViewModel
        {
            Lens = lens,
            Action = "Details",
            ReadOnly = true,
            Theme = "info",
            ShowAction = false,
            Mount = lens == null ? new Mount()
                    : lens.LensMount,
            Images = lens == null ? Enumerable.Empty<GearImage>()
                    : lens.Images
        };
        public static AccessoryViewModel AccessoryDetails(Accessory accessory) => new AccessoryViewModel
        {
            Accessory = accessory,
            Action = "Details",
            ReadOnly = true,
            Theme = "info",
            ShowAction = false,
            Images = accessory == null ? Enumerable.Empty<GearImage>()
                    : accessory.Images
        };
        public static CamerasListViewModel CamerasList(IEnumerable<Camera> cameras,string cameraType,int? page,int pageSize) 
            => new CamerasListViewModel
                {
                    CameraType = cameraType,
                    PageSize = pageSize,
                    Cameras = PaginatedList<Camera>.Create(cameras.AsQueryable(), page ?? 1, pageSize)
            };
        public static LensesListViewModel LensesList(IEnumerable<Lens> lenses, string lensType, int? page, int pageSize)
            => new LensesListViewModel
            {
                LensType = lensType,
                PageSize = pageSize,
                Lenses = PaginatedList<Lens>.Create(lenses.AsQueryable(), page ?? 1, pageSize)
            };
        public static AccessoriesListViewModel AccessoriesList(IEnumerable<Accessory> accessories, int? page, int pageSize)
            => new AccessoriesListViewModel
            {
                PageSize = pageSize,
                Accessories = PaginatedList<Accessory>.Create(accessories.AsQueryable(), page ?? 1, pageSize)
            };

       
    }
}
