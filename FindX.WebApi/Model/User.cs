using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.Model
{
    public class User
    {
        [BsonId]
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Phone { get; set; }
    }
}
