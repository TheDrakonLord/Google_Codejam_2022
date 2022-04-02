using System;
using System.Collections;

public class ChainReactions
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++)
        {
            int N = int.Parse(Console.ReadLine());

            string strF = Console.ReadLine();
            int[] F = strF.Split(' ').Select(int.Parse).ToArray();

            string strP = Console.ReadLine();
            int[] P = strP.Split(' ').Select(int.Parse).ToArray();

            node[] inputs = new node[N];

            for (int j = 0; j < N; j++)
            {
                inputs[j] = new node(F[j], P[j], j + 1);
            }
            for (int o = 0; o < N; o++)
            {
                inputs[inputs[j].Point].pointedTo = true;
            }

            node[] sorted = inputs;

            Array.Sort(sorted, new NodeComparer());
            int max = 0;
            bool flag = false;
            for (int l = N; l >= 0; l--)
            {

                if (!sorted[l].pointedTo)
                {
                    for (int m = N; m >= 0; m++)
                    {
                        if (!sorted[l].pointedTo)
                        {
                            int current = DepthCheck(sorted[l], inputs, flag);
                            if (current > max)
                            {
                                max = current;
                            }
                        }
                    }

                }
                flag = !flag;

            }

        }
    }

    private static int DepthCheck(node n, node[] a, bool flag)
    {
        n.visited = !n.visited;
        if (n.Point == 0)
        {
            return n.F;
        }
        else if (a[n.Point].visited == flag)
        {
            return n.F;
        }
        else
        {
            return DepthCheck(a[n.Point], a, flag) + n.F;
        }
    }

}


class NodeComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return (new CaseInsensitiveComparer()).Compare(((node)x).P, ((node)y).P);
    }

}

class node
{
    public int Point { get; set; }
    public int F { get; set; }
    public int i { get; set; }
    public bool visited { get; set; }
    public bool pointedTo { get; set; }

    public node(int f)
    {
        F = f;
    }
    public node(int f, node p)
    {
        P = p;
        F = f;
    }
    public node(int fun, int point, int index)
    {
        F = fun;
        Point = point;
        i = index;
    }

}
