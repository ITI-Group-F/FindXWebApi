using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FindX.WebApi.Model
{
    public interface ICategory
    {
        [BsonId]
        public Guid id { get; set; }
        public string Title { get; set; }        
    }
}
