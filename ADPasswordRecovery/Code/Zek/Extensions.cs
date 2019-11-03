namespace Zek.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// იღებს Int32-ს ტექსტიდან
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(this string str, int defaultValue = 0)
        {
            str = IfNullEmpty(str);
            int result;
            return int.TryParse(str, out result) ? result : defaultValue;
        }
        public static string ParseMobile(this string str)
        {
            if (str == null) return null;

            var result = string.Empty;
            foreach (var c in str)
                if (char.IsNumber(c)) result += c;

            if (result.StartsWith("995") && result.Length == 11)
                result = result.Insert(3, "5");
            else if (result.StartsWith("8") && result.Length == 9)
                result = "9955" + result.Substring(1);
            else if (result.StartsWith("5") && result.Length == 9)
                result = "995" + result;
            return result;
        }

        /// <summary>
        /// იღებს String-ს ტექსტიდან. თუ ტექსტი == null მაშინ აბრუნებს ""
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string IfNullEmpty(this string str)
        {
            return str ?? string.Empty;
        }
    }
}
