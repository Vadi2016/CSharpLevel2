using System;

using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace MyHomeWorkL2
{
    public static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;  // буфер
        static public BaseObject[] objs;        // массив звезд
        static public BaseObject[] asteroids;        // массив астероидов
        static public BaseObject[] bullet;        // массив пуль

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
            Graphics g;   // Графическое устройство для вывода графики

            Load();  // вызов метода Load, заполняющего массив

            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();  // Создаём объект - поверхность рисования и связываем его с формой

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
            string path = Path.GetFullPath("Rosette_nebula_Lanoue.png");    // Путь к файлу

            // Проверяем вывод графики
            Image newImage = Image.FromFile(path);
            buffer.Graphics.DrawImage(newImage, 0, 0, Width, Height);

            // Рисуем объекты
            /* 
             * foreach (BaseObject obj in objs)
                obj.Draw();
             */
            foreach (Asteroid obj in asteroids)
                obj.Draw();
            foreach (Bullet obj in bullet)
                obj.Draw();

            buffer.Render();
        }
        /// <summary>
        /// Обновление позиции каждой звезды.
        /// </summary>
        static public void Update()
        {
            //foreach (BaseObject obj in objs)
            //obj.Update();
            foreach (Asteroid a in asteroids)
            {
                foreach (Bullet b in bullet)
                {
                    a.Update();
                    b.Update();
                    if (a.Collision(b)) { System.Media.SystemSounds.Hand.Play(); b.New(); a.New(); }
                }
            }

        }
        /// <summary>
        /// Загрузка в массива установленных звезд, пуль и астероидов.
        /// </summary>
        static public void Load()
        {
            //objs = new BaseObject[40];
            asteroids = new Asteroid[10];
            bullet = new Bullet[10];

            int astH = Execut(10);
            int astW = Execut(-10);     //  Неверный размер! Должен быть 10.

            int bulH = Execut(5);
            int bulW = Execut(5);

            // Астероиды
            for (int i = 0; i < asteroids.Length / 2; i++)
                asteroids[i] = new Asteroid(new Point(790, (Height / 2) + 10), new Point(i, i), new Size(astW, astH));
            // Астероиды
            for (int i = asteroids.Length / 2; i < asteroids.Length; i++)
                asteroids[i] = new Asteroid(new Point(790, (Height / 2) + 10), new Point(i, -i), new Size(astW, astH));

            // Пули
            for (int i = 0; i < bullet.Length / 2; i++)
                bullet[i] = new Bullet(new Point(10, (Height / 2) + 10), new Point(i, i), new Size(bulW, bulH));
            // Пули
            for (int i = bullet.Length / 2; i < bullet.Length; i++)
                bullet[i] = new Bullet(new Point(10, (Height / 2) + 10), new Point(i, -i), new Size(bulW, bulH));

            #region // Создание звезд   //
            /*
            //  Звезды-кресты 
            for (int i = 0; i < objs.Length / 4; i++)
                objs[i] = new StarNew(new Point(400, 300), new Point(-i, -i), new Size(5, 5));
            //  Золотые звезды
            for (int i = objs.Length / 4; i < (objs.Length * 2) / 4; i++)
                objs[i] = new Star(new Point(400, 300), new Point(i, i), new Size(5, 5));
            //  Звезды-кресты
            for (int i = (objs.Length * 2) / 4; i < (objs.Length * 3) / 4; i++)
                objs[i] = new StarNew(new Point(400, 300), new Point(i, -i), new Size(5, 5));
            //  Звезды-кресты
            for (int i = (objs.Length * 3) / 4; i < objs.Length; i++)
                objs[i] = new StarNew(new Point(400, 300), new Point(-i, i), new Size(5, 5));
            */
            #endregion

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

        /// <summary>
        /// Срабатываемое исключение на ошибку размера.
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        static int Execut(int width)
        {
            try
            {

                if (width < 0) throw new MyException();
                return width;
            }
            catch (MyException)
            {
                return width = 10;
            }
        }
    }
}
