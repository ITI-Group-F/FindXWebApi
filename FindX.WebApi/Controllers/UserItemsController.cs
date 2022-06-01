using AutoMapper;
using FindX.WebApi.DTOs;
using FindX.WebApi.Model;
using FindX.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindX.WebApi.Controllers
{
	[Route("api/[controller]/{userId}/{itemId}")]
	[ApiController]
	public class UserItemsController : ControllerBase
	{
		private readonly IItemRepository _itemsRepository;
		private readonly IMapper _mapper;

		public UserItemsController(IItemRepository itemsRepository, IMapper mapper)
		{
			_itemsRepository = itemsRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ItemReadDTO>>> GetItemsForUserAsync(Guid userId, Guid itemId)
		{
			if (!await _itemsRepository.IsUserExist(userId))
			{
				return NotFound();
			}
			var userItems = await _itemsRepository.GetItemsForUserAsync(userId);
			var userItemsDto = _mapper.Map<IEnumerable<ItemReadDTO>>(userItems);
			return Ok(userItemsDto);
		}
	}
}
