using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Artboy.PhotoGears.Models;
using Microsoft.AspNetCore.Authorization;

namespace Artboy.PhotoGears.Web.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class LensController : ControllerBase
    {
        private IGenericRepository<Lens> repository;
        public LensController(IGenericRepository<Lens> repo)
        {
            repository = repo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetLens()
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
        public async Task<IActionResult>GetLens(long id)
        {
            Lens lens = await repository.GetOneAsync(id);
            if(lens == null)
            {
                return NotFound();
            }
            return Ok(lens);
        }
    }
}
