using FindX.WebApi.DTOs;
using FindX.WebApi.Models;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Bson;
using FindX.WebApi.Extenstions;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories.Repository
{
	public class SearchRepository : ISearchRepository
	{
		private readonly IMongoContext _context;
		public SearchRepository(IMongoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Item>> SearchFinderAsync(string query)
		{
			var pipeLine = new BsonDocument[]
				{
					new BsonDocument("$search",
					new BsonDocument
							{
									{ "index", "BebarsSearch" },
									{ "autocomplete",
					new BsonDocument
									{
											{ "path", "Title" },
											{ "query", ""+query+"" },
											{ "fuzzy",
					new BsonDocument("maxEdits", 1) }
									} }
							}),
						new BsonDocument
						{
								{
										"$project", new BsonDocument
										{
												{"_id", 1},
												{"Title", 1},
										}
								}
						},
					new BsonDocument("$limit", 10),
				};
			var searchResult = await _context.Items
				.Aggregate<Item>(pipeLine)
				.ToListAsync();
			return searchResult;
		}
	}
}
