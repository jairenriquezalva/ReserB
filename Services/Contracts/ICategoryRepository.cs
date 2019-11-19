using ReserB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services.Contracts
{
	public interface ICategoryRepository
	{
		Task<List<Category>> GetBySector(string idSector);
	}
}
