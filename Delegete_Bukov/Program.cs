using System;

namespace Delegete_Bukov
{
    internal class Program
    {
        delegate int MyDelegate(int x, int y);

        static int Add(int x, int y)
        {
            return x + y;
        }
        
        static int Multiplication(int x, int y)
        {
            return x * y;
        }

        static int Division(int x, int y)
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                throw new DivideByZeroException("can't devide by zero");
            }
        }
        
        // метод принимающий делегат в качестве аргумента
        static void Print(MyDelegate del)
        {
            Console.WriteLine("Введите первое число: ");
            int x = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите второе число: ");
            int y = Convert.ToInt32(Console.ReadLine());
            
            int result = del(x, y);
            Console.WriteLine($"Результат: {result}");
        }
        
        // метод multicast 
        static void Multicast(MyDelegate del, int x, int y)
        {
            Console.WriteLine("Выполнение нескольких фукций при помощи метода multicast");
            Delegate [] delArray = del.GetInvocationList();

            foreach (MyDelegate method in delArray)
            {
                // информация о методе
                System.Reflection.MethodInfo methodInfo = method.Method;
                //имя метода
                string methodName = methodInfo.Name;
                //вызов методов и вывод результата
                int result = method(x, y);
                Console.WriteLine($"Результат выполнения {methodName}: {result}");
            }
        }
        
        public static void Main(string[] args)
        {
            MyDelegate del = Add;
            Console.WriteLine("Тестирование метода, принимающего делегат в качестве аргумента:");
            Print(del);
            
            int x = 10;
            int y = 5;

            del += Multiplication;
            del += Division;
            
            Console.WriteLine("\nТестирование метода multicast:");
            Multicast(del, x, y);
        }
    }
}