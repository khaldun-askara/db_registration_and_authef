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

            while (true)
            {
                String text = Console.ReadLine();
                if (text == "0")
                    break;
                Console.WriteLine("Соответствие:  " + login_and_password.CorrectLogin(text).ToString());
                Console.WriteLine("Без пробелов внутри: \"" + login_and_password.DelSpaces(text) + "\"");
                Console.WriteLine("Без пробелов снаружи: \"" + login_and_password.DelBorderSpaces(text) + "\"");
                Console.WriteLine("Без пробелов внутри и снаружи: \"" + login_and_password.DelSpaces(login_and_password.DelBorderSpaces(text)) + "\"");
            }
        }
    }
}
