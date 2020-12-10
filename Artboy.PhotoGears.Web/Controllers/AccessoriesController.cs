using Artboy.PhotoGears.Models;
using Artboy.PhotoGears.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artboy.PhotoGears.Web.Controllers
{
    public class AccessoriesController : Controller
    {
        private IGenericRepository<Accessory> repository;
        public int Page { get; set; }
        public AccessoriesController(IGenericRepository<Accessory> repository)
        {
            this.repository = repository;
            Page = 1;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,
            string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CountrySortParm"] = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewData["MakerSortParm"] = (String.IsNullOrEmpty(sortOrder) || sortOrder == "maker")
                                ? "maker_desc" : "maker";
            ViewData["TypeSortParm"] = (String.IsNullOrEmpty(sortOrder) || sortOrder == "type")
                                ? "type_desc" : "type";
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

            var result = await repository.GetAllAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
               result = result.Where(s => s.Model.ToUpper().Contains(searchString.ToUpper()) ||
               s.Maker.ToUpper().Contains(searchString.ToUpper()) ||
               s.Brand.ToUpper().Contains(searchString.ToUpper()) ||
               s.AccessoryType.ToUpper().Contains(searchString.ToUpper()));
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
                case "type":
                    result = result.OrderBy(r => r.AccessoryType);
                    break;
                case "type_desc":
                    result = result.OrderByDescending(r => r.AccessoryType);
                    break;
                case "":
                    result = result.OrderBy(r => r.MadeInCountry);
                    break;
            }
            //if (pageSize != null)
            //{
            //    pageSizeIn = Convert.ToInt32(pageSize);
            //}

            var lensesListVM = ViewModelFactory.AccessoriesList(result, pageNumber, pageSizeIn);
            return View(lensesListVM);
        }

        // GET: HomeController1/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Accessory accessory = await repository.GetOneAsync(id);
            if (accessory != null)
            {
                AccessoryViewModel model = ViewModelFactory.AccessoryDetails(accessory);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
