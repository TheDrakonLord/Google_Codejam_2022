using System;

public class ThreeDPrinting
{
    public static void Main(string[] args)
    {
        const int target = 1000000;
        int T = int.Parse(Console.ReadLine());
        string[] output = new string[T];
        for (int i = 0; i < T; i++)
        {
            int C1, C2, C3, M1, M2, M3, Y1, Y2, Y3, K1, K2, K3;
            string printer1 = Console.ReadLine();
            string[] printer1s = printer1.Split(" ");
            string printer2 = Console.ReadLine();
            string[] printer2s = printer2.Split(" ");
            string printer3 = Console.ReadLine();
            string[] printer3s = printer3.Split(" ");

            C1 = int.Parse(printer1s[0]);
            C2 = int.Parse(printer2s[0]);
            C3 = int.Parse(printer3s[0]);

            M1 = int.Parse(printer1s[1]);
            M2 = int.Parse(printer2s[1]);
            M3 = int.Parse(printer3s[1]);

            Y1 = int.Parse(printer1s[2]);
            Y2 = int.Parse(printer2s[2]);
            Y3 = int.Parse(printer3s[2]);

            K1 = int.Parse(printer1s[3]);
            K2 = int.Parse(printer2s[3]);
            K3 = int.Parse(printer3s[3]);

            int Cmin = Math.Min(Math.Min(C1, C2), C3);
            int Mmin = Math.Min(Math.Min(M1, M2), M3);
            int Ymin = Math.Min(Math.Min(Y1, Y2), Y3);
            int Kmin = Math.Min(Math.Min(K1, K2), K3);

            if (Cmin + Mmin + Ymin + Kmin == target)
            {
                output[i] = $"{Cmin} {Mmin} {Ymin} {Kmin}";
            }
            else if (Cmin + Mmin + Ymin + Kmin > target)
            {
                int overage = (Cmin + Mmin + Ymin + Kmin) - target;

                while (overage > 0)
                {
                    int overageEvener = overage % 4;
                    overage = overage - overageEvener;
                    int division = overage / 4;

                    if (Cmin >= Mmin && Cmin >= Ymin && Cmin >= Kmin)
                    {
                        Cmin = Cmin - overageEvener;
                    }
                    else if (Mmin >= Cmin && Mmin >= Ymin && Mmin >= Kmin)
                    {
                        Mmin = Mmin - overageEvener;
                    }
                    else if (Ymin >= Cmin && Ymin >= Mmin && Ymin >= Kmin)
                    {
                        Ymin = Ymin - overageEvener;
                    }
                    else
                    {
                        Kmin = Kmin - overageEvener;
                    }

                    if (Cmin >= division)
                    {
                        Cmin = Cmin - division;
                        overage -= division;
                    }

                    if (Mmin >= division)
                    {
                        Mmin = Mmin - division;
                        overage -= division;
                    }

                    if (Ymin >= division)
                    {
                        Ymin = Ymin - division;
                        overage -= division;
                    }

                    if (Kmin >= division)
                    {
                        Kmin = Kmin - division;
                        overage -= division;
                    }
                }
                output[i] = $"{Cmin} {Mmin} {Ymin} {Kmin}";
            }
            else
            {
                output[i] = "IMPOSSIBLE";
            }
        }

        for (int j = 0; j < T; j++)
        {
            Console.WriteLine($"Case #{j + 1}: {output[j]}");
        }
    }
}