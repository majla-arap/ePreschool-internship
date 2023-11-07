using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Newtonsoft.Json;

namespace ePreschool.Web.Utilities.Extensions
{
    public static class TempData
    {
        public static void SetObject<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T GetObject<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out var o);

            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}
