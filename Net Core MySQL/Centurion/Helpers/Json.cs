using System.Text.Json;

namespace Helpers
{
	public static class Json
	{
		public static string Serialize(object obj)
		{
			return JsonSerializer.Serialize(obj);
		}

		public static T? Deserialize<T>(string content)
		{
			return JsonSerializer.Deserialize<T>(content);
		}
	}
}

