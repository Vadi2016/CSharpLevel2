using System;
using System.Windows.Forms;

namespace MyHomeWorkL2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = Execut(1000);        // Ловим ограничение экрана //  Неверный размер! Должен быть 800.
            form.Height = Execut(800);      // Ловим ограничение экрана


            Game.Init(form); // передаем размеры формы
            form.Show();
            Game.Draw();    // вызов рисования 
            Application.Run(form);
            Console.ReadKey();
        }

        /// <summary>
        /// Проверка ввода значений экрана.
        /// </summary>
        /// <param name="width">Передаваемый параметр.</param>
        /// <returns></returns>
        static int Execut(int width)
        {
            try
            {

                if (width < 600 || width > 1000) throw new MyException();
                return width;
            }
            catch (MyException)
            {
                Console.WriteLine("Придерживайтесь размера от 600 до 1000.");
                Console.ReadKey();
                return 600;

            }
        }
    }
}
