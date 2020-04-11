using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Medium.Common.Helper
{
    public static class JsonHelper
    {
        public static bool ValidateJSON(this string s)
        {
            var response = false;

            try
            {
                JToken.Parse(s);
                response = true;
            }
            catch (JsonReaderException ex)
            {
                response = false;
            }

            return response;
        }
    }
}
