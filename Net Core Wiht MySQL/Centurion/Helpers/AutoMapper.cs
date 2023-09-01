using Json = System.Text.Json.JsonSerializer;
namespace Helpers
{
	public static class AutoMapper
	{
		public static T Convert<T>(object from)
		{
			return Json.Deserialize<T>(Json.Serialize(from));
		}
	}
}

