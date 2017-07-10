using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Net.Dev.Test.Helper
{
    public class APIKey
    {
        public static string AuthKey { get; } = "token";

        public static bool Authenticate(string key, out int id)
        {
            id = 0;
            if (string.IsNullOrEmpty(key) || string.Compare(key, "T3JjaGFyZEFwaUtleQ==") != 0) return false;
            id = 1;
            return true;
        }
    }
}