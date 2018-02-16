using System;

using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace MyHomeWorkL2
{
    public class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;  // буфер
        static public BaseObject[] objs;        // массив звезд
        // Свойства
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }
        static Game()
        {
        }
        /// <summary>
        /// Сборка графического окна, установка высоты и ширины окна. Присутствует таймер.
        /// </summary>
        /// <param name="form">Объект класса Form, включающая в себя размеры окна формы.</param>
        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;

            // вызов метода Load, заполняющего массив
            Load();

            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics(); // Создаём объект - поверхность рисования и связываем его с формой

            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;

            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Создание фона на основе фотографии туманности. Вывод каждой звезды на экран через цикл.
        /// </summary>
        static public void Draw()
        {
            //buffer.Graphics.Clear(Color.BlueViolet);     // <---- Скучный фон
            string path = Path.GetFullPath("Звездная_ночь.jpg");


            // Проверяем вывод графики
            Image newImage = Image.FromFile(path);
            buffer.Graphics.DrawImage(newImage, 0, 0, Width, Height);

            // Рисуем объекты
            foreach (BaseObject obj in objs)
                obj.Draw();
            buffer.Render();
        }
        /// <summary>
        /// Обновление позиции каждой звезды.
        /// </summary>
        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }
        /// <summary>
        /// Загрузка в массива установленных звезд.
        /// </summary>
        static public void Load()
        {
            objs = new BaseObject[30];

            //  Звезды-кресты большие
            for (int i = 0; i < objs.Length / 3; i++)
                objs[i] = new BaseObject(new Point(Width, i * 20), new Point(-i, -i), new Size(10, 10));

            //  Золотые звезды
            for (int i = objs.Length / 3; i < (objs.Length * 2) / 3; i++)
                objs[i] = new Star(new Point(Width, i * 20), new Point(-i, 0), new Size(5, 5));

            //  Звезды-кресты маленькие
           // for (int i = (objs.Length * 2) / 3; i < objs.Length; i++)
             //   objs[i] = new StarNew(new Point(Width, i * 20), new Point(-i, 0), new Size(5, 5));
        }
        /// <summary>
        ///  Обработчик таймера.
        /// </summary>
        /// <param name="sender">Объект таймера.</param>
        /// <param name="e">Событие.</param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
