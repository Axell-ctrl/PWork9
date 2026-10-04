//*****************************************************************************************************************************************************************************
//*Практическая работа №9                                                                                                                                                     *
//*Сделал Егоров Н.Н, группа 2-ИСП                                                                                                                                            *
//*Задание: объявить массивы, заполнить первые 2 массива случайными числами в диапазоне, сложить их поэлементно в 3 массив, найти среднее арифметическое элементов 3 массива. *
//*****************************************************************************************************************************************************************************

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
            bool ExitProgram = false;//флаг для выхода из программы
            try
            {
                while (true)
                {
                    Console.Write("Введите количество элементов трёх массивов: ");
                    string input = Console.ReadLine();
                    if (!Int32.TryParse(input, out int ElementsCount))//если пользователь ввёл буквы или другие символы вместо числа
                    {
                        Console.WriteLine("Вы ввели буквы или другие символы вместо числа. Попробуйте ещё раз.");//выводится сообщение об ошибке и просьбой попробовать ещё раз
                        continue;//начинается следующая итерация цикла
                    }
                    if (ElementsCount <= 0)//если пользователь ввёл число меньшее или равное 0
                    {
                        Console.WriteLine($"Вы ввели: {ElementsCount}. Количество элементов должно быть больше нуля. Попробуйте ещё раз.");//выводится сообщение об ошибке и просьбой попробовать ещё раз
                        continue;//начинается следующая итерация цикла
                    }
                    int[] A = new int[ElementsCount];//создание массива A с количеством элементов, заданным пользователем
                    int[] B = new int[ElementsCount];
                    int[] C = new int[ElementsCount];
                    int sum = 0, SR = 0;
                    Random rnd = new Random();//инициализация генератора случайных чисел

                    for (int i = 0; i < A.Length; i++)//перебор массива по индексам элементов, A.Length - кол-во элементов массива A
                    {
                        A[i] = rnd.Next(10, 31);//генерация чисел в массив A с интервалом [10,31)
                        B[i] = rnd.Next(10, 31);//генерация чисел в массив B с интервалом [10,31)
                    }

                    for (int i = 0; i < C.Length; i++)//перебор массива по индексам элементов, C.Length - кол-во элементов массива C
                    {
                        C[i] = A[i] + B[i];//сложение чисел из массива A и B в массив C
                    }

                    for (int i = 0; i < C.Length; i++)
                    {
                        sum += C[i];//складывается сумма из всех элементов массива C
                    }

                    SR = sum / ElementsCount;//расчёт среднего арифметического 3 массива (сумма элементов 3 массива разделить на кол-во элементов 3 массива)
                    Console.WriteLine($"\nСреднее арифметическое 3 массива: {SR}");

                    while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        string input2 = Console.ReadLine();
                        if (!Int32.TryParse(input2, out int answer))
                        {
                            Console.WriteLine("Вы ввели буквы или другие символы вместо числа. Попробуйте ещё раз.");
                            continue;
                        }
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            continue;//продолжает итерацию внутреннего цикла
                        }
                        else//иначе
                        {
                            if (answer == 0)//если ответ пользователя равен 0
                            {
                                ExitProgram = true;//флаг выхода из программы становится истинным
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
            catch (IndexOutOfRangeException iorex)//обработчик исключения IndexOutOfRangeException (Индекс находился вне границ массива)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Что-то пошло не так! Ошибка: {iorex.Message}");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Индекс находился вне границ массива.
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
