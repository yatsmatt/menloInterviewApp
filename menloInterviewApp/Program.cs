using System;
using System.Text;
using System.Text.RegularExpressions;

namespace menloInterviewApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(check("123A1CA3CAFC789"));
        }
        static string check(string txt)
        {
            StringBuilder sanitizesTxt = new StringBuilder();
            const string repalce = "A255C";

            string start = txt.Substring(0, 3);
            string end = txt.Substring(txt.Length - 3, 3);
            var checkStart = @"123";
            var checkMid = @"A[1-9]C";
            var checkEnd = @"789";


            if (Regex.IsMatch(start, checkStart))
            {
                sanitizesTxt.Append(start);
            }
            for (int i = 3; i < txt.Length - 3; i = i + 3)
            {
                if (Regex.IsMatch(txt.Substring(i, 3), checkMid))
                {
                    sanitizesTxt.Append(txt.Substring(i, 3));
                }
                else
                {
                    sanitizesTxt.Append(repalce);
                }
            }
            if (Regex.IsMatch(checkEnd, end))
            {
                sanitizesTxt.Append(end);
            }

            return sanitizesTxt.ToString();
        }

    }
}