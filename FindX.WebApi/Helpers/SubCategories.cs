using System.Reflection;

namespace FindX.WebApi.Helpers
{
	public static class SubCategories
	{
		#region Electronics
		public const string Mobile = "Mobile";
		public const string Tablet = "Tablet";
		public const string Laptop = "Laptop";
		#endregion

		#region Animals
		public const string Bird = "Bird";
		public const string Cat = "Cat";
		public const string Dog = "Dog";
		#endregion

		#region Belongings
		public const string PersonalCardsAndPapers = "Personal cards and papers";
		public const string Wallet = "Wallet";
		public const string Glasses = "Glasses";
		public const string Money = "Money";
		public const string Bag = "Bag";
		public const string Accessory = "Accessory";
		#endregion

		public const string Other = "Other";

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
}
