using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserB.Models;
using ReserB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{

		ICustomerRepository _customerRepository; 

		public CustomerController(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		[HttpGet]
		async public Task<ActionResult> GetCustomers()
		{
			var customers = await _customerRepository.GetAll();
			var response = customers.Select(customer => new { customer.Id, customer.EMail, customer.Forenames, customer.Surnames, customer.Birthdate });
			return new JsonResult(response); 
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetCustomer(string id)
		{
			var customer = await _customerRepository.Get(id);
			return new JsonResult(new { customer.Id, customer.EMail, customer.Forenames, customer.Surnames, customer.Birthdate });
		}

		[HttpPost]
		public async Task<ActionResult> InsertCustomer(Customer customer)
		{
			var existingCustomer = await _customerRepository.GetByEmail(customer.EMail);
			if (existingCustomer == null)
			{
				await _customerRepository.InsertOne(customer);
				return StatusCode(StatusCodes.Status201Created);
			}
			return StatusCode(StatusCodes.Status403Forbidden);
		}
	}
}
