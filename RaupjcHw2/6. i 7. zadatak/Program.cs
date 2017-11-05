using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.i_7.zadatak
{
    class Program
    {
        static async Task<int> FactorialDigitSum(int n)
        {
            Task<int> task = Task.Run(() =>
            {
                int sum = 0;
                int factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;
                }

                while (factorial != 0)
                {
                    sum += factorial % 10;
                    factorial /= 10;
                }

                return sum;
            });

            await task;
            return task.Result;
        }

        private static async Task LetsSayUserClickedAButtonOnGuiMethodAsync()
        {
            var result = await GetTheMagicNumberAsync();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumberAsync()
        {
            return await IKnowIGuyWhoKnowsAGuyAsync();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
        {
            return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
        }

        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            int result = await FactorialDigitSum(n);
            return result;
        }

        // Ignore this part .
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethodAsync());
            Console.Read();
        }
    }
}