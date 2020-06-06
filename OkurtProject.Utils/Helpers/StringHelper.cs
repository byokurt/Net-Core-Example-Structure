
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OkurtProject.Utils.Helpers
{
    public static class StringHelper
    {
        public static bool ValidateJSON(this string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}
