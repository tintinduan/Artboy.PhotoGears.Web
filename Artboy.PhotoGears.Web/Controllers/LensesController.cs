using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models;
using Artboy.PhotoGears.Models.ViewModels;

namespace Artboy.PhotoGears.Web.Controllers
{
    public class LensesController : Controller
    {
        private ILensRepository repository;
        public int Page { get; set; }
        public LensesController(ILensRepository repository)
        {
            this.repository = repository;
            Page = 1;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,
            string searchString, string lensType, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CountrySortParm"] = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewData["MakerSortParm"] = (String.IsNullOrEmpty(sortOrder) || sortOrder == "maker")
                                ? "maker_desc" : "maker";
            int pageSizeIn = 5;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var result = await repository.GetLenses();
            if (!String.IsNullOrEmpty(searchString))
            {
                if (!String.IsNullOrEmpty(lensType))
                {
                    LensTypeEnum lenType = (LensTypeEnum)Enum.Parse(typeof(LensTypeEnum), lensType);

                    result = result.Where(s => (s.Model.ToUpper().Contains(searchString.ToUpper()) ||
                      s.Maker.ToUpper().Contains(searchString.ToUpper()) ||
                      s.Brand.ToUpper().Contains(searchString.ToUpper())) &&
                      (s.LensType == lenType));
                }
                else
                {
                    result = result.Where(s => s.Model.ToUpper().Contains(searchString.ToUpper()) ||
                     s.Maker.ToUpper().Contains(searchString.ToUpper()) ||
                     s.Brand.ToUpper().Contains(searchString.ToUpper()));
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(lensType))
                {
                    LensTypeEnum lenType = (LensTypeEnum)Enum.Parse(typeof(LensTypeEnum), lensType);
                    result = result.Where(s => s.LensType == lenType);
                }
            }
            switch (sortOrder)
            {
                case "country_dec":
                    result = result.OrderByDescending(r => r.MadeInCountry);
                    break;
                case "maker":
                    result = result.OrderBy(r => r.Maker);
                    break;
                case "maker_desc":
                    result = result.OrderByDescending(r => r.Maker);
                    break;
                case "":
                case null:
                    result = result.OrderBy(r => r.MadeInCountry);
                    break;
            }
            //if (pageSize != null)
            //{
            //    pageSizeIn = Convert.ToInt32(pageSize);
            //}

            var lensesListVM = ViewModelFactory.LensesList(result, lensType, pageNumber, pageSizeIn);
            return View(lensesListVM);
        }

        // GET: HomeController1/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Lens lens = await repository.GetLens(id);
            if (lens != null)
            {
                LensViewModel model = ViewModelFactory.LensDetails(lens);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
