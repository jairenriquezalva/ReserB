using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserB.Models;
using ReserB.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserB.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProviderController : ControllerBase
	{
		IProviderRepository _providerRepository;

		public ProviderController(IProviderRepository providerRepository)
		{
			_providerRepository = providerRepository;
		}

		[HttpGet]
		public async Task<ActionResult> GetProviders()
		{
			var providers = await _providerRepository.GetAll();
			return new JsonResult(providers);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetProvider(string id)
		{
			var provider = await _providerRepository.Get(id);
			return new JsonResult(new { provider.Id, provider.EMail, provider.Forenames, provider.Surnames, provider.BusinessName, provider.Tradename, provider.Image, provider.Address, provider.RUC,provider.Phone, provider.Sector, provider.Schedule });
		}

		[HttpPost]
		public async Task<IActionResult> InsertProvider(Provider provider)
		{
			var existingProvider = await _providerRepository.GetByEmail(provider.EMail);
			if (existingProvider == null)
			{
				await _providerRepository.InsertOne(provider);
				return StatusCode(StatusCodes.Status201Created);
			}
			return StatusCode(StatusCodes.Status403Forbidden);
		}

		public IActionResult Index()
		{
			return new JsonResult(".");
		}

	}
}
