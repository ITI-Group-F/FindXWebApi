namespace FindX.WebApi.Extenstions
{
	public static class IQueryable
	{

		public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> obj) => await Task.Run(() => obj.ToList());
		public static async Task<T> SingleOrDefaultAsync<T>(this IQueryable<T> obj) => await Task.Run(() => obj.SingleOrDefault());
	}
}
