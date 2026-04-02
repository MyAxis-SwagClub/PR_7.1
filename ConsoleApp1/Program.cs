using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_7
{
    internal class Program
    {
        /// <summary>
        /// Основной класс консольного приложения, объединяющего задания практической работы 7.
        /// Реализует текстовое меню для последовательного запуска трёх демонстрационных программ:
        /// «Числа Фибоначчи», «Галактики» и «Буквы».
        /// Каждая из программ служит примером для изучения возможностей отладчика Microsoft Visual Studio.
        /// </summary>
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Введите цифру для выбора: \n 1 - Числа Фибоначчи \n 2 - Галактики \n 3 - Буквы");
                Console.Write("Введите цифру для начала: ");
                int choose_input = Convert.ToInt32(Console.ReadLine());
                switch (choose_input) {
                    case 1: Fibonacci_start_programm();
                        break;
                    case 2: Galaxy_start_programm();
                        break;
                    case 3: Letters_start_programm();
                        break;
                    case 0: Console.WriteLine("\n Завершение работы программы...");
                        return;
                }

                Console.WriteLine(" \n Нажмите любую кнопку для возврата в начальное меню... \n ");
                Console.ReadLine();
            }
        }

        // ЗАДАНИЕ 1 — ЧИСЛА ФИБОНАЧЧИ

        /// <summary>
        /// Запускает модуль «Числа Фибоначчи».
        /// Программа запрашивает у пользователя индекс <c>n</c> и выводит последовательность от F(0) до F(n).
        /// </summary>
        /// <remarks>
        /// Демонстрация средств отладки Visual Studio:
        /// <list type="bullet">
        ///   <item><b>Точки останова</b> — в рекурсивном методе <see cref="Fibonacci"/>.</item>
        ///   <item><b>Стек вызовов</b> — для контроля глубины рекурсии.</item>
        ///   <item><b>Окно "Локальные"</b> — наблюдение за параметром <c>n</c>.</item>
        ///   <item><b>Пошаговый режим (F11/F10)</b> — управление выполнением кода.</item>
        ///   <item><b>Подсказки данных (Data Tips)</b> — мгновенный просмотр значений.</item>
        /// </list>
        /// </remarks>

        static void Fibonacci_start_programm()
        {
            Console.Clear();
            Console.WriteLine("\nПрограмма #1: Числа Фибоначчи");
            Console.WriteLine("Введите порядковый номер Фибаноччи: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Ошибка!! Введно отрицательное число или пустое число.");
                return;
            }

            Console.WriteLine($"(0 .. {n}):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write(Fibonacci_Number_equal(i));
                if (i < n)
                    Console.Write(", ");
            }
            Console.WriteLine($"\n\nF({n}) = {Fibonacci_Number_equal(n)}");
        }

        static int Fibonacci_Number_equal(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n),"Ошибка! Индекс отрицателен.");
            if (n == 0) return 0; if (n == 1) return 1; return Fibonacci_Number_equal(n - 1) + Fibonacci_Number_equal(n - 2);
        }

        /// <summary>
        /// Рекурсивным способом вычисляет указанный элемент последовательности Фибоначчи.
        /// </summary>
        /// <remarks>
        /// Правила построения последовательности:
        /// - Базовые случаи: F(0) = 0, F(1) = 1.
        /// - Рекуррентная формула: F(n) = F(n-1) + F(n-2) для всех n ≥ 2.
        /// 
        /// <b>Важно:</b> из-за экспоненциальной вычислительной сложности O(2^n)
        /// данный метод рекомендуется применять лишь для небольших значений n (например, n ≤ 30).
        /// </remarks>
        /// <param name="n">Порядковый номер искомого числа (n ≥ 0).</param>
        /// <returns>Значение n-го числа Фибоначчи.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Исключение генерируется при передаче отрицательного значения параметра <paramref name="n"/>.
        /// </exception>

        // ЗАДАНИЕ 2 — ГАЛАКТИКИ

        /// <summary>
        /// Запускает программу «Галактики» для вывода информации о галактиках.
        /// </summary>
        /// <remarks>
        /// При отладке исправлены две ошибки:
        /// 1. Тип свойства GalaxyType изменён с object на GType (вместо типа выводилось имя класса).
        /// 2. В конструкторе GType исправлена опечатка: 'l' заменено на 'I' (тип Irregular не работал).
        /// 
        /// Инструменты отладки: точки останова, Data Tips, F11, Edit and Continue, Ctrl+Shift+F5.
        /// </remarks>


        static void Galaxy_start_programm()
        {
            Console.Clear();
            Console.WriteLine("\n Программа #2: Галактики! \n");

            var galaxies = new List<Galaxy>
        {
            new Galaxy { Name = "Tadpole",                MegaLightYears = 400, GalaxyType = new GType('S') },
            new Galaxy { Name = "Pinwheel",               MegaLightYears = 25,  GalaxyType = new GType('S') },
            new Galaxy { Name = "Cartwheel",              MegaLightYears = 500, GalaxyType = new GType('L') },
            new Galaxy { Name = "Small Magell.", MegaLightYears = 0.2, GalaxyType = new GType('I') },
            new Galaxy { Name = "Andromeda",              MegaLightYears = 3,   GalaxyType = new GType('S') },
            new Galaxy { Name = "Maffei 1",               MegaLightYears = 11,  GalaxyType = new GType('E') }
        };

            Console.WriteLine($"{"| Название: |",-5}{" | Расстояние в Миллионах световых лет | ",16}{" | Вид/Тип | ",13}");
            Console.WriteLine(new string('=', 100));

            foreach (Galaxy g in galaxies)
            {Console.WriteLine($"{g.Name,-5}{g.MegaLightYears,20}{g.GalaxyType.MyGType,30}");}
        }

        /// <summary>
        /// Представляет галактику с именем, расстоянием и морфологическим типом.
        /// </summary>
        /// 
        class Galaxy
        {
            public string Name { get; set; }
            public double MegaLightYears { get; set; }
            public GType GalaxyType { get; set; }
        }

        class GType
        {
            public enum GalaxyTypeEnum { Spiral, Elliptical, Irregular, Lenticular }
            public GalaxyTypeEnum MyGType { get; set; }

            public GType(char type)
            {
                switch (type)
                {
                    case 'S': MyGType = GalaxyTypeEnum.Spiral; break;
                    case 'E': MyGType = GalaxyTypeEnum.Elliptical; break;
                    case 'I': MyGType = GalaxyTypeEnum.Irregular; break;  /// Исправление (было: l, стало i)
                    case 'L': MyGType = GalaxyTypeEnum.Lenticular; break;
                }
            }
        }





        // ЗАДАНИЕ 3 — БУКВЫ

        /// <summary>
        /// Запускает приложение «Буквы».
        /// Последовательно перебирает массив символов, формируя на каждом шаге строку <c>name</c>,
        /// после чего вызывает метод <see cref="SendMessage"/>.
        /// </summary>
        static void Letters_start_programm()
        {
            Console.Clear();
            Console.WriteLine(" \n риложение #3: Буквы");

            char[] letters = { 'f', 'r', 'e', 'd', ' ', 's', 'm', 'i', 't', 'h' };
            string name = "";
            int[] a = new int[10];

            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
                a[i] = i + 1;
                SendMessage(name, a[i]);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Отображает приветствие, содержащее накопленное имя и номер итерации.
        /// </summary>
        /// <param name="name">
        /// Накопленная строка, формируемая последовательно в методе <see cref="RunLetters"/>.
        /// </param>
        /// <param name="msg">
        /// Номер текущей итерации (нумерация начинается с 1).
        /// </param>
        /// <example>
        /// Пример вызова: <c>SendMessage("f", 1)</c> → вывод: <c>Hello, f! Count to 1</c>
        /// </example>

        static void SendMessage(string name, int msg)
        {
            Console.WriteLine("Hello, " + name + "! Count to " + msg);
        }
    }
}