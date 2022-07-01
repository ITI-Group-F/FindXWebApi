using FindX.WebApi.Models;
using MongoDB.Bson;

namespace FindX.WebApi.Repositories.IRepository
{
    public interface ISearch
    {

        public  Task<IEnumerable<Item>> SearchFinderAsync(string query);
    }
}
