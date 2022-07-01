using MongoDB.Driver;

namespace FindX.WebApi.Extenstions
{
    public static class ToList
    {

        public static List<TDocument> ToListIAsyncCursor<TDocument>(this IAsyncCursor<TDocument> source)
        {
            return source.ToList<TDocument>();
        }

    }
}
