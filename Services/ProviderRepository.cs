using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using ReserB.Models;

namespace ReserB.Services
{
	public class ProviderRepository : GenericRepository<Provider, ProviderBson>, IProviderRepository
	{
		public ProviderRepository(IConfiguration configuration, string collectionName) : base(configuration, collectionName)
		{
		}

		public async Task<Provider> GetByEmail(string eMail)
		{
			var document = await collection.Find((b => b.EMail == eMail)).FirstOrDefaultAsync();
			return document?.GetBase();
		}

		public async Task<string> GetPassword(string eMail)
		{
			var document = await collection.Find((b => b.EMail == eMail)).FirstOrDefaultAsync();
			return document.Password;
		}
	}

	public class ProviderBson : BsonTypeBase<Provider>
	{
		[BsonElement("email")]
		public string EMail { get; set; }
		[BsonElement("contraseña")]
		public string Password { get; set; }
		[BsonElement("nombres")]
		public string Forenames { get; set; }
		[BsonElement("apellidos")]
		public string Surnames { get; set; }
		[BsonElement("razonSocial")]
		public string BusinessName { get; set; }
		[BsonElement("nombreComercial")]
		public string Tradename { get; set; }
		[BsonElement("imagen")]
		public string Image { get; set; }
		[BsonElement("direccion")]
		public double[] Address { get; set; }
		[BsonElement("ruc")]
		public string RUC { get; set; }
		[BsonElement("telefono")]
		public string Phone { get; set; }
		[BsonElement("rubro")]
		public string Sector { get; set; }
		[BsonElement("horario")]
		public int[][] Schedule { get; set; }
		public override Provider GetBase()
		{
			return new Provider()
			{
				Id = Id,
				EMail = EMail,
				Password = Password,
				Forenames = Forenames,
				Surnames = Surnames,
				BusinessName = BusinessName,
				Tradename = Tradename,
				Image = Image,
				Address = Address,
				RUC = RUC,
				Phone = Phone,
				Sector = Sector,
				Schedule = Schedule
			};
		}

		public override void SetBase(Provider providerBase)
		{
			this.EMail = providerBase.EMail;
			this.Password = providerBase.Password;
			this.Forenames = providerBase.Forenames;
			this.Surnames = providerBase.Surnames;
			this.BusinessName = providerBase.BusinessName;
			this.Tradename = providerBase.Tradename;
			this.Image = providerBase.Image;
			this.Address = providerBase.Address;
			this.RUC = providerBase.RUC;
			this.Phone = providerBase.Phone;
			this.Sector = providerBase.Sector;
			this.Schedule = providerBase.Schedule;
		}
	}
}
