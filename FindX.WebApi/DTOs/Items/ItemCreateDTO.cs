using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.DTOs;

public class ItemCreateDTO
{
	public string Title { get; set; }
	public string Description { get; set; }
	[DataType(DataType.Date)]
	public DateTime Date { get; set; }
	public string Longitude { get; set; }
	public string Latitude { get; set; }
	public string Location { get; set; }
	public bool IsLost { get; set; }
	public IList<IFormFile> File { get; set; }
	public string SubCategory { get; set; }
	public string SuperCategory { get; set; }

	public string Brand { get; set; }
	public string Model { get; set; }
	public int ModelYear { get; set; }
	public string Color { get; set; }

	public int Age { get; set; }
}
