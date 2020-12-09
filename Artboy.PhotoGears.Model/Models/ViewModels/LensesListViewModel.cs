using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models.Helpers;

namespace Artboy.PhotoGears.Models.ViewModels
{
    public class LensesListViewModel
    {
        public string LensType { get; set; }
        public int PageSize { get; set; }
        public PaginatedList<Lens> Lenses { get; set; }
    }
}
