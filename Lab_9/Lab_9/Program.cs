using System;
using System.IO;
using System.Reflection.Emit;

namespace Lab_9
{
    class BackpackProblem
    {

        static int Backpack(int[] weights, int[] values, int n, int W)
        {
            int[,] K = new int[n + 1, W + 1];


            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weights[i - 1] <= w)
                        K[i, w] = Math.Max(values[i - 1] + K[i - 1, w - weights[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }

        static void SolveBackpackProblem(string inputFilePath, string outputFilePath)
        {

            string[] lines = File.ReadAllLines(inputFilePath);
            string[] firstLine = lines[0].Split(' ');
            int W = int.Parse(firstLine[0]);
            int n = int.Parse(firstLine[1]);
            int[] values = new int[n];
            int[] weights = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] data = lines[i + 1].Split(' ');
                values[i] = int.Parse(data[0]);
                weights[i] = int.Parse(data[1]);
            }

            int result = Backpack(weights, values, n, W);

            File.WriteAllText(outputFilePath, result.ToString());
        }


        public static void Main()
        {
            string inputFilePath = "D://LAB_TA//Lab_9//Lab_9//test_data//input_100.txt";
            string outputFilePath = "D://LAB_TA//Lab_9//Lab_9//test_data//test_output_100.txt";
            SolveBackpackProblem(inputFilePath, outputFilePath);
        }
    }
}
