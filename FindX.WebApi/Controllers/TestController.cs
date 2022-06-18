using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using FindX.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using MongoDB.Bson;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using FindX.WebApi.Models.Chat;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindX.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		public IMongoDatabase _database;
		private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
		public IMongoCollection<BsonDocument> Items { get; private set; }

		private readonly IUserItemsRepository _itemRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IConversationRepository _conversationRepository;
		private readonly IMongoContext _context;

		public TestController(IMongoClient client,
			IUserItemsRepository itemRepository,
			UserManager<ApplicationUser> userManager,
			IMapper mapper,
			IConversationRepository conversationRepository,
			IMongoContext context)
		{
			_database = client.GetDatabase("FindX");
			Items = _database.GetCollection<BsonDocument>("items");
			_itemRepository = itemRepository;
			_userManager = userManager;
			_mapper = mapper;
			_conversationRepository = conversationRepository;
			_context = context;
		}
		// GET: api/<TestController>
		[HttpGet]
		public async Task<ActionResult> Get()
		{
			//var pipelineStage = new BsonDocument
			//	{
			//		{
			//			"$lookup", new BsonDocument{
			//					{ "from", "superCategories" },
			//					{ "localField", "SuperCategoryId" },
			//					{ "foreignField", "_id" },
			//					{ "as", "superCategory" }
			//				}
			//		}
			//	};

			//BsonDocument[] pipeline = new BsonDocument[] {
			//		pipelineStage
			//};
			//var docs = await Items.Aggregate<BsonDocument>(pipeline).ToListAsync();
			//var docs = await Items
			//	.Aggregate()
			//	.Lookup("superCategories", "SuperCategoryId", "_id", "superCategory")
			//	.As<BsonDocument>()
			//	.ToListAsync();

			//return Ok(docs);

			//await _context.Conversations.InsertOneAsync(new Conversation());
			return NoContent();
		}

		// GET api/<TestController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<TestController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<TestController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<TestController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
