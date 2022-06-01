namespace FindX.WebApi.Extenstions
{
	public static class IQueryableExtensions
	{
		public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> obj)
			=> await Task.Run(() => obj.ToList());
	}
}
