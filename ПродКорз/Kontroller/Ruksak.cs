using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПродКорз.Kontroller
{
    class Ruksak
    {
        public static List<int> rukzakproblem(int[] price, int[] polza, int summ)
        {
            List<int> rukzak = new List<int>();
            int n = price.Length;
            int[,] F = new int[summ + 1, n + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int p = 1; p <= summ; p++)
                {
                    if (price[i - 1] <= p)
                    {
                        F[p, i] = Math.Max(F[p, i - 1], F[p - price[i - 1], i - 1] + polza[i - 1]);
                    }
                    else
                    {
                        F[p, i] = F[p, i - 1];
                    }
                }
            }
            int res = F[summ, n], a = summ;
            for (int k = n; k >= 0; k--)
            {
                if (res <= 0) 
                    break;
                if (res == F[a, k - 1])
                    continue;
                else
                {
                    rukzak.Add(k - 1);
                    res -= polza[k - 1];
                    a -= price[k - 1];
                }
            }
            rukzak.Add(F[summ, n]);
            return rukzak;
        }
    }
}
