using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using ReserB.Models;
using ReserB.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services
{
	public class ReservationRepository : GenericRepository<Reservation, ReservationBson>, IReservationRepository
	{
		public ReservationRepository(IConfiguration configuration, string collectionName) : base(configuration, collectionName)
		{
		}

		public async Task<IEnumerable<Reservation>> GetByCustomer(string idCustomer)
		{
			var reservations = await collection.Find((b => b.Customer == idCustomer)).ToListAsync<ReservationBson>();
			return reservations.Select(res => res.GetBase()).ToList();
		}

		public async Task<IEnumerable<Reservation>> GetBySpace(string idSpace)
		{
			var reservations = await collection.Find((b => b.Space == idSpace)).ToListAsync<ReservationBson>();
			return reservations.Select(res => res.GetBase()).ToList();
		}
	}

	public class ReservationBson : BsonTypeBase<Reservation>
	{
		[BsonElement("espacio")]
		public string Space { get; set; }
		[BsonElement("cliente")]
		public string Customer { get; set; }
		[BsonElement("creado")]
		public string CreatedAt { get; set; }
		[BsonElement("metodoPago")]
		public int PaymentMethod { get; set; }
		[BsonElement("horario")]
		public Tuple<string, int[]> Time { get; set; }

		public override Reservation GetBase()
		{
			return new Reservation()
			{
				Id = Id,
				Space = Space,
				Customer = Customer,
				CreatedAt = CreatedAt,
				PaymentMethod = PaymentMethod,
				Time = Time
			};
		}

		public override void SetBase(Reservation baseObject)
		{
			Id = baseObject.Id;
			Space = baseObject.Space;
			Customer = baseObject.Customer;
			CreatedAt = baseObject.CreatedAt;
			PaymentMethod = baseObject.PaymentMethod;
			Time = baseObject.Time;
		}
	}
}
