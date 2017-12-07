using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuilderBuilderWebApp.BusinessLogic
{
    public static class Extensions
    {
        public static string Privatize(this string s)
        {
            string camelCase = "_" + char.ToLower(s[0]) + s.Substring(1);
            return camelCase;
        }
    }
}