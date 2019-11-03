using System.Configuration;
using Zek.Extensions;

namespace Zek.Configuration
{
    public class WebConfig
    {
        /// <summary>
        /// ქეშის ვადის გასვლის წუთების რაოდენობა
        /// </summary>
        public static int CacheExpiration
        {
            get { return GetInt32("CacheExpiration"); }
        }

        /// <summary>
        /// Gets the int value with the specified key in app.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetInt32(string key)
        {
            return ConfigurationManager.AppSettings[key].ToInt32();
        }
    }
}
