using MongoDB.Bson;

namespace FindX.WebApi.Model
{
    public interface ICategory
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }        
    }
}
