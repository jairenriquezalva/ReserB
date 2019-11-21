using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserB.Models;
using ReserB.Services.Contracts;

namespace ReserB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
		ISpaceRepository _spaceRepository;

		public SpaceController(ISpaceRepository spaceRepository)
		{
			_spaceRepository = spaceRepository;
		}

		[HttpPost]
		public async Task<ActionResult> InsertSpace(Space customer)
		{
			await _spaceRepository.InsertOne(customer);
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet("provider/{id}")]
		public async Task<ActionResult> GetSpaceByProvider(string id)
		{
			var customer = await _spaceRepository.GetByProvider(id);
			return new JsonResult(customer);
		}

		[HttpGet("category/{id}")]
		public async Task<ActionResult> GetSpaceByCategory(string id)
		{
			var customer = await _spaceRepository.GetByCategory(id);
			return new JsonResult(customer);
		}
	}
}