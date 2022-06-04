using AutoMapper;
using FindX.WebApi.DTOs;
using FindX.WebApi.DTOs.Populated;
using FindX.WebApi.Models;
using FindX.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FindX.WebApi.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]/{userId}")]
	[ApiController]
	public class UserItemsController : ControllerBase
	{
		private readonly IUserItemsRepository _itemsRepository;
		private readonly ISubCategoryRepository _subCategoryRepository;
		private readonly IMapper _mapper;

		public UserItemsController(
			IUserItemsRepository itemsRepository,
			IMapper mapper,
			ISubCategoryRepository subCategoryRepository)
		{
			_itemsRepository = itemsRepository;
			_subCategoryRepository = subCategoryRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PopulatedItemReadDto>>> GetItemsForUserAsync(Guid userId)
		{
			if (!await _itemsRepository.IsUserExist(userId))
			{
				return NotFound();
			}
			var items = await _itemsRepository.GetItemsForUserAsync(userId);
			var itemsDto = _mapper.Map<IEnumerable<PopulatedItemReadDto>>(items);
			return Ok(itemsDto);
		}

		[HttpGet("{itemId}", Name = "GetItemForUserAsync")]
		public async Task<ActionResult<PopulatedItemReadDto>> GetItemForUserAsync(Guid userId, Guid itemId)
		{
			if (!await _itemsRepository.IsUserExist(userId))
			{
				return NotFound();
			}
			var item = await _itemsRepository.GetItemForUserAsync(userId, itemId);
			var itemDto = _mapper.Map<PopulatedItemReadDto>(item);
			return Ok(itemDto);
		}

		[HttpPost]
		public async Task<ActionResult<IEnumerable<PopulatedItemReadDto>>> PostUserItem(Guid userId, ItemCreateDTO newItem)
		{
			if (!await _itemsRepository.IsUserExist(userId))
			{
				return NotFound();
			}
			var subCat = await _subCategoryRepository.GetSubCategoryIdAsync(newItem.SubCategory);

			var item = _mapper.Map<Item>(newItem);
			item.Id = Guid.NewGuid();
			item.UserId = userId;
			item.SubCategoryId = subCat.Id;
			item.SuperCategoryId = subCat.SuperCategoryId;
			try
			{
				await _itemsRepository.CreateItemAsync(item);
				var itemDto = _mapper.Map<ItemReadDTO>(item);
				return CreatedAtRoute(nameof(GetItemForUserAsync), new { userId = userId, itemId = item.Id }, itemDto);
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPut("{itemId}")]
		public async Task<ActionResult> UpdateItemAsync(Guid userId, Guid itemId, ItemUpdateDTO updatedItem)
		{
			if (!await _itemsRepository.IsUserExist(userId) ||
				await _itemsRepository.GetItemForUserAsync(userId, itemId) is null)
			{
				return NotFound();
			}

			var subCat = await _subCategoryRepository.GetSubCategoryIdAsync(updatedItem.SubCategory);

			var item = _mapper.Map<Item>(updatedItem);
			item.Id = Guid.NewGuid();
			item.UserId = userId;
			item.SubCategoryId = subCat.Id;
			item.SuperCategoryId = subCat.SuperCategoryId;
			try
			{
				await _itemsRepository.UpdateItemAsync(item);
				return NoContent();
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpDelete("{itemId}")]
		public async Task<ActionResult> DeleteUserItem(Guid userId, Guid itemId)
		{
			if (!await _itemsRepository.IsUserExist(userId) ||
				await _itemsRepository.GetItemForUserAsync(userId, itemId) is null)
			{
				return NotFound();
			}
			try
			{
				await _itemsRepository.DeleteItemAsync(userId, itemId);
				return NoContent();
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
