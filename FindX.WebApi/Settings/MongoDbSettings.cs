namespace FindX.WebApi.Settings
{
    public class MongoDbSettings
    {
        public string Username { get; set; }
        public int Password { get; set; }
        public string ConnectionString => $"mongodb+srv://{Username}:{Password}@cluster0.lanii.mongodb.net/?retryWrites=true&w=majority";
    }
}
