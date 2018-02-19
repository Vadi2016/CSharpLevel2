using System;
namespace MyHomeWorkL2
{
    public class MyException : Exception
    {
        /// <summary>
        /// Информация об ошибке.
        /// </summary>
        public MyException()
        {
            Console.WriteLine("Сработало мое исключение!");
            Console.WriteLine("Неверные размеры объекта. Задаю значения по умолчанию.");
            Console.ReadKey();
        }
    }
}
