using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = {
            new IndexOutOfRangeException("Выход за пределы массива"),
            new ArgumentNullException("Попытка обратиться к null объекту"),
            new DivideByZeroException("Ошибочное деление на ноль"),
            new ArgumentException("Неверный аргумент"),
            new CustomException("Собственное исключение")
        };

            foreach (var exception in exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Исключение: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Блок finally");
                }
            }
            Console.ReadKey();
        }
    }
}
