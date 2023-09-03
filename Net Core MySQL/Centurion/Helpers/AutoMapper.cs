using System.Text.Json;

namespace Helpers
{
    public static class AutoMapper
    {
        public static TOut Convert<TOut>(object object1)
        {
            return JsonSerializer.Deserialize<TOut>(JsonSerializer.Serialize(object1));
        }
    }
}
