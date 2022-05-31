namespace FindX.WebApi.Settings
{
	public class MongoDbSettings
	{
		public string Username { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string ConnectionString =>
			$"mongodb+srv://{Username}:{Password}@cluster0.lanii.mongodb.net/?retryWrites=true&w=majority";
	}
}
