using AutoMapper;
using FindX.WebApi.DTOs;
using FindX.WebApi.Models;
using FindX.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FindX.WebApi.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
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

		//Get All Items In DB .....
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ItemReadDTO>>> GetUserItem()
		{
			var allItems = await _itemsRepository.GetAllItemsAsync();
			if (!allItems.Any())
			{
				return NotFound();
			}
			
			return Ok(_mapper.Map<IEnumerable<ItemReadDTO>>(allItems));
		}


		//Get All Items For Specific User ....
		[HttpGet("{userId}")]
		public async Task<ActionResult<IEnumerable<ItemReadDTO>>> GetItemsForUser(Guid userId)
		{
			if (!await _itemsRepository.IsUserExist(userId))
			{
				return NotFound();
			}

			var userItems = await _itemsRepository.GetItemsForUserAsync(userId);
			var userItemsDto = _mapper.Map<IEnumerable<ItemReadDTO>>(userItems);
			return Ok(userItemsDto);
		}

		//this  for Getting A Specific  Item For Specific User but Still under work 
		//[HttpGet("{itemId}")]
		//public async Task<ActionResult<IEnumerable<ItemReadDTO>>> GetUserItem(Guid userId, Guid itemId)
		//{
		//    if (!await _itemsRepository.IsUserExist(userId))
		//    {
		//        return BadRequest();
		//    }

		//    _itemsRepository.get



		//    return Ok();
		//}

		[HttpPost("{userId}")]
		public async Task<ActionResult<IEnumerable<ItemReadDTO>>> PostUserItem(Guid userId, ItemCreateDTO newItem)
		{
			if (userId != newItem.UserId)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState.ValidationState);

			}
			var itemModel = _mapper.Map<Item>(newItem);
			await _itemsRepository.CreateItemAsync(userId, itemModel);

            return Created("Created Successfully", _mapper.Map<ItemReadDTO>(itemModel));


        }


		//Update or Edit  User  
		[HttpPut("{userId}/{itemId}")]
		public async Task<ActionResult<ItemUpdateDTO>> PutUserItem(Guid userId,Guid itemId, ItemUpdateDTO newItem)
		{
			if (userId != newItem.UserId||!ModelState.IsValid)
			{
				return BadRequest();
			}


    //        if (!_itemsRepository.IsItemExistFor(userId,itemId))
    //        {
				//return NotFound();

    //        }
		

			var itemModel = _mapper.Map<Item>(newItem);
			await _itemsRepository.UpdateItemAsync(userId, itemModel);

			return NoContent();

		}


		//this for Delete a Specific  Item For Specific User but Still under work...
		[HttpDelete("{userId}/{itemId}")]
		public async Task<ActionResult> DeleteUserItem(Guid userId, Guid itemId)
		{
			if (!await _itemsRepository.IsUserExist(userId)) { return BadRequest(); }

			//        if (!_itemsRepository.IsItemExistFor())
			//        {
			//				return NotFound();

			//        }

			await _itemsRepository.DeleteItemAsync(itemId);
			return NoContent();

		}

	}

}
