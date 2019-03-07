using System;
namespace MyVote.Tools
{
    public static class Utils
    {
        /// <summary>
        /// 获得一个GUID
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
