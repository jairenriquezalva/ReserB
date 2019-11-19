using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Attributes;
using ReserB.Models;
using ReserB.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserB.Services
{
	public class SectorRepository : GenericRepository<Sector, SectorBson>, ISectorRepository
	{
		public SectorRepository(IConfiguration configuration, string collectionName) : base(configuration, collectionName)
		{
		}

	}

	public class SectorBson : BsonTypeBase<Sector>
	{
		[BsonElement("nombre")]
		public string Name { get; set; }
		[BsonElement("imagen")]
		public string Image { get; set; }

		[BsonElement("alquilerDuracion")]
		public float ReserveDuration { get; set; }
		public override Sector GetBase()
		{
			return new Sector() { Id = Id, Name = Name,Image = Image,  ReserveDuration = ReserveDuration };
		}

		public override void SetBase(Sector baseObject)
		{
			Id = baseObject.Id;
			Name = baseObject.Name;
			Image = baseObject.Image;
			ReserveDuration = baseObject.ReserveDuration;
		}
	}
}
