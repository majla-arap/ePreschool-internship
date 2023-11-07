using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;


namespace ePreschool.Shared.Extensions
{
    public static class SessionExtensions
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }


        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var stringified = JsonConvert.SerializeObject(value);
            session.SetString(key, stringified);
        }

        public static bool ContainsKey(this ISession session, string key)
        {
            return session.TryGetValue(key, out var _);
        }

        public static void RemoveObject(this ISession session, string key)
        {
            session.Remove(key);
        }
    }
}
