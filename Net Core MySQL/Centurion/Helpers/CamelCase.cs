using System;
using System.Text.RegularExpressions;

namespace Helpers
{
	public static class CamelCase
	{
		public static string Get(string content)
		{
			var camel = Regex.Replace(
                Regex.Replace(
                    content,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );

            var split = camel.Split(' ');

            for (int i = 1; i < split.Count(); i++)
            {
                split[i] = split[i].ToLower();
            }

            var result = string.Join(" ", split);

            return result;
        }
	}
}

