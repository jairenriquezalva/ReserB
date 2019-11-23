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
		IProviderRepository _providerRepository;
		public LoginService(ICustomerRepository customerRepository, IProviderRepository providerRepository)
		{
			_customerRepository = customerRepository;
			_providerRepository = providerRepository;
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

		async public Task<Provider> LoginProvider(string email, string password)
		{
			var provider = await _providerRepository.GetByEmail(email);
			if(provider != null)
			{
				if (password == provider.Password)
					return provider;
				return new Provider() { Id = "0" };
			}
			else
			{
				return new Provider() { Id = "-1" };
			}
		}
	}
}
