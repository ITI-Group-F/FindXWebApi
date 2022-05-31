using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using FindX.WebApi.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindX.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		public IMongoDatabase _database;
		private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
		public IMongoCollection<Item> Items { get; private set; }

		public TestController(IMongoClient client)
		{
			_database = client.GetDatabase("FindX");
			Items = _database.GetCollection<Item>("items");

		}
		// GET: api/<TestController>
		[HttpGet]
		public IActionResult Get()
		{
			var filter = _filterBuilder.Eq(i => i.Id, new Guid("b9d045f3-b4f3-4921-b33f-b13dfc6e9559"));
			var result = Items.Find(filter).SingleOrDefault();

			return Ok(result);
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
