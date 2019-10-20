using ReserB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services
{
	public interface IClientRepository
	{
		Task<IEnumerable<Client>> GetAll();
		Task InsertOne(Client client);
		Task<Client> Get(string id);
	}
}
