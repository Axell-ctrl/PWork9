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
            Console.Write("Размерность 3 массивов равна 10.");
            bool ExitProgram = false;//флаг для выхода из программы
            Random rnd = new Random();//создание генератора случайных чисел
            while (true)
            {
                try
                {
                    const int ElementsCount = 10;
                    int[] A = new int[ElementsCount];//создание массива A с количеством элементов, заданным пользователем
                    int[] B = new int[ElementsCount];
                    int[] C = new int[ElementsCount];
                    int sum = 0;
                    double average = 0;

                    Console.Write($"\nЭлементы 1 массива:\t");
                    for (int i = 0; i < A.Length; i++)
                    {
                        A[i] = rnd.Next(10, 31);//генерация чисел в массив A с интервалом [10,31)
                        Console.Write(A[i] + "\t");//вывод массива A по индексам (по очереди)
                    }

                    Console.Write($"\nЭлементы 2 массива:\t");
                    for (int i = 0; i < B.Length; i++)
                    {
                        B[i] = rnd.Next(10, 31);//генерация чисел в массив B с интервалом [10,31)
                        Console.Write(B[i] + "\t");//вывод массива B по индексам (по очереди)
                    }

                    Console.Write("\nЭлементы 3 массива:\t");
                    for (int i = 0; i < C.Length; i++)
                    {
                        C[i] = A[i] + B[i];//поэлементная сумма первых 2 массивов A и B в 3 массив C
                        Console.Write(C[i] + "\t");////вывод массива C по индексам (по очереди)
                        sum += C[i];//складывается сумма из всех элементов массива C
                    }

                    average = (double)sum / ElementsCount;//расчёт среднего арифметического 3 массива (сумма элементов 3 массива разделить на кол-во элементов 3 массива)

                    //Console.WriteLine("\nСреднее арифметическое 3 массива: {0:0.##}", average);//вывод с 2 знаками после запятой с помощью маски
                    Console.WriteLine($"\nСреднее арифметическое 3 массива: {Math.Round(average, 2)}");//вывод с 2 знаками после запятой c помощью Math.Round()
                }
                catch (IndexOutOfRangeException iorex)//обработчик исключения IndexOutOfRangeException (Индекс находился вне границ массива)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {iorex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Индекс находился вне границ массива.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                {
                    try
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            Console.ForegroundColor = ConsoleColor.White;
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
                    catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }

                if (ExitProgram == true)//если выход из программы является истинным
                    break;//завершается внешний цикл

            }
            Console.ReadKey();
        }
    }
}
