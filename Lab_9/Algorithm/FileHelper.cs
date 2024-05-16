namespace Classes
{
    public class FileHelper
    {
        static void FileHelper(string inputFilePath, string outputFilePath)
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

            int result = Algorithm.Backpack(weights, values, n, W);

            File.WriteAllText(outputFilePath, result.ToString());
        }
    }
}
