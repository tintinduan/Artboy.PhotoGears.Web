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
    public class CameraController : ControllerBase
    {
        private IGenericRepository<Camera> repository;
        public CameraController(IGenericRepository<Camera> repo)
        {
            repository = repo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCameras()
        {
            var result = await repository.GetAllAsync();
            if(result == null || result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCamera(long id)
        {
            Camera c = await repository.GetOneAsync(id);
            if(c==null)
            {
                return NotFound();
            }
            return Ok(c);
        }
        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(GetCamera), new { Id = 1 });
        }

    }
}
