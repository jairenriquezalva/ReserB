using ReserB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services
{
	public interface ICustomerRepository
	{
		Task<IEnumerable<Customer>> GetAll();
		Task InsertOne(Customer customer);
		Task<Customer> Get(string id);
	}
}
