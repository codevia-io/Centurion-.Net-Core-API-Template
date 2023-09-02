using System.Net;
using Microsoft.AspNetCore.Mvc;
using Catch;
using Enums;
using Session;

namespace API
{
    public class ApiResponse
    {
        public static ActionResult Try<T>(Func<T> services, IHeaderDictionary? headers = null, UserPermission permission = UserPermission.Visitor)
		{
			try
			{
                if (services is null)
                    throw new HttpException("Try Api Response : Service is null", StatusCode.InternalServerError);

                if (headers is not null && permission is not UserPermission.Visitor)
                    Authentication.Auth(TokenManagement.Get(headers), permission);

                object? result = services.Invoke();
                return new HttpResult(result);
			}
            catch (HttpRequestException ex)
			{
                return new HttpResult(ex);
            }
		}

        public static ActionResult Try(Action services, IHeaderDictionary? headers = null, UserPermission permission = UserPermission.Visitor)
        {
            try
            {
                if (services is null)
                    throw new HttpException("Try Api Response : Service is null", StatusCode.InternalServerError);

                if (headers is not null && permission is not UserPermission.Visitor)
                    Authentication.Auth(TokenManagement.Get(headers), permission);

                services.Invoke();
                return new HttpResult(HttpStatusCode.OK);
            }
            catch (HttpRequestException ex)
            {
                return new HttpResult(ex);
            }
        }
    }
}
