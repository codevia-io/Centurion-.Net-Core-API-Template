using Models;
using Catch;
using Helpers;
using Microsoft.AspNetCore.Http;

namespace Session
{
	/// <summary>
	/// This Class allow you to manager Tokens
	/// </summary>
	public static class TokenManagement
	{
        private static SessionManagement SessionManagement = SessionManagement.GetInstance();
		public static string TokenAppName = $"user.appname.token";

		/// <summary>
		/// This method allow create a new Toke from a user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		/// <exception cref="HttpException"></exception>
        public static string Create(User user)
		{
            if (user is null)
                throw new HttpException("User is null", StatusCode.Unauthorized);

			TokentInfo tokentInfo = new TokentInfo()
			{
				UserName = user.UserName,
				Id = user.Id,
				DateTime = DateTime.Now,
			};

			string jsonContent = Json.Serialize(tokentInfo);

			return Encryptor.Hash(jsonContent);
		}

		/// <summary>
		/// This method allow verify if token exist in one our more session
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		/// <exception cref="HttpException"></exception>
		public static bool Exist(string token)
        {
            if (token is null)
                throw new HttpException("Token is null", StatusCode.Unauthorized);

			return SessionManagement.Exist(token);
        }

		/// <summary>
		/// This method allow get a token from resquest header transmited by controller
		/// </summary>
		/// <param name="headers"></param>
		/// <returns></returns>
		/// <exception cref="HttpException"></exception>
		public static string Get(IHeaderDictionary headers)
		{
            string? token = headers.SingleOrDefault(h => h.Key.Equals(TokenAppName)).Value;

			if (token is null)
                throw new HttpException("Token is null", StatusCode.Unauthorized);

            return token;
        }
    }

	public class TokentInfo
	{
		public string? UserName { get; set; }
		public int? Id { get; set; }
		public DateTime DateTime { get; set; } = DateTime.Now;
	}
}


