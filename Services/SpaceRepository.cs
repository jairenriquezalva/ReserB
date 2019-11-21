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
	public class SpaceRepository : GenericRepository<Space, SpaceBson>, ISpaceRepository
	{
		public SpaceRepository(IConfiguration configuration, string collectionName) : base(configuration, collectionName)
		{
		}
		public async Task<List<Space>> GetByCategory(string idCategory)
		{
			var spaces = await collection.Find((b => b.Category == idCategory)).ToListAsync<SpaceBson>();
			return spaces.Select(cat => cat.GetBase()).ToList();
		}

		public async Task<List<Space>> GetByProvider(string idProvider)
		{
			var spaces = await collection.Find((b => b.Provider == idProvider)).ToListAsync<SpaceBson>();
			return spaces.Select(cat => cat.GetBase()).ToList();
		}
	}

	public class SpaceBson : BsonTypeBase<Space>
	{
		[BsonElement("proveedor")]
		public string Provider { get; set; }
		[BsonElement("categoria")]
		public string Category { get; set; }
		[BsonElement("nombre")]
		public string Name { get; set; }
		[BsonElement("fotos")]
		public string[] Photos { get; set; }
		[BsonElement("precio")]
		public float Price { get; set; }
		[BsonElement("horarioDisponible")]
		public int[][] Schedule { get; set; }
		[BsonElement("horario")]
		public List<Tuple<string, int[]>> BookingSchedule { get; set; }
		
		public override Space GetBase()
		{
			return new Space() { Id = Id, Name = Name, Provider = Provider, Category = Category, Photos = Photos, Price = Price, Schedule = Schedule, BookingSchedule = BookingSchedule };
		}

		public override void SetBase(Space baseObject)
		{
			Id = baseObject.Id;
			Name = baseObject.Name;
			Provider = baseObject.Provider;
			Category = baseObject.Category;
			Photos = baseObject.Photos;
			Price = baseObject.Price;
			Schedule = baseObject.Schedule;
			BookingSchedule = baseObject.BookingSchedule;
		}
	}
}
