using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zxcvbn;
using Zxcvbn.Matcher;

namespace reg_and_aut
{
    class login_and_password
    {
        private static readonly Regex loginRegex = new Regex("^[А-Яа-яA-Za-z \f\n\r\t\v]{8,50}$");

        public static bool CorrectLogin(string login)
        {
            return loginRegex.IsMatch(login);
        }

        public static string DelSpaces(string str)
        {
            Regex spaces = new Regex("[ \f\n\r\t\v]{1,}");
            return spaces.Replace(str, " ");
        }

        public static string DelBorderSpaces(string str)
        {
            Regex spaces1 = new Regex("(?<![^ \f\n\r\t\v])[ \f\n\r\t\v]{1,}(?=[^ \f\n\r\t\v])");
            Regex spaces2 = new Regex("(?<=[^ \f\n\r\t\v])[ \f\n\r\t\v]{1,}(?![^ \f\n\r\t\v])");
            return spaces2.Replace(spaces1.Replace(str, ""), "");
        }

        public static int PasswordScore(string pass)
        {
            var zx = new Zxcvbn.Zxcvbn();
            var result = zx.EvaluatePassword(pass, null);
            return result.Score;
        }
    }
}
