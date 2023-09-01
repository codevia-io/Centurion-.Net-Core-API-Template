using Helpers;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Catch
{
	public class HttpException : HttpRequestException
    {
		public HttpException(HttpStatusCode statusCode)
		{
            throw new HttpRequestException(CamelCase.Get(statusCode.ToString()), null, statusCode);
        }

        public HttpException(string message, HttpStatusCode statusCode)
        {
            throw new HttpRequestException(message, null, statusCode);
        }
    }

    public class HttpResult : ObjectResult
    {
        public HttpResult(HttpRequestException ex) : base(ex)
        {

            StatusCode = (int?)ex.StatusCode;
            Value = new HttpResultContent()
            {
                Result = null,
                Message = ex.Message,
            };
        }

        public HttpResult(object? value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.OK;
            Value = new HttpResultContent()
            {
                Result = value,
                Message = "Success"
            };
        }
    }

    public class HttpResultContent
    {
        public object Result { get; set; }
        public object Message { get; set; }
    }
}

