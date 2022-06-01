﻿using FindX.WebApi.Model;

namespace FindX.WebApi.DTOs
{
	public class ItemUpdateDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public bool IsLost { get; set; }
		public ICollection<string> Images { get; set; } = new HashSet<string>();
		public Guid UserId { get; set; }
		public string SubCategory { get; set; }
	}
}