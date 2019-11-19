using ReserB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services
{
	public interface IProviderRepository
	{
		Task<IEnumerable<Provider>> GetAll();
		Task InsertOne(Provider customer);
		Task<Provider> Get(string id);
		Task<string> GetPassword(string eMail);
		Task<Provider> GetByEmail(string eMail);
	}
}
