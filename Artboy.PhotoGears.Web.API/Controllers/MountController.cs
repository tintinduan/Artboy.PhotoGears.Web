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
    //[Authorize(AuthenticationSchemes = "Identity.Application, Bearer")]
    public class MountController : ControllerBase
    {
        private IMountRepository repository;
        public MountController(IMountRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetMounts()
        {
            var result = await repository.GetMounts();
            if(result == null || result.Count() ==0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetMount(int id)
        {
            Mount mount = await repository.GetMount(id);
            if (mount == null)
            {
                return NotFound();
            }
            return Ok(mount);
        }
    }
}
