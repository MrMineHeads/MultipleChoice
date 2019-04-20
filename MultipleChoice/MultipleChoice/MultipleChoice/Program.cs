using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoice
{
    class Program
    {
        static void Main(string[] args)
        {
            int minRight, totalAnswers, options;
            double chance=0;
            
        Start:
            Console.Write("Please enter number of correct answers: ");

        Start1:
            try
            {
                
                minRight = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.Write("Invalid input. Try again: ");
                goto Start1;
            }

            Console.Write("\nPlease enter number of total questions: ");

        Start2:
            try
            {

                totalAnswers = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.Write("Invalid input. Try again: ");
                goto Start2;
            }

            Console.Write("\nPlease enter number of options per question: ");

        Start3:
            try
            {

                options = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.Write("Invalid input. Try again: ");
                goto Start3;
            }                                           

            for (int i = 0; i < minRight; i++)
            {
                chance += Choose(i, totalAnswers, options);
            }

            chance = 1 - chance;
            Console.WriteLine("\nChance: " + chance);

            goto Start;
            //Console.ReadLine();
        }

        static double Choose(int k, int total, int answers)
        {
            double a, b, c;

            b = Math.Pow((1/(double)answers), k);
            c = Math.Pow((((double)answers - 1)/answers), (total - k));
            a = Combination(total, k) * b * c;
            return a;
        }

        static double Combination(int n, int k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log10(n - i);
                sum -= Math.Log10(i + 1);
            }
            return (double)Math.Pow(10, sum);
        }
    }
}
