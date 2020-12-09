using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artboy.PhotoGears.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Artboy.PhotoGears.Web.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class AccessoryController : ControllerBase
    {
        private IAccessoryRepository repository;
        public AccessoryController(IAccessoryRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAccessories()
        {
            var result = await repository.GetAccessories();
            if(result== null || result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAccessory(long id)
        {
            Accessory accessory = await repository.GetAccessory(id);
            if(accessory == null)
            {
                return NotFound();
            }
            return Ok(accessory);
        }
    }
}
