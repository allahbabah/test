using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = Order("3 16 9 38 95 1131268 49455 347464 59544965313 496636983114762 85246814996697");

            Console.WriteLine(data);
            



        }
        static string Order(string input)
        {
            List<long> listOfNumber = new List<long>();
            string result;
            string [] numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < numbers.Length; i++)
            {
                listOfNumber.Add(long.Parse(numbers[i]));
            }
            for (int i = 0; i < listOfNumber.Count-1; i++)
            {
                for (int j = i+1; j < listOfNumber.Count; j++)
                {
                    long sumFirstNum = 0; 
                    long sumSecondNum = 0;
                    long firstNumber = listOfNumber[i];
                    long secondNumber = listOfNumber[j];
                    while (firstNumber > 0) 
                    {
                        long digit = firstNumber % 10;
                        sumFirstNum += digit;
                        firstNumber /= 10;
                    }
                    while (secondNumber > 0)
                    {
                        long digit = secondNumber % 10;
                        sumSecondNum += digit;
                        secondNumber /= 10;
                    }
                    if (sumFirstNum > sumSecondNum)
                    {
                        long temp = listOfNumber[j];
                        listOfNumber[j] = listOfNumber[i];
                        listOfNumber[i] = temp;
                    }
                    else if(sumFirstNum == sumSecondNum)
                    {
                        firstNumber = listOfNumber[i];
                        secondNumber = listOfNumber[j];
                        long firstNumDigit = FindFirstDigit(firstNumber);
                        long secondNumDigit = FindFirstDigit(secondNumber);
                        if(firstNumDigit > secondNumDigit)
                        {
                            long temp = listOfNumber[j];
                            listOfNumber[j] = listOfNumber[i];
                            listOfNumber[i] = temp;
                        }
                    }
                }
            }
            result = string.Join(" ", listOfNumber);



            return result;
        }
        static long FindFirstDigit (long number)
        {
            while (number >= 10)
            {
                number /= 10;
            }
            return number;
        }
    }
}
