using System.Reflection;

namespace FindX.WebApi.Helpers;

public static class SubCategories
{
	#region Electronics
	public const string Mobile = "Mobiles";
	public const string Tablet = "Tablets";
	public const string Laptop = "Laptops";
	#endregion

	#region Animals
	public const string Birds = "Birds";
	public const string Cats = "Cats";
	public const string Dogs = "Dogs";
	#endregion

	#region Belongings
	public const string PersonalCardsAndPapers = "Personal cards and papers";
	public const string Wallets = "Wallets";
	public const string Glasses = "Glasses";
	public const string Money = "Money";
	public const string Bags = "Bags";
	public const string Accessories = "Accessories";
	#endregion

	public const string Other = "other";

	public static bool IsExists(string subCategory)
	{
		Type type = typeof(SubCategories);
		foreach (var c in type.GetFields(BindingFlags.Static | BindingFlags.Public))
		{
			var value = c.GetValue(null);
			if ((string)value == subCategory)
			{
				return true;
			}
		}
		return false;
	}
}
