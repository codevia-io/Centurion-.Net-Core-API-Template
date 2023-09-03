using Enums;
using Catch;

namespace Session
{
	/// <summary>
	/// This class allow you to manager Auth for securize acces for services
	/// </summary>
	public static class Authentication
	{
		private static SessionManagement SessionManagement = SessionManagement.GetInstance();

		/// <summary>
		/// This method allow try if auth informationis the appropiate one
		/// </summary>
		/// <param name="token"></param>
		/// <param name="endPointPermision"></param>
		/// <exception cref="HttpException"></exception>
		public static void Try(string token, UserPermission endPointPermision)
		{
			if (token is null)
				throw new HttpException("Auth: Token is null", StatusCode.Unauthorized);

			if (token == string.Empty)
				throw new HttpException(StatusCode.Unauthorized);

			if (TokenManagement.Exist(token) is false)
				throw new HttpException("Token does exist", StatusCode.Unauthorized);

			UserSession? session = SessionManagement.Get(token);

			if ((int)session.User.Permision > (int)endPointPermision)
				throw new HttpException("You do not have authorization", StatusCode.Unauthorized);
        }
	}
}

