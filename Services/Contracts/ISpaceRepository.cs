using ReserB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services.Contracts
{
	public interface ISpaceRepository
	{
		Task InsertOne(Space space);
		Task<List<Space>> GetByProvider(string providerId);
		Task<List<Space>> GetByCategory(string id);
	}
}
