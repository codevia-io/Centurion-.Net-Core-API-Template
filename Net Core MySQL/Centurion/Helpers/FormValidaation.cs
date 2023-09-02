using System.Text.RegularExpressions;
using Catch;

namespace Helpers
{
	public static class FormValidation
	{
		public static bool Mail(string input)
		{
			if (input is null)
				throw new HttpException("Email is null", StatusCode.BadRequest);

            if (input == string.Empty)
                throw new HttpException("Email is empty", StatusCode.BadRequest);

            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            RegexOptions options = RegexOptions.Multiline;
			var match = Regex.Matches(input, pattern, options);

			if (match is null || match.Count == 0)
				throw new HttpException("Email is not valide", StatusCode.BadRequest);

			return true;
		}
	}

	public class Validations : List<bool>
	{
		public bool IsValidate => !this.Contains(false);
	}
}

