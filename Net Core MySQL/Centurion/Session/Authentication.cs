using Enums;
using Catch;
namespace Session
{
	public static class Authentication
	{
		private static SessionManagement SessionManagement = SessionManagement.GetInstance();

		public static void Auth(string token, UserPermission endPointPermision)
		{
			if (token is null)
				throw new HttpException("Auth: Token is null", StatusCode.Unauthorized);

			if (token == string.Empty)
				throw new HttpException(StatusCode.Unauthorized);

			if (TokenManagement.Exist(token) is false)
				throw new HttpException("Token does exist", StatusCode.Unauthorized);

			UserSession session = SessionManagement.Get(token);

			if ((int)session.User.Permision > (int)endPointPermision)
				throw new HttpException("You do not have authorization", StatusCode.Unauthorized);
        }
	}
}

