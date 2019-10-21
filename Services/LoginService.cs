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
		async public Task<bool> Login(string email, string password)
		{
			var expectedPassword = await _customerRepository.GetPassword(email);
			if(password == expectedPassword)
				return true;
			return false;
		}
	}
}
