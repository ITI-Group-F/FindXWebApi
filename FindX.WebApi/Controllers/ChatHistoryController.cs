using FindX.WebApi.Models.Populated;
using FindX.WebApi.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatHistoryController : ControllerBase
{
	private IConversationRepository _conversationRepository;

	public ChatHistoryController(IConversationRepository conversationRepository)
	{
		_conversationRepository = conversationRepository;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<PopulatedConversation>>> GetUserConversationsAsync(Guid userId)
	{
		var conversations = await _conversationRepository.
			GetUserConversationsAsync(userId);
		return Ok(conversations);
	}
}
