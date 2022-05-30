

using MongoDB.Bson;

namespace FindX.WebApi.Model
{
    public class SuperCategory : ICategory
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public ICategory[] Subcategories { get; set; }
    }
}
