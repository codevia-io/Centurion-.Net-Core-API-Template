using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
