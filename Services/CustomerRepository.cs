using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReserB.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReserB.Services
{
	public class CustomerRepository : GenericRepository<Customer, CustomerBson>, ICustomerRepository
	{
		public CustomerRepository(IConfiguration configuration, string collectionName) : base(configuration, collectionName)
		{
		}

		public async Task<Customer> GetByEmail(string eMail)
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

	public class CustomerBson : BsonTypeBase<Customer>
	{
		
		[BsonElement("email")]
		public string EMail { get; set; }
		[BsonElement("contraseña")]
		public string Password { get; set; }
		[BsonElement("nombres")]
		public string Forenames { get; set; }
		[BsonElement("apellidos")]
		public string Surnames { get; set; }
		[BsonElement("fechaNacimiento")]
		public DateTime Birthdate { get; set; }
		public override Customer GetBase() {
			return new Customer() { Id = this.Id, EMail = this.EMail, Password = this.Password, Forenames = this.Forenames, Surnames = this.Surnames, Birthdate = this.Birthdate };
		}
		public override void SetBase(Customer customer)
		{
			Id = customer.Id;
			EMail = customer.EMail;
			Password = customer.Password;
			Forenames = customer.Forenames;
			Surnames = customer.Surnames;
			Birthdate = customer.Birthdate;
		}
	}
}
