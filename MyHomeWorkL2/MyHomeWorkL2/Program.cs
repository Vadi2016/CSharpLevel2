using System;
using System.Windows.Forms;

namespace MyHomeWorkL2
{
    class MainClass
    {
        static public bool flag = true; // переменная проверяет не была ли нажата кнопка Выход

        static void Main(string[] args)
        {

            Menu();
            if (flag) StartGame();
        }

        /// <summary>
        /// метод вызывающий меню
        /// </summary>
        private static void Menu()
        {
            Application.EnableVisualStyles();
            Application.Run(new SplashScreen());
        }


        /// <summary>
        ///  метод начинающий игру
        /// </summary>
        private static void StartGame()
        {
            Form form = new Form();
            form.Width = 1000;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
