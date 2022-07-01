using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories.IRepository
{
    public interface ISearch
    {

        public  Task<IEnumerable<Item>> SearchFinderAsync(string query);
    }
}
