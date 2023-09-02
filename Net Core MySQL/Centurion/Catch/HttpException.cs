
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Catch
{
	public class HttpException : HttpRequestException
    {
		public HttpException(StatusCode statusCode)
		{
            throw new HttpRequestException(CamelCase.ToString(statusCode.ToString()), null, (HttpStatusCode)statusCode);
        }

        public HttpException(string message, StatusCode statusCode)
        {
            throw new HttpRequestException(message, null, (HttpStatusCode)statusCode);
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

    public enum StatusCode
    {
        Continue = 100,
        SwitchingProtocols = 101,
        Processing = 102,
        EarlyHints = 103,
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultiStatus = 207,
        AlreadyReported = 208,
        IMUsed = 226,
        MultipleChoices = 300,
        Ambiguous = 300,
        MovedPermanently = 301,
        Moved = 301,
        Found = 302,
        Redirect = 302,
        SeeOther = 303,
        RedirectMethod = 303,
        NotModified = 304,
        UseProxy = 305,
        Unused = 306,
        TemporaryRedirect = 307,
        RedirectKeepVerb = 307,
        PermanentRedirect = 308,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        MisdirectedRequest = 421,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        RequestHeaderFieldsTooLarge = 431,
        UnavailableForLegalReasons = 451,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HttpVersionNotSupported = 505,
        VariantAlsoNegotiates = 506,
        InsufficientStorage = 507,
        LoopDetected = 508,
        NotExtended = 510,
        NetworkAuthenticationRequired = 0x1FF
    }
}

