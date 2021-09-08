﻿namespace com.snake.framework
{
    public static class StringExtension
    {
        /// <summary>
        /// 修复斜杠
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FixSlash(this string str)
        {
            return str.Replace("\\", "/");
        }
    }
}