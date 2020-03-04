using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reg_and_aut
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //while (true)
            //{
            //    String text = Console.ReadLine();
            //    if (text == "0")
            //        break;
            //    Console.WriteLine("Соответствие:  " + login_and_password.CorrectLogin(text).ToString());
            //    Console.WriteLine("Без пробелов внутри: \"" + login_and_password.DelSpaces(text) + "\"");
            //    Console.WriteLine("Без пробелов снаружи: \"" + login_and_password.DelBorderSpaces(text) + "\"");
            //    Console.WriteLine("Без пробелов внутри и снаружи: \"" + login_and_password.DelSpaces(login_and_password.DelBorderSpaces(text)) + "\"");
            //}

            //while(true)
            //{
            //    String text = Console.ReadLine();
            //    if (text == "0")
            //        break;
            //    Console.WriteLine(login_and_password.PasswordScore(text));
            //}

            while (true)
            {
                String text = Console.ReadLine();
                String text2 = Console.ReadLine();
                if (text == "0")
                    break;
                byte[] temp_salt = login_and_password.GetSalt();
                string temp_s_salt = Convert.ToBase64String(temp_salt);
                string temp_s_hash = Convert.ToBase64String(login_and_password.GetHash(text, temp_salt));
                Console.WriteLine(temp_s_salt);
                Console.WriteLine(temp_s_hash);
                Console.WriteLine(login_and_password.VerifyPassword(text2, temp_s_salt, temp_s_hash));
                //Console.WriteLine(Convert.ToInt32(login_and_password.GetSalt().ToString()));
            }
        }
    }
}
