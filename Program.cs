using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TredaSolutionsPruebaTeorica
{
    class Program
    {
        enum Problem
        {
            ONE, TWO, THREE
        }


        static void Main(string[] args)
        {
            try
            {
                RunProblems();
            }
            catch (Exception ex)
            {
                Console.WriteLine($":: ERROR ::\n{ex.Message}");
            }

            Console.ReadLine();
        }


        static void RunProblems()
        {
            RunProblemOne();
            RunProblemTwo();

            Console.WriteLine("\n\n >>> Developed by ... Yender Vargas <<<\n\n\n");
        }

        static void RunProblemOne()
        {
            Console.WriteLine(":: Problema 1 ::\n");

            var n = int.Parse(ReadValue("Ingrese un número entero : "));
            var result = ResolveProblemOne(n);

            ShowProblemResult(Problem.ONE, 3, 5, n, result);
        }

        static void RunProblemTwo()
        {
            Console.WriteLine("\n:: Problema 2 ::\n");

            var text = ReadValue("Ingrese el texto a convertir en camel case : ");

            if (!IsValidTextFormatCamelCase(text))
                throw new ArgumentException("Texto no valido.");

            var result = ResolveProblemTwo(text);

            ShowProblemResult(Problem.TWO, result);
        }


        // Problems functions

        /// <summary>
        /// Dado un numero n encontrar todos los múltiplos de 3 y 5 menores al número dado.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int ResolveProblemOne(int num)
        {
            int numIncrement = 1;
            int sum = 0;
            int[] numbersToFindMultiplos = { 3, 5 };

            while (numIncrement < num)
            {
                foreach (int n in numbersToFindMultiplos)
                {
                    if (CheckMultiplo(numIncrement, n))
                    {
                        sum += numIncrement;
                    }
                }

                numIncrement++;
            }

            return sum;
        }

        /// <summary>
        /// Dado un string separado por espacios, guiones y guiones bajos. 
        /// Se debe implementar una función camel case que transforme la oración.
        /// </summary>
        /// <param name="textToTransform"></param>
        /// <returns></returns>
        public static string ResolveProblemTwo(string textToTransform)
        {
            textToTransform = Regex.Replace(textToTransform, "[-_]", " ");

            var textSplit = textToTransform.Split(' ');
            textToTransform = string.Empty;

            for (int i = 1; i < textSplit.Length; i++)
            {
                var word = textSplit[i];

                if (!string.IsNullOrWhiteSpace(word))
                {
                    textToTransform += word[0].ToString().ToUpper();
                    textToTransform += word.Length > 1 ? word.Substring(1, word.Length-1) : "";
                }
            }

            return textSplit[0] + textToTransform;
        }

        public static void ResolveProblemThree()
        {

        }


        // Utility functions

        static bool CheckMultiplo(int n, int m) => n % m == 0;

        static bool IsValidTextFormatCamelCase(string text) => 
            Regex.IsMatch(text, @"[a-zA-Z\s-_]");


        static string ReadValue(string message)
        {
            Console.WriteLine(message);

            var value = Console.ReadLine();

            return value;
        }

        static void ShowProblemResult(Problem problem, params object[] replaces)
        {
            Console.WriteLine(
                GetFormatResultProblemMessage(problem, replaces)
            );
        }

        static string GetFormatResultProblemMessage(Problem problem, params object[] replaces)
        {
            switch (problem)
            {
                case Problem.ONE:
                    return "=> " +
                        $"La suma de los multiplos de {replaces[0]} y {replaces[1]} " +
                        $"menores que {replaces[2]} es: {replaces[3]}";

                case Problem.TWO:
                    return "=> " +
                        $"Texto convertido a came case : {replaces[0]}";

                case Problem.THREE:
                    return "=> ";

                default:
                    throw new ArgumentException();
            }
        }
    }
}
