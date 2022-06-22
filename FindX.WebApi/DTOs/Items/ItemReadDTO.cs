using Newtonsoft.Json;
using JsonSerialization = System.Text.Json.Serialization;

namespace FindX.WebApi.DTOs;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class ItemReadDTO
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public DateTime Date { get; set; }
	public string Longitude { get; set; }
	public string Latitude { get; set; }
	public string Location { get; set; }
	public bool IsLost { get; set; }
	public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();
	public string SubCategory { get; set; }
	public string SuperCategory { get; set; }
	public Guid UserId { get; set; }

	public string Brand { get; set; }
	public string Model { get; set; }
	public DateTime ModelYear { get; set; }
	public string Color { get; set; }

	public string Species { get; set; }
	[JsonSerialization.JsonIgnore(Condition =
		JsonSerialization.JsonIgnoreCondition.WhenWritingDefault)]
	public int Age { get; set; }
}
