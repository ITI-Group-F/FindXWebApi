using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.Model
{
    public class User
    {

        public ObjectId _id { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Phone { get; set; }
    }
}
