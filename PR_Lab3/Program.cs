using System;
using System.IO;
using System.Linq;

namespace PR_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] myArray = GetValuesFromFile();

            int A = 0, B=0, C=0;

            Console.WriteLine("Кондорсе method:\n");
            A = CompareCandidatesAndGetBetter(myArray , "A", "C") == "A" ? A++ : C++;
            B = CompareCandidatesAndGetBetter(myArray, "A", "B") == "A" ? A++ : B++;
            C = CompareCandidatesAndGetBetter(myArray, "B", "C") == "C" ? C++ : B++;
            PrintResult(A, B, C);

            Console.WriteLine("\n<--------------->\nБорда method:\n");
            string[] tempArray = new string[] { "A", "B", "C" };
            int[] tempArrayValue = new int[] { 0, 0, 0 };

            for (int mda = 0; mda < tempArray.Length; mda++)
            {
                for (int i = 0; i < myArray.Length; i++)
                {

                    tempArrayValue[mda] += Array.IndexOf(myArray[i], tempArray[mda]) == 1 ? 3 * Convert.ToInt32(myArray[i][0]) :
                        Array.IndexOf(myArray[i], tempArray[mda]) == 3 ? 1 * Convert.ToInt32(myArray[i][0]) : 2 * Convert.ToInt32(myArray[i][0]);
                }

                Console.WriteLine("Candidate {0} has {1} points",tempArray[mda],tempArrayValue[mda]);
            }
            A = tempArrayValue[0];
            B = tempArrayValue[1];
            C = tempArrayValue[2];

            PrintResult(A, B, C);
        }

        private static string[][] GetValuesFromFile()
        {
            var directory = System.IO.Directory.GetCurrentDirectory();
            string[][] values = File
                  .ReadLines(@$"{directory}\\Inputs.txt").Select(x => (x.Split(' ').ToArray())).ToArray();

            return values;
        }

        private static string CompareCandidatesAndGetBetter( string[][] myArray, string candidate1, string candidate2)
        {
            int candidate1Value=0;
            int candidate2Value = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                if (Array.IndexOf(myArray[i], candidate1) < Array.IndexOf(myArray[i], candidate2))
                {
                    candidate1Value += Convert.ToInt32(myArray[i][0]);
                }
                else
                {
                    candidate2Value += Convert.ToInt32(myArray[i][0]);
                }
            }

            Console.WriteLine("Compare {0} and {1}.... Result is {0}={2}, {1}={3}",candidate1,candidate2,candidate1Value,candidate2Value);

            if (candidate1Value > candidate2Value)
            {
                Console.WriteLine("{0} > {1}\n---\n",candidate1,candidate2);
                return candidate1;
            }
            else
            {
                Console.WriteLine("{1} > {0}\n----\n", candidate1, candidate2);
                return candidate2;
            }
        }

        static void PrintResult(int A, int B, int C)
        {
            Console.WriteLine("Результат:");
            if (A > B)
            {
                if (A > C)
                {
                    if (B > C)
                        Console.WriteLine("A >  B > C ");
                    else
                        Console.WriteLine("A >  C > B ");
                }
            }
            else if (B > C)
            {
                if (A > C)
                    Console.WriteLine("B >  A > C ");
                else
                    Console.WriteLine("B >  C > A ");
            }
            else
            {
                if (A > B)
                    Console.WriteLine("C >  A > B ");
                else
                    Console.WriteLine("C >  B > A ");
            }
        }
    }
}
