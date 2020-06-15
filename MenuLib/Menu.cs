using System;

namespace MenuLib
{
    /// <summary>
    /// Класс Menu конструирует консольное меню на основе переданного ему массива делегатов.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Делегат delMenu.
        /// </summary>
        public delegate void delMenu();
        private delMenu[] delMenus;

        /// <summary>
        /// Конструктор в качестве параметра принимает массив делегатов delMenu.
        /// </summary>
        /// <param name="delegates">Массив делегатов delMenu.</param>
        public Menu(delMenu[] delegates)
        {
            delMenus = delegates;
        }

        /// <summary>
        /// Метод создает консольное меню и ожидает ввода номера задания, после чего запускает выбранный метод.
        /// </summary>
        public void ChooseMenu()
        {
            int num;
            do
            {
                num = 1 ;
                Console.WriteLine($"Для выбора задания введите номер задания от 1 до {delMenus.Length}");
                foreach (delMenu del in delMenus)
                {
                    Console.WriteLine(num++ + " - " + del.Method.Name);
                }
                Console.WriteLine("Для выхода из меню нажмите 0");
                try
                {
                    bool b;
                    do
                    {
                        b = int.TryParse(Console.ReadLine(), out num);
                        if (!b) Console.WriteLine("Ошибка ввода данных, введите целое число!");
                    } while (!b);
                    delMenus[num - 1]();
                    Console.Clear();
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (num != 0);
        }
    }

    /// <summary>
    /// Класс содержит методы для ускорения работы с консолью.
    /// </summary>
    public static class FastConsole
    {
        /// <summary>
        /// Метод выводит строку и ожидает ввода целого числа, при вводе осуществляется проверка на корректность введенных данных.
        /// </summary>
        /// <param name="str">Выводимая строка.</param>
        /// <param name="num">Возвращаемое целое число.</param>
        public static void Input(string str, out int num)
        {
            Console.WriteLine(str);
            bool b;
            do
            {
                b = int.TryParse(Console.ReadLine(), out num);
                if(!b) Console.WriteLine("Ошибка ввода данных, введите целое число!");
            } while (!b);
        }
        /// <summary>
        /// Метод выводит строку и ожидает ввода вещественного числа, при вводе осуществляется проверка на корректность 
        /// введенных данных.
        /// </summary>
        /// <param name="str">Выводимая строка.</param>
        /// <param name="num">Возвращаемое вещественное число.</param>
        public static void Input(string str, out double num)
        {
            Console.WriteLine(str);
            bool b;
            do
            {
                b = double.TryParse(Console.ReadLine(), out num);
                if (!b) Console.WriteLine("Ошибка ввода данных, введите вещественное число!");
            } while (!b);
        }
        /// <summary>
        /// Метод выводит строку и ожидает ввода новой строки.
        /// </summary>
        /// <param name="str">Выводимая строка.</param>
        /// <returns>Метод возвращает введенную строку.</returns>
        public static string Input(string str)
        {
            Console.WriteLine(str);
            return Console.ReadLine();
        }
        /// <summary>
        /// Метод ожидает нажатия клавиши Enter от пользователя.
        /// </summary>
        public static void Pause()
        {
            Console.ReadLine();
        }
        /// <summary>
        /// Метод очищает консоль и выводит строку в заданные координаты консоли.
        /// </summary>
        /// <param name="str">Выводимая строка.</param>
        /// <param name="x">Координата X.</param>
        /// <param name="y">Координата Y.</param>
        public static void Print(string str, int x, int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }
    }
}
