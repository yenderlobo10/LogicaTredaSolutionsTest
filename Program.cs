using System;
using System.Text.RegularExpressions;

namespace TredaSolutionsPruebaTeorica
{
    class Program
    {
        /// <summary>
        /// Enumerable to type problems.
        /// </summary>
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


        // Run problems functions

        static void RunProblems()
        {
            RunProblemOne();
            RunProblemTwo();
            RunProblemThree();

            Console.WriteLine("\n\n >>> Thanks ... Developed by ... Yender Vargas <<<\n\n\n");
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

        static void RunProblemThree()
        {
            Console.WriteLine("\n:: Problema 3 ::\n");

            var text = ReadValue("Ingreso texto a transformar : ");

            var result = ResolveProblemThree(text);

            ShowProblemResult(Problem.THREE, result);
        }


        // Resolve problems functions

        /// <summary>
        /// Dado un numero n encontrar todos los múltiplos de 3 y 5 
        /// menores al número dado.
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
        /// Se debe implementar una función camel case que transforme la 
        /// oración.
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

                    textToTransform += word.Length > 1 ?
                        word.Substring(1, word.Length - 1) :
                        string.Empty;
                }
            }

            return textSplit[0] + textToTransform;
        }


        /// <summary>
        /// Dada una frase, devolver la frase donde las palabras con mayor 
        /// a 5 letras esten al revés.
        /// </summary>
        /// <param name="textToTransform"></param>
        /// <returns></returns>
        public static string ResolveProblemThree(string textToTransform)
        {
            if (string.IsNullOrWhiteSpace(textToTransform))
            {
                throw new ArgumentException("Texto no valido.");
            }

            var textSplit = textToTransform.Split(' ');
            textToTransform = string.Empty;

            foreach (var word in textSplit)
            {
                textToTransform += IsValidWordToReverse(word) ?
                    ReverseWord(word) : // With linq word.Reverse()
                    word;

                textToTransform += " ";
            }


            return textToTransform;
        }


        // Utility functions

        static bool CheckMultiplo(int n, int m) => n % m == 0;

        static bool IsValidTextFormatCamelCase(string text) =>
            Regex.IsMatch(text, @"[a-zA-Z\s-_]");

        static bool IsValidWordToReverse(string word) => word.Length > 5;

        static string ReverseWord(string word)
        {
            string reverse = string.Empty;

            for (int i = (word.Length - 1); i >= 0; i--)
            {
                reverse += word[i];
            }

            return reverse;
        }



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
                    return "=> " +
                        $"El textto transformado : {replaces[0]}";

                default:
                    throw new ArgumentException();
            }
        }
    }
}
