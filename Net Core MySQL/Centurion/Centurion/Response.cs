using System.Net;
using Microsoft.AspNetCore.Mvc;
using Catch;

namespace API
{
    public class ApiResponse
    {        
        public static ActionResult Try<T>(Func<T> services)
		{
			try
			{
                if (services is null)
                    throw new HttpException("Try Api Response : Service is null", HttpStatusCode.InternalServerError);

                object? result = services.Invoke();
                return new HttpResult(result);
			}
            catch (HttpRequestException ex)
			{
                return new HttpResult(ex);
            }
		}

        public static ActionResult Try(Action services)
        {
            try
            {
                if (services is null)
                    throw new HttpException("Try Api Response : Service is null", HttpStatusCode.InternalServerError);

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
