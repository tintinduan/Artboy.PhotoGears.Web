using Artboy.PhotoGears.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Models.ViewModels
{
    public class AccessoriesListViewModel
    {
        public int PageSize { get; set; }
        public PaginatedList<Accessory> Accessories { get; set; }
    }
}
