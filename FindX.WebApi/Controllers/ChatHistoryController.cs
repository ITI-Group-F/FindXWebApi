using FindX.WebApi.DTOs.Chat;
using FindX.WebApi.Models.Populated;
using FindX.WebApi.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindX.WebApi.Controllers;

[Route("api/[controller]/{userId}")]
[ApiController]
public class ChatHistoryController : ControllerBase
{
	private readonly IConversationRepository _conversationRepository;
	private readonly IUserItemsRepository _userItemsRepository;

	public ChatHistoryController(
		IConversationRepository conversationRepository,
		IUserItemsRepository userItemsRepository)
	{
		_conversationRepository = conversationRepository;
		_userItemsRepository = userItemsRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<PopulatedConversationReadDto>>> GetUserConversationsAsync(Guid userId)
	{
		if (!await _userItemsRepository.IsUserExistAsync(userId))
		{
			return NotFound();
		}
		var conversations = await _conversationRepository.
			GetUserConversationsAsync(userId);
		return Ok(conversations);
	}
}
