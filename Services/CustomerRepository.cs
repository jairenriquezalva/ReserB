using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReserB.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ReserB.Services
{
	public class CustomerRepository : ICustomerRepository
	{
		IMongoCollection<BsonDocument> customersCollection;

		public CustomerRepository(IConfiguration configuration)
		{
			IMongoClient client = new MongoClient(configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"));
			IMongoDatabase database = client.GetDatabase(configuration.GetSection("MongoDB").GetValue<string>("Database"));
			customersCollection = database.GetCollection<BsonDocument>("cliente");
		}

		async public Task<Customer> Get(string id)
		{
			Customer customer = new Customer();
			var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
			var customerBson = await customersCollection.Find(filter).FirstAsync();
			customer.Id = customerBson["_id"].AsString;
			customer.EMail = customerBson["email"].AsString;
			customer.Password = customerBson["contraseña"].AsString;
			customer.Forenames = customerBson["nombres"].AsString;
			customer.Surnames = customerBson["apellidos"].AsString;
			customer.Birthdate = customerBson["fechaNacimiento"].ToUniversalTime();
			return customer;
		}

		async public Task<IEnumerable<Customer>> GetAll()
		{
			var documents = await customersCollection.Find(new BsonDocument()).ToListAsync();
			List<Customer> customersList = new List<Customer>();
			Customer customer = new Customer();
			foreach (BsonDocument customerBson in documents)
			{
				customer.Id = customerBson["_id"].AsString;
				customer.EMail = customerBson["email"].AsString;
				customer.Password = customerBson["contraseña"].AsString;
				customer.Forenames = customerBson["nombres"].AsString;
				customer.Surnames = customerBson["apellidos"].AsString;
				customer.Birthdate = customerBson["fechaNacimiento"].ToUniversalTime();
				customersList.Add(customer);
			}
			return customersList;
		}

		async public Task InsertOne(Customer customer)
		{
			var customerDocument = new BsonDocument
			{
				{ "email", customer.EMail },
				{ "contraseña", customer.Password },
				{ "nombres", customer.Forenames },
				{ "apellidos", customer.Surnames },
				{ "fechaNacimiento", customer.Birthdate}
			};
			await customersCollection.InsertOneAsync(customerDocument);
		}

	}
}
