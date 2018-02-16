using System;
using System.Windows.Forms;

namespace MyHomeWorkL2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form); // передаем размеры формы
            form.Show();
            Game.Draw();    // вызов рисования 
            Application.Run(form);
            Console.ReadKey();
        }
    }
}
