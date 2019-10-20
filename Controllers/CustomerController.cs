using Microsoft.AspNetCore.Mvc;
using ReserB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Controllers
{
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{

		ICustomerRepository _customerRepository; 

		public CustomerController(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		[HttpGet]
		async public Task<ActionResult> GetCliente()
		{
			var clientes = await _customerRepository.GetAll();
			return new JsonResult(clientes); 
		}
	}
}
