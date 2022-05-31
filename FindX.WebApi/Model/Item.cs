using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FindX.WebApi.Model
{
    public class Item
    {
        [BsonId]
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BsonDateTime Date { get; set; }
        public string Location { get; set; }
        public bool IsLost { get; set; }
        public bool isClosed { get; set; }

        public string[] images { get; set; }
        public ObjectId Poster { get; set; }
        public ICategory[] categories { get; set; }

    }

}
