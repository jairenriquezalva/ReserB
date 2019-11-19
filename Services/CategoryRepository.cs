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
	public class CategoryRepository : GenericRepository<Category, CategoryBson>, ICategoryRepository
	{
		public CategoryRepository(IConfiguration configuration, string collectionName) : base(configuration, collectionName)
		{
		}
		public async Task<List<Category>> GetBySector(string idSector)
		{
			var categories = await collection.Find((b => b.Sector == idSector)).ToListAsync<CategoryBson>();
			return categories.Select(cat => cat.GetBase()).ToList();
		}
	}

	public class CategoryBson : BsonTypeBase<Category>
	{
		[BsonElement("nombre")]
		public string Name { get; set; }
		[BsonElement("rubro")]
		public string Sector { get; set; }

		public override Category GetBase()
		{
			return new Category() { Id = Id, Name = Name, Sector = Sector };
		}

		public override void SetBase(Category baseObject)
		{
			Id = baseObject.Id;
			Name = baseObject.Name;
			Sector = baseObject.Sector;
		}
	}
}
