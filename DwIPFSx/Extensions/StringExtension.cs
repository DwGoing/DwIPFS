using System;
using System.Collections.Generic;
using System.Text;

namespace DwIPFS.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {
            char[] chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(chars[random.Next(chars.Length)]);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 构造参数字符串
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="isFirst"></param>
        /// <returns></returns>
        public static string BuildParameterString(this Dictionary<string, object> parameters, bool isFirst = true)
        {
            string parameterString = "";
            if (parameters != null)
                foreach (var item in parameters)
                {
                    parameterString += $"{item.Key}={item.Value}";
                }
            if (!string.IsNullOrEmpty(parameterString) && !isFirst)
                parameterString = "&" + parameterString;
            return parameterString;
        }
    }
}
