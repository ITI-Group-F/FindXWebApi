using MongoDbGenericRepository.Attributes;

namespace FindX.WebApi.Models.Chat;

[CollectionName("messages")]
public class Message
{
	public Guid Id { get; set; }
	public string Content { get; set; }
	public DateTime SendDate { get; set; }
	public bool IsSender { get; set; }
	public bool Seen { get; set; }
}
