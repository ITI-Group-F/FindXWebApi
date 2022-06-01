namespace FindX.WebApi.Repositories
{
	public interface ISubCategoryRepository
	{
		Task<Guid> GetSubCategoryId(string title);
	}
}
