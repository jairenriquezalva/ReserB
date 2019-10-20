using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReserB.Services
{
	public abstract class GenericRepository<T,BsonT>
		where T : new()
		where BsonT : BsonTypeBase<T>, new()
	{
		IMongoCollection<BsonT> collection;
		
		public GenericRepository(IConfiguration configuration, string collectionName)
		{
			IMongoClient client = new MongoClient(configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"));
			IMongoDatabase database = client.GetDatabase(configuration.GetSection("MongoDB").GetValue<string>("Database"));
			collection = database.GetCollection<BsonT>(collectionName);
		}

		async public Task<T> Get(string id)
		{
			T baseObject = new T();
			BsonT bsonObject = new BsonT();
			Type bsonType = bsonObject.GetType();
			bsonObject = await collection.Find(document => document.Id == id).FirstOrDefaultAsync();
			return bsonObject.GetBase();
		}

		async public Task<IEnumerable<T>> GetAll()
		{
			var bsonObjects = await collection.Find(bson => true).ToListAsync();
			List<T> baseObjectList = new List<T>();
			foreach (var bsonObject in bsonObjects)
			{
				baseObjectList.Add(bsonObject.GetBase());
			}
			return baseObjectList;
		}

		async public Task InsertOne(T customer)
		{
			BsonT bsonObject = new BsonT();
			bsonObject.SetBase(customer);
			await collection.InsertOneAsync(bsonObject);
		}

	}
}
