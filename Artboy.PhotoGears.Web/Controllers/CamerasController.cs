using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models;
using Artboy.PhotoGears.Models.ViewModels;
using Artboy.PhotoGears.Models.Helpers;

namespace Artboy.PhotoGears.Web.Controllers
{
    public class CamerasController : Controller
    {
        private ICameraRepository repository;
        public int Page { get; set; } 
        public CamerasController(ICameraRepository repository)
        {
            this.repository = repository;
            Page = 1;
        }
        public async Task<IActionResult> Index(string sortOrder,string currentFilter,
            string searchString,string cameraType, int?pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CountrySortParm"] = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewData["MakerSortParm"] = (String.IsNullOrEmpty(sortOrder) || sortOrder == "maker")
                                ? "maker_desc" : "maker";

            int pageSizeIn = 5;
            //if (pageSize != null)
            //{
            //    pageSizeIn = Convert.ToInt32(pageSize);
            //}

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            { 
                searchString = currentFilter; 
            }
            ViewData["CurrentFilter"] = searchString;

            var result = await repository.GetCameras();
            if(!String.IsNullOrEmpty(searchString))
            {
                if (!String.IsNullOrEmpty(cameraType))
                {
                    CameraTypeEnum camType = (CameraTypeEnum)Enum.Parse(typeof(CameraTypeEnum), cameraType);

                    result = result.Where(s => (s.Model.ToUpper().Contains(searchString.ToUpper()) ||
                      s.Maker.ToUpper().Contains(searchString.ToUpper()) ||
                      s.Brand.ToUpper().Contains(searchString.ToUpper())) &&
                      (s.CameraType == camType));
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
                if (!String.IsNullOrEmpty(cameraType))
                {
                    CameraTypeEnum camType = (CameraTypeEnum)Enum.Parse(typeof(CameraTypeEnum), cameraType);
                    result = result.Where(s => s.CameraType == camType);
                }
            }
            switch(sortOrder)
            {
                case "country_dec":
                    result = result.OrderByDescending(r => r.MadeInCountry);
                    break;
                case "maker":
                    result = result.OrderBy(r=>r.Maker);
                    break;
                case "maker_desc":
                    result = result.OrderByDescending(r => r.Maker);
                    break;
                case "":
                case null:
                    result = result.OrderBy(r => r.MadeInCountry);
                    break;
            }
            
            
            var camerasListVM = ViewModelFactory.CamerasList(result, cameraType, pageNumber, pageSizeIn);
            return View(camerasListVM);
        }

        // GET: HomeController1/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Camera camera = await repository.GetCamera(id);
            if (camera != null)
            {
                CameraViewModel model = ViewModelFactory.CameraDetails(camera);
                return View(model);
            }
            else 
            {
                return NotFound();
            }
        }

    }
}
