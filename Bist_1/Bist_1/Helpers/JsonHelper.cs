﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bist_1.Helpers
{
    public class JsonHelper
    {
        public static string GetSerializedString(object obj, params JsonConverter[] converters)
        {
            if (converters.Length == 0)
            {
                converters = new[] { new Newtonsoft.Json.Converters.StringEnumConverter() };
            }

            var settings = new JsonSerializerSettings()
            {
                Converters = converters,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T GetObjectFromString<T>(string json, params JsonConverter[] converters)
        {
            return JsonConvert.DeserializeObject<T>(json, converters);
        }

        public static T GetFullCopyOfObject<T>(T obj, params JsonConverter[] converters)
        {
            var json = GetSerializedString(obj, converters);
            return JsonConvert.DeserializeObject<T>(json, converters);
        }

    }
}
