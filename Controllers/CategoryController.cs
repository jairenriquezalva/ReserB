using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserB.Services.Contracts;

namespace ReserB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
		ICategoryRepository _categoryRepository;

		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetSectors(string id)
		{
			var sectors = await _categoryRepository.GetBySector(id);
			return new JsonResult(sectors);
		}
	}
}