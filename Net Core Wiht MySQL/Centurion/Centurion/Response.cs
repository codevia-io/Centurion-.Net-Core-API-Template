using System.Net;
using Microsoft.AspNetCore.Mvc;
using Catch;
namespace API
{
	public class API
	{
		private static ActionResult Method<TModel> (Func<TModel> services)
		{
			try
			{
                if (services is null)
                    throw new HttpException(HttpStatusCode.MethodNotAllowed);

                TModel result = services.Invoke();
                return new HttpResult(result);
			}
            catch (HttpException ex)
			{
                return new HttpResult(ex);
            }
		}

        private static ActionResult Method(Action services)
        {
            try
            {
                if (services is null)
                    throw new HttpRequestException("Service is undefined", null, HttpStatusCode.MethodNotAllowed);

                services.Invoke();
                return new HttpResult(HttpStatusCode.OK);
            }
            catch (HttpException ex)
            {
                return new HttpResult(ex);
            }
        }

        public static ActionResult Get<TModel>(Func<TModel> services)
        {
			return Method(services);
        }

        public static ActionResult Post(Action services)
        {
            return Method(services);
        }

        public static ActionResult Put(Action services)
        {
            return Method(services);
        }

        public static ActionResult Delete(Action services)
        {
            return Method(services);
        }
    }
}

