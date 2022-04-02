
using System.Text;
using System;

public class PunchedCards
{
    public static void Main(string[] args)
    {
        const string row1AStart = "..+";
        const string row1BStart = "..|";
        const string borderStart = "+-+";
        const string rowStart = "|.|";
        const string borderBuild = "-+";
        const string rowBuild = ".|";

        int T = int.Parse(Console.ReadLine());
        int[,] TestCases = new int[T,2];
        for (int i = 0; i < T; i++)
        {
            string input = Console.ReadLine();
            string[] splitInput = input.Split(' ');
            TestCases[i,0] = int.Parse(splitInput[0]);
            TestCases[i,1] = int.Parse(splitInput[1]);
        }

        for (int j = 0; j < TestCases.GetLength(0); j++)
        {
            StringBuilder borderBuilder = new StringBuilder();
            StringBuilder rowBuilder = new StringBuilder();
            for (int c = 1; c < TestCases[j, 1]; c++)
            {
                borderBuilder.Append(borderBuild);
                rowBuilder.Append(rowBuild);
            }
            
            string borderAppend = borderBuilder.ToString();
            string rowAppend = rowBuilder.ToString();

            Console.WriteLine($"Case #{j+1}:");
            Console.WriteLine(row1AStart + borderAppend);
            Console.WriteLine(row1BStart + rowAppend);
            Console.WriteLine(borderStart + borderAppend);
            for (int r = 1; r < TestCases[j,0]; r++)
            {
                Console.WriteLine(rowStart + rowAppend);
                Console.WriteLine(borderStart + borderAppend);
            }
        }
    }
}