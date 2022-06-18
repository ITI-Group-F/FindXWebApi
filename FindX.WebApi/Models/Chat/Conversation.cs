using MongoDbGenericRepository.Attributes;

namespace FindX.WebApi.Models.Chat;

[CollectionName("conversations")]
public class Conversation
{
	public Guid Id { get; set; }
	public Guid SenderId { get; set; }
	public Guid ReceiverId { get; set; }
	public IEnumerable<Message> Messages { get; set; }
}
