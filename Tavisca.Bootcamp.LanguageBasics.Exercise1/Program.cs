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
            double result = -1;
            String resultWithQuestionMark = "-1";

            //split string on basis of =
            string[] splitString = equation.Split('=');

            try
            {
                //check whether first part of splitstring contains ?
                if (splitString[0].Contains("?"))
                {
                    //splitting first part of string on basis of *
                    string[] firstPartSplit = splitString[0].Split('*');

                    //checking whether first part of firstpartsplit contains ?
                    //If yes then split on basis of ?
                    if (firstPartSplit[0].Contains("?"))
                    {
                        resultWithQuestionMark = firstPartSplit[0];
                        result = divide(splitString[1], firstPartSplit[1]);
                    }
                    else
                    {
                        resultWithQuestionMark = firstPartSplit[1];
                        result = divide(splitString[1], firstPartSplit[0]);
                    }
                }
                else
                {
                    //splitting first part on basis of *
                    string[] secondPartSplit = splitString[0].Split('*');
                    result = multiply(secondPartSplit[1], secondPartSplit[0]);
                    resultWithQuestionMark = splitString[1];
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.GetType().Name);
            }

            char[] finalResult = resultWithQuestionMark.ToCharArray();
            char[] number = result.ToString().ToCharArray();

            //checking whether result should not be equal to 0 and 
            //final result length should be equal to result obtained
            if (result % 1 != 0 || finalResult.Length != number.Length)
            {
                return -1;
            }
            else
            {
                //returning number obtained in place of question mark
                int index = Array.IndexOf(finalResult, '?');
                return int.Parse(number[index] + "");
            }
        }

        //method for division of two numbers
        public static double divide(string numb1, string numb2)
        {
            try
            {
                return int.Parse(numb1) / int.Parse(numb2);
            }
            catch
            {
                throw;
            }
            }

        //method for multlipication of two numbers
        public static double multiply(string numb1, string numb2)
        {
            try
            {
                return int.Parse(numb1) * int.Parse(numb2);
            }
            catch {
                throw;
            }
            }
    }
}
