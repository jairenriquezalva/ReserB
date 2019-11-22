using ReserB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services
{
	public class LoginService
	{
		ICustomerRepository _customerRepository;
		public LoginService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}
		async public Task<Customer> Login(string email, string password)
		{
			var user = await _customerRepository.GetByEmail(email);
			if(user != null)
			{
				if (password == user.Password)
					return user;
				return new Customer() {Id = "0" };
			}
			else
			{
				return new Customer() { Id = "-1" };
			}
			
		}
	}
}
