using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            double divisor, dividend;
            double result = -1;
            String resultWithQues = "-1";
            string[] splitString = equation.Split('=');
            if (splitString[0].Contains("?"))
            {
                string[] splitPart1 = splitString[0].Split('*');

                if (splitPart1[0].Contains("?"))
                {
                    divisor = int.Parse(splitPart1[1]);
                    dividend = int.Parse(splitString[1]);
                    resultWithQues = splitPart1[0];
                    result = dividend / divisor;
                }
                else
                {
                    divisor = int.Parse(splitPart1[0]);
                    dividend = int.Parse(splitString[1]);
                    resultWithQues = splitPart1[1];
                    result = dividend / divisor;
                }
            }
            else
            {
                string[] splitPart2 = splitString[0].Split('*');
                divisor = int.Parse(splitPart2[0]);
                dividend = int.Parse(splitPart2[1]);
                result = divisor * dividend;
                resultWithQues = splitString[1];
            }

            char[] finalResult = resultWithQues.ToCharArray();
            char[] number = result.ToString().ToCharArray();
            if (result % 1 != 0 || finalResult.Length != number.Length)
            {
                return -1;
            }
            else
            {
                int index = Array.IndexOf(finalResult, '?');
                return int.Parse(number[index] + "");
            }

        }
    }
}
