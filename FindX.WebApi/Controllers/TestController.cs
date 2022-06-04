using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using FindX.WebApi.Models;
using FindX.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using FindX.WebApi.Models.Populated;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindX.WebApi.Controllers
{
	[Authorize(Roles = "Admin,User")]
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		public IMongoDatabase _database;
		private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
		public IMongoCollection<Item> Items { get; private set; }
		public IMongoCollection<SubCategory> Sub { get; }
		public IMongoCollection<SuperCategory> Sup { get; }

		private readonly IUserItemsRepository _itemRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;

		public TestController(IMongoClient client,
			IUserItemsRepository itemRepository,
			UserManager<ApplicationUser> userManager,
			IMapper mapper)
		{
			_database = client.GetDatabase("FindX");
			Items = _database.GetCollection<Item>("items");
			Sub = _database.GetCollection<SubCategory>("subCategories");
			Sup = _database.GetCollection<SuperCategory>("superCategories");
			_itemRepository = itemRepository;
			_userManager = userManager;
			_mapper = mapper;
		}
		// GET: api/<TestController>
		[HttpGet]
		public async Task<ActionResult> Get()
		{

			var reuslt = await _itemRepository.GetItemsForUserAsync(new Guid("547a8d67-7fa1-414d-b456-33cde2c58cd7"));
			return Ok(reuslt);
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
