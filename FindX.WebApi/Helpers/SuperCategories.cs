using System.Reflection;

namespace FindX.WebApi.Helpers;

public static class SuperCategories
{
	public const string Electronics = "Electronics";
	public const string Animals = "Animals";
	public const string Belongings = "Belongings";
	public const string Other = "Other";

	public static bool IsExists(string superCategory)
	{
		Type type = typeof(SubCategories);
		foreach (var c in type.GetFields(BindingFlags.Static | BindingFlags.Public))
		{
			var value = c.GetValue(null);
			if ((string)value == superCategory)
			{
				return true;
			}
		}
		return false;
	}
}
