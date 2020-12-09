using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models;
using Artboy.PhotoGears.Models.Helpers;

namespace Artboy.PhotoGears.Models.ViewModels
{
    public class CamerasListViewModel
    {
        public string CameraType { get; set; }
        public int PageSize { get; set; }
        public PaginatedList<Camera> Cameras { get; set; }
    }
}
