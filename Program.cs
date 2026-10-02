//********************************************************************************************************************************************************************
//*Практическая работа №9                                                                                                                                            *
//*Сделал Егоров Н.Н, группа 2-ИСП                                                                                                                                   *
//*Задание: объявить массивы, заполнить случайными числами в диапазоне, сложить элементы 1 и 2 массива в 3 массив, найти среднее арифметическое элементов 3 массива. *
//********************************************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №9";//задаёт значение в заголовок консоли

            Console.WriteLine("Здравствуйте!");

            try
            {
                Console.WriteLine("Введите положительное количество элементов 1 массива: ");
                int arr1 = Int32.Parse(Console.ReadLine());
                if (arr1 <= 0) 
                {
                    Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");
                }
                Console.WriteLine("Введите количество элементов 2 массива: ");
                int arr2 = Int32.Parse(Console.ReadLine());
                int arr3 = arr2;
                int[] A = new int[arr1];
                int[] B = new int[arr2];
                int[] C = new int[arr3];
                while (true)
                {
                    int sum = 0, SR = 0, i_max = 0;
                    bool ExitProgram = false;
                    Random rnd = new Random();
                    for (int i = 0; i < A.Length; i++)
                    {
                        A[i] = rnd.Next(10, 31);
                    }
                    for (int i = 0; i < B.Length; i++)
                    {
                        B[i] = rnd.Next(10, 31);
                    }
                    for (int i = 0; i < C.Length; i++)
                    {
                        C[i] = A[i] + B[i];
                    }
                    for (int i = 0; i < C.Length; i++)
                    {
                        sum += C[i];
                        if (i > i_max)
                        {
                            i_max = i;
                        }
                    }
                    SR = sum / i_max;
                    Console.WriteLine($"\nСреднее арифметическое 3 массива: {SR}");
                    while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            continue;//продолжает итерацию внутреннего цикла
                        }
                        else//иначе
                        {
                            if (answer == 0)//если ответ пользователя равен 0
                            {
                                ExitProgram = true;//выход программы становится истинным
                                Console.WriteLine("Завершение программы.");//выводится сообщение: Завершение программы.
                            }
                            break;
                        }
                    }
                    if (ExitProgram == true)//если выход из программы является истинным
                        break;//завершается внешний цикл
                }
                Console.ReadKey();
            }
            catch (IndexOutOfRangeException iorex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Что-то пошло не так! Ошибка: {iorex.Message}");  
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message}");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message}");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message}");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
