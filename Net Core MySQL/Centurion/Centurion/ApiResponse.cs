using System.Net;
using Microsoft.AspNetCore.Mvc;
using Catch;
using Enums;
using Session;

namespace API
{
    /// <summary>
    /// This Class allow you tu manager Api Response with try acction and verify
    /// user permision and token of controller
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// This methods allow try call acction of controller service for verify
        /// if catch an exception and verify controller permision and user token
        /// </summary>
        /// <typeparam name="T">Generic Model type</typeparam>
        /// <param name="services">Service of controller</param>
        /// <param name="headers">Request headers</param>
        /// <param name="permission">Controller permision</param>
        /// <returns>HTTP Response</returns>
        /// <exception cref="HttpException"></exception>
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

        /// <summary>
        /// This methods allow try call acction of controller service for verify
        /// if catch an exception and verify controller permision and user token
        /// </summary>
        /// <typeparam name="T">Generic Model type</typeparam>
        /// <param name="services">Service of controller</param>
        /// <param name="headers">Request headers</param>
        /// <param name="permission">Controller permision</param>
        /// <returns>HTTP Response</returns>
        /// <exception cref="HttpException"></exception>
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
