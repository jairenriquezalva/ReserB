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
    public class SectorController : ControllerBase
    {
		ISectorRepository _sectorRepository;

		public SectorController(ISectorRepository customerRepository)
		{
			_sectorRepository = customerRepository;
		}

		public async Task<ActionResult> GetSectors()
		{
			var sectors = await _sectorRepository.GetAll();
			return new JsonResult(sectors);
		}
	}
}