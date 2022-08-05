using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = Order("300000000 111");

            Console.WriteLine(data);
            



        }
        static string Order(string input)
        {
            List<int> listOfNumber = new List<int>();
            string result;
            string [] numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < numbers.Length; i++)
            {
                listOfNumber.Add(int.Parse(numbers[i]));
            }
            for (int i = 0; i < listOfNumber.Count-1; i++)
            {
                for (int j = i+1; j < listOfNumber.Count; j++)
                {
                    int sumFirstNum = 0; 
                    int sumSecondNum = 0;
                    int firstNumber = listOfNumber[i];
                    int secondNumber = listOfNumber[j];
                    while (firstNumber > 0) 
                    {
                        int digit = firstNumber % 10;
                        sumFirstNum += digit;
                        firstNumber /= 10;
                    }
                    while (secondNumber > 0)
                    {
                        int digit = secondNumber % 10;
                        sumSecondNum += digit;
                        secondNumber /= 10;
                    }
                    if (sumFirstNum > sumSecondNum)
                    {
                        int temp = listOfNumber[j];
                        listOfNumber[j] = listOfNumber[i];
                        listOfNumber[i] = temp;
                    }
                    else if(sumFirstNum == sumSecondNum)
                    {
                        firstNumber = listOfNumber[i];
                        secondNumber = listOfNumber[j];
                        double firstNumDigit = FindFirstDigit(firstNumber);
                        double  secondNumDigit = FindFirstDigit(secondNumber);
                        if(firstNumDigit > secondNumDigit)
                        {
                            int temp = listOfNumber[j];
                            listOfNumber[j] = listOfNumber[i];
                            listOfNumber[i] = temp;
                        }
                    }
                }
            }
            result = string.Join(" ", listOfNumber);



            return result;
        }
        static int FindFirstDigit (int number)
        {
            while (number >= 10)
            {
                number /= 10;
            }
            return number;
        }
    }
}
