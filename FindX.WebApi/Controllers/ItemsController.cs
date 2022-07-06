using AutoMapper;
using FindX.WebApi.DTOs;
using FindX.WebApi.Helpers;
using FindX.WebApi.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FindX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
	private readonly IItemsRepository _itemsRepository;
	private readonly IMapper _mapper;

	public ItemsController(IItemsRepository itemsRepository, IMapper mapper)
	{
		_itemsRepository = itemsRepository;
		_mapper = mapper;
	}

	[HttpGet]
	[Route("all")]
	public async Task<ActionResult<IEnumerable<ItemReadDTO>>> GetItemsAsync()
	{
		var items = await _itemsRepository.GetItemsAsync();
		var itemsDto = _mapper.Map<IEnumerable<ItemReadDTO>>(items);
		return Ok(itemsDto);
	}

	[HttpGet]
	[Route("undersub/{subcategory}")]
	public async Task<ActionResult<IEnumerable<ItemReadDTO>>> GetItemsUnderSubCategoryAsync(string subcategory)
	{
		if (SubCategories.IsExists(subcategory))
		{
			var items = await _itemsRepository.GetItemsUnderSubCategoryAsync(subcategory);
			var itemsDto = _mapper.Map<IEnumerable<ItemReadDTO>>(items);
			return Ok(itemsDto);
		}
		else
		{
			return NotFound();
		}
	}

	[HttpGet]
	[Route("undersup/{supercategory}")]
	public async Task<ActionResult<IEnumerable<ItemReadDTO>>> GetItemsUnderSuperCategoryAsync(string supercategory)
	{
		if (SuperCategories.IsExists(supercategory))
		{
			var items = await _itemsRepository.GetItemsUnderSuperCategoryAsync(supercategory);
			var itemsDto = _mapper.Map<IEnumerable<ItemReadDTO>>(items);
			return Ok(itemsDto);
		}
		else
		{
			return NotFound();
		}
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<ActionResult<ItemReadDTO>> GetItemByIdAsync(Guid id)
	{
		var item = await _itemsRepository.GetItemsUnderItemIdAsync(id);
		if (item is null)
		{
			return NotFound();
		}
		var itemDto = _mapper.Map<ItemReadDTO>(item);
		return Ok(itemDto);
	}
}
