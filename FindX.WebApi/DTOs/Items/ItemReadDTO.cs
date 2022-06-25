using System.Text.Json;
using System.Text.Json.Serialization;

namespace FindX.WebApi.DTOs;

//[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string Brand { get; set; }
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string Model { get; set; }
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public DateTime ModelYear { get; set; }
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string Color { get; set; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string Species { get; set; }
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public int Age { get; set; }
}
