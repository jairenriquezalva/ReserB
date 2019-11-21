using ReserB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services.Contracts
{
	public interface IReservationRepository
	{
		Task<IEnumerable<Reservation>> GetAll();
		Task InsertOne(Reservation customer);
		Task<Reservation> Get(string id);
		Task<IEnumerable<Reservation>> GetByCustomer(string id);
		Task<IEnumerable<Reservation>> GetBySpace(string id);
	}
}
