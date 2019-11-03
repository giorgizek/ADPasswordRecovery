using System.IO;
using System.Net;

namespace Zek.Service.SMS
{
    public class HttpToSMSBase
    {
        public static string ParseMobile(string mobile)
        {
            var result = string.Empty;
            foreach (var c in mobile)
                if (char.IsNumber(c)) result += c;

            if (result.StartsWith("995") && result.Length == 11)
                result = result.Insert(3, "5");
            else if (result.StartsWith("8") && result.Length == 9)
                result = "9955" + result.Substring(1);
            else if (result.StartsWith("5") && result.Length == 9)
                result = "995" + result;
            return result;
        }
        public static string SendWebRequest(string url)
        {
            string responseFromServer;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream))
                    {
                        responseFromServer = reader.ReadToEnd();
                        reader.Close();
                    }
                    dataStream.Close();
                }
                response.Close();
            }

            return responseFromServer;
        }
    }
}
