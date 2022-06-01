using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using FindX.WebApi.Model;
using FindX.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using FindX.WebApi.Models.Populated;
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

		private readonly IItemRepository _itemRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;

		public TestController(IMongoClient client,
			IItemRepository itemRepository,
			UserManager<ApplicationUser> userManager,
			IMapper mapper)
		{
			_database = client.GetDatabase("FindX");
			Items = _database.GetCollection<Item>("items");
			_itemRepository = itemRepository;
			_userManager = userManager;
			_mapper = mapper;
		}
		// GET: api/<TestController>
		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var itm = new Item();
			var pop = _mapper.Map<PopulatedItems>(itm);
			//var filter = _filterBuilder.Eq(i => i.Id, new Guid("b9d045f3-b4f3-4921-b33f-b13dfc6e9559"));
			//var result = Items.Find(filter).SingleOrDefault();

			//var result = await _userManager.CreateAsync(new ApplicationUser() { UserName = "Mohab", Email = "mohab@mail.com", FirstName = "Mohab", LastName = "Alnajjar" }, "Mohab123!");
			//if (result.Succeeded)
			//{

			//}
			//Items.InsertOne(new Item());
			var reuslt = await _itemRepository.GetAllItemsAsync();
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
