using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromText
{
    public static class ExtensionHelper
    {
        public static string[] mList(this string[] message)
        {
            //s.ForEach(x => x.Trim(new char[] { '\r', '\n' }).Trim());
            for (int i = 0; i < message.Length; i++)
            {
                message[i] = message[i].Trim(new char[] { '\r', '\n' }).Trim();
            }
            for (int j = 0; j < message.Length; j++)
            {
                message[j] = message[j].Trim(new char[] { '[', ']' }).Trim();
            }
            //foreach (var a in s)
            //{
            //    a = a.Trim(new char[] { '\r', '\n' }).Trim();
            //}

            return message;
        }
        public static string TrimNewLines(this string message)
        {
            return message.Trim(new char[] { '\r', '\n' }).Trim();

        }

        public static string TrimCharacter(this string message)
        {
            return message.Trim(new char[] { '[', ']' }).Trim();
        }
    }
}
