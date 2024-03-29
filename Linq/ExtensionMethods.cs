﻿namespace Linq
{
	internal static class ExtensionMethods
	{
		public static int Quersumme(this int x)
		{
			return x.ToString().ToCharArray().Sum(e => (int) char.GetNumericValue(e));
		}

		public static int ParseDirect(this string s)
		{
			return int.Parse(s);
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
		{
			return list.OrderBy(e => Random.Shared.Next());
		}
	}
}
