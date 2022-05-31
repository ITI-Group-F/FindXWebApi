using FindX.WebApi.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace FindX.WebApi.Models
{
    public class SubCategory : ICategory
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
