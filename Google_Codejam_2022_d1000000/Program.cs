using System;
using System.Linq;

public class d1000000
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());
        int[] y = new int[T];
        for (int i = 0; i < T; i++)
        {
            int N = int.Parse(Console.ReadLine());
            string strS = Console.ReadLine();
            int[] S = strS.Split(' ').Select(int.Parse).ToArray();
            Array.Sort(S);
            y[i] = 0;
            for (int j = 0; j < S.Length; j++)
            {
                if (y[i] < S[j])
                {
                    y[i]++;
                }
                else if (y[i] == S[j] && S[j] != S[j-1])
                {
                    y[i]++;
                }
            }
        }

        for (int k = 0; k < y.Length; k++)
        {
            Console.WriteLine($"Case #{k+1}: {y[k]}");
        }
    }
}