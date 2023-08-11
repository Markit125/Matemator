using System.Collections;
using UnityEngine;

public class Levels : MonoBehaviour
{
    private int lvl;
    public int[] input;
    public int output;
    private readonly int mx = 2147480000;
    public bool work = false;
    public bool stop = true;
    public bool masready = true;
    public byte count;
    public int[,] a = new int[8, 3];
    public byte[] slots;
    public string[] elementary;
    public string[] easy;
    public string[] medium;
    public string[] hard;
    public string[] impossible;

    private void Awake()
    { //============================================================================================================== 1
        slots = new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 };
        elementary = new string[] { "0", "1", "2", "3", "5", "19", "20" };
        easy = new string[] { "4", "7" };
        medium = new string[] { "6", "8", "9", "10", "11", "12", "14", "21", "22", "23", "25", "26" };
        hard = new string[] { "13", "15", "16", "24" };
        impossible = new string[] { "17", "18" };
        input = new int[] { 0, 0, 0 };
    }
    private void Update()
    {
        if (work && stop)
        {
            lvl = int.Parse(GetComponent<Settings>().CurrentLvl);
            switch (lvl)
            { //============================================================================================================== 2
                case 0: Plus125(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 1: Revolution(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 2: NumLen(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 3: Doubler(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 4: CountTwos(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 5: TwoPower(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 6: DivFour(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 7: MultiPlus(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 8: Fibonacci(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 9: OddPlus(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 10: EnumChange(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 11: SumOdds(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 12: NumDecSum(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 13: Ruletka625(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 14: MultiMinusSum(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 15: TernarySystem(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 16: IsPrime(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 17: CountOfDivs(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 18: FirstWithCountDel(ref input[0], false, ref a, ref count); output = input[0]; break;
                case 19: SumOfNums(ref input, false, ref a, ref count); output = input[0]; break;
                case 20: Bigger(ref input, false, ref a, ref count); output = input[0]; break;
                case 21: MultyMin(ref input, false, ref a, ref count); output = input[0]; break;
                case 22: Evclid(ref input, false, ref a, ref count); output = input[0]; break;
                case 23: NumMultySumOfNum(ref input, false, ref a, ref count); output = input[0]; break;
                case 24: DifferOfSquare(ref input, false, ref a, ref count); output = input[0]; break;
                case 25: Logarifm(ref input, false, ref a, ref count); output = input[0]; break;
                case 26: BoundsSum(ref input, false, ref a, ref count); output = input[0]; break;
                case 27: BackSum(ref input, false, ref a, ref count); output = input[0]; break;
                //case : (ref input, false, ref a, ref count); output = input[0]; break;
                default: break;
            } //==============================================================================================================
            stop = false;
        }
        else if(work) work = false;

        if (GetComponent<Settings>().test && !masready && GetComponent<Settings>().CurrentLvl != "")
        {
            count = 0;
            lvl = int.Parse(GetComponent<Settings>().CurrentLvl);
            switch (lvl)
            { //============================================================================================================== 3
                case 0: Plus125(ref input[0], true, ref a, ref count); break;
                case 1: Revolution(ref input[0], true, ref a, ref count); break;
                case 2: NumLen(ref input[0], true, ref a, ref count); break;
                case 3: Doubler(ref input[0], true, ref a, ref count); break;
                case 4: CountTwos(ref input[0], true, ref a, ref count); break;
                case 5: TwoPower(ref input[0], true, ref a, ref count); break;
                case 6: DivFour(ref input[0], true, ref a, ref count); break;
                case 7: MultiPlus(ref input[0], true, ref a, ref count); break;
                case 8: Fibonacci(ref input[0], true, ref a, ref count); break;
                case 9: OddPlus(ref input[0], true, ref a, ref count); break;
                case 10: EnumChange(ref input[0], true, ref a, ref count); break;
                case 11: SumOdds(ref input[0], true, ref a, ref count); break;
                case 12: NumDecSum(ref input[0], true, ref a, ref count); break;
                case 13: Ruletka625(ref input[0], true, ref a, ref count); break;
                case 14: MultiMinusSum(ref input[0], true, ref a, ref count); break;
                case 15: TernarySystem(ref input[0], true, ref a, ref count); break;
                case 16: IsPrime(ref input[0], true, ref a, ref count); break;
                case 17: CountOfDivs(ref input[0], true, ref a, ref count); break;
                case 18: FirstWithCountDel(ref input[0], true, ref a, ref count); break;
                case 19: SumOfNums(ref input, true, ref a, ref count); break;
                case 20: Bigger(ref input, true, ref a, ref count); break;
                case 21: MultyMin(ref input, true, ref a, ref count); break;
                case 22: Evclid(ref input, true, ref a, ref count); break;
                case 23: NumMultySumOfNum(ref input, true, ref a, ref count); break;
                case 24: DifferOfSquare(ref input, true, ref a, ref count); break;
                case 25: Logarifm(ref input, true, ref a, ref count); break; 
                case 26: BoundsSum(ref input, true, ref a, ref count); break;
                case 27: BackSum(ref input, true, ref a, ref count); break;
                //case : (ref input, true, ref a, ref count); break;
                default: break;
            } //==============================================================================================================
            masready = true;
        }
        if(!GetComponent<Settings>().test && a[0, 0] != -32768)
        {
            a[0, 0] = -32768;
            for (byte i = 0; i < 8; i++)
                for (byte j = 0; j < 3; j++)
                    if (j > 0) a[i, j] = -32768;
                    else a[i, j] = 0;
        }
    }
    /*
    private void Name(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-1000, 1000);
        }
        else
        {
            x = 
        }
    }
    */ //==============================================================================================================

    private void Evclid(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 4;
            a[0, 0] = Random.Range(2, 100);
            a[0, 1] = Random.Range(2, 100);
            a[1, 0] = Random.Range(20, 100);
            a[1, 1] = Random.Range(1, 100);
            a[2, 0] = Random.Range(10, 400);
            a[2, 1] = Random.Range(10, 400);
            a[2, 0] = Random.Range(10, 400);
            a[2, 1] = Random.Range(10, 400);
        }
        else
        {
            if (x[0] > 0 && x[1] > 0)
            {
                int q = x[0];
                int b = x[1];
                while (q != b)
                {
                    if (q > b)
                    {
                        q -= b;
                    }
                    else
                    {
                        b -= q;
                    }
                }
                x[0] = q;
            }
            else 
            {
                x[0] = -1;
            }
        }
    }

    private void BackSum(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            a[0, 0] = Random.Range(0, 10);
            a[0, 1] = Random.Range(0, 10);
            a[1, 0] = Random.Range(0, 10);
            a[1, 1] = Random.Range(0, 100);
            a[2, 0] = Random.Range(10, 100);
            a[2, 1] = Random.Range(100, 1000);
        }
        else
        {
            if (x[0] > 0 && x[1] > 0)
            {
                int q = 1, w = 0, e = x[0];
                while (e > 0)
                {
                    e /= 10;
                    q *= 10;
                }
                q /= 10;
                while (x[0] > 0)
                {
                    w += (x[0] % 10) * q;
                    q /= 10;
                    x[0] /= 10;
                }
                e = x[1];
                q = 1;
                while (e > 0)
                {
                    e /= 10;
                    q *= 10;
                }
                q /= 10;
                while (x[1] > 0)
                {
                    w += (x[1] % 10) * q;
                    q /= 10;
                    x[1] /= 10;
                }
                x[0] = w;
            }
            else
            {
                x[0] = -1;
            }
        }
    }

    private void BoundsSum(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            a[0, 0] = Random.Range(0, 10);
            a[0, 1] = Random.Range(0, 10);
            a[1, 0] = Random.Range(0, 1000);
            a[1, 1] = Random.Range(0, 10);
            a[2, 0] = Random.Range(0, 10000);
            a[2, 1] = Random.Range(0, 10000);
        }
        else
        {
            if (x[0] >= 0 && x[1] >= 0)
            {
                int q = x[0] % 10 + x[1] % 10, e = 0;
                while (x[0] > 0)
                {
                    e = x[0] % 10;
                    x[0] /= 10;
                }
                q += e;
                while (x[1] > 0)
                {
                    e = x[1] % 10;
                    x[1] /= 10;
                }
                q += e;
                x[0] = q;
            }
            else x[0] = -1;
        }
    }

    private void NumMultySumOfNum(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 4;
            a[0, 0] = Random.Range(1, 11);
            a[0, 1] = Random.Range(-100, 100);
            a[1, 0] = Random.Range(1, 11);
            a[1, 1] = Random.Range(-10000, 10000);
            a[2, 0] = Random.Range(-11, -1);
            a[2, 1] = Random.Range(-10000, 10000);
            a[3, 0] = Random.Range(-11, 11);
            a[3, 1] = Random.Range(-10000, -100);
        }
        else
        {
            int q = 0, last = 0;
            bool b = false;
            if (x[1] < 0)
            {
                x[1] = Mathf.Abs(x[1]);
                b = true;
            }
            while (x[1] > 0)
            {
                last = x[1] % 10;
                q += last;
                x[1] /= 10;
            }
            if (b) q -= last * 2;
            x[0] *= q;
        }
    }

    private void DifferOfSquare(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++)
            {
                a[i, 0] = Random.Range(-100, 100);
                a[i, 1] = a[i, 0] + Random.Range(-10, 10);
            }
        }
        else x[0] = (x[0] + x[1]) * (x[0] - x[1]);
    }

    private void MultyMin(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++)
            {
                a[i, 0] = Random.Range(-10, 50);
                a[i, 1] = Random.Range(-10, 10);
            }
        }
        else x[0] = int.Parse((x[0] * x[1]).ToString() + (x[0] > x[1] ? x[1] : x[0]).ToString());
    }

    private void Logarifm(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++)
            {
                a[i, 0] = Random.Range(1, 5000);
                a[i, 1] = Random.Range(2, 10);
            }
        }
        else
        {
            if (x[0] > 0 || x[1] > 0)
            {
                if (x[0] < x[1]) x[0] = 0;
                else x[0] = Mathf.RoundToInt(Mathf.Log(x[0], x[1]));
            }
            else x[0] = -1;
        }
    }

    private void Bigger(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++)
            {
                a[i, 0] = Random.Range(-1000, 100000);
                a[i, 1] = Random.Range(-1000, 100000);
            }
        }
        else x[0] = x[0] > x[1] ? 0 : 1;
    }

    private void SumOfNums(ref int[] x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++)
                for (byte j = 0; j < 2; j++)
                    a[i, j] = Random.Range(-100, 100);
        }
        else x[0] += x[1];
    }

    private void TernarySystem(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-243, 243);
        }
        else
        {
            if (x != 0)
            {
                string st = "";
                int q, w, e;
                if (x < 0)
                {
                    x = -x;
                    st += "-";
                }
                q = 1;
                w = 0;
                while (q <= x)
                {
                    q *= 3;
                    w++;
                }
                q /= 3;
                while (x > 0)
                {
                    e = 0;
                    while (x >= q)
                    {
                        x -= q;
                        e++;
                    }
                    st += e.ToString();
                    q /= 3;
                    w--;
                }
                for (int i = 0; i < w; i++) st += '0';
                x = int.Parse(st);
            }
            else x = 0;

        }
    }

    private void IsPrime(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        int q;
        if (tst)
        {
            int r;
            count = 4;
            a[0, 0] = Random.Range(0, 100);
            a[1, 0] = Random.Range(0, 100);
            a[2, 0] = primes[Random.Range(0, 24)];
            a[3, 0] = primes[Random.Range(0, 24)];
            for(byte i = 0; i < 5; i++)
            {
                r = Random.Range(0, 3);
                q = a[r, 0];
                a[r, 0] = a[r + 1, 0];
                a[r + 1, 0] = q;
            }
        }
        else
        {
            if (x <= 100 && x > 0)
            {
                q = x;
                x = 0;
                for (byte i = 0; i < 25; i++)
                    if (primes[i] == q)
                    {
                        x = 1;
                        break;
                    }
            }
            else if (x > 100)
            {
                q = x;
                x = 1;
                for (int i = 2; i < Mathf.Ceil(Mathf.Sqrt(x)) + 1; i++)
                    if (q % i == 0)
                    {
                        x = 0;
                        break;
                    }
            }
            else x = -1;
        }
    }

    private void NumDecSum(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(0, 1000);
        }
        else
        {
            if (x >= 0) x += x / 10;
            else x = -1;
        }
    }

    private void SumOdds(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-10000, 10000);
        }
        else
        {
            string st, st1;
            int q, w;
            if (x < 0) x = -x;
            q = 0;
            st = x.ToString();
            for(int i = 0; i < st.Length; i++)
            {
                st1 = "";
                st1 += st[i];
                w = int.Parse(st1);
                if (w % 2 == 1) q += w;
            }
            x = q;
        }
    }

    private void MultiMinusSum(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-100, 200);
        }
        else
        {
            int q, w;
            if (x < 0) x = -x;
            q = 1;
            w = 0;
            string st, st1;
            st = x.ToString();
            for (int i = 0; i < st.Length; i++)
            {
                st1 = "";
                st1 += st[i];
                q *= int.Parse(st1);
                w += int.Parse(st1);
            }
            x = q - w;
        }
    }

    private void NumLen(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 4;
            a[0, 0] = Random.Range(-10000000, 100000000);
            a[1, 0] = Random.Range(-100000, 0);
            a[2, 0] = Random.Range(-1000, 10000);
            a[3, 0] = Random.Range(0, 10000);

        }
        else x = x.ToString().Length;
    }

    private void EnumChange(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-10, 10000);
        }
        else
        {
            if (x > 0)
            {
                string st, st1, st2;
                int q;
                st = x.ToString();
                st1 = "";
                x = 0;
                for (int i = x; i < st.Length; i++)
                {
                    st2 = "";
                    st2 += st[i];
                    q = int.Parse(st2);
                    if (q % 2 == 0) st1 += (q / 2).ToString();
                    else st1 += (q * 2).ToString();
                }
                if (st1.Length > 9) x = mx;
                else x = int.Parse(st1);
            }
            else x = -1;
        }
    }

    private void Fibonacci(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 4;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(1, 12);
        }
        else
        {
            if (x > 0 && x <= 44) x = fib[x - 1];
            else if (x > fib.Length) x = mx;
            else x = -1;
        }
    }

    private void Ruletka625(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 4;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-100000000, 100000000);
        }
        else x = Random.Range(0, 2);
    }

    private void OddPlus(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 4;
            a[0, 0] = Random.Range(-100, 0) / 2;
            a[1, 0] = Random.Range(-100, 0) / 2 + 1;
            a[2, 0] = Random.Range(0, 100) / 2;
            a[3, 0] = Random.Range(0, 100) / 2 + 1;
            for (byte i = 3; i >= 1; i--)
            {
                int k, q;
                k = a[i, 0];
                q = Random.Range(0, 4);
                a[i, 0] = a[q, 0];
                a[q, 0] = k;
            }
        }
        else
        {
            if (x > 0 && x < mx / 3)
            {
                if (x % 2 == 0)  x *= 3;
                else x = x * 2 + 1;
            }
            else if (x > mx / 3) x = mx;
            else
            {
                if (x % 2 == 0) x /= 2;
                else x = (x - 1) / 2;
            }
        }
    }

    private void TwoPower(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 5;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(0, 14);
        }
        else
        {
            if (x >= 0 && x < 24)
            {
                int k;
                k = x;
                x = 1;
                for (int i = 0; i < k; i++) x *= 2;
            }
            else if (x < 0) x = 0;
            else x = mx;
        }
    }

    private void CountTwos(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 5;
            a[Random.Range(0, 5), 0] = int.Parse(Random.Range(1, 100).ToString() + "2" + Random.Range(1, 1000).ToString());
            while(true)
            {
                int p;
                p = Random.Range(0, 5);
                if (a[p, 0] == 0 || a[p, 0] == -32768)
                {
                    a[p, 0] = int.Parse(Random.Range(1, 9).ToString() + Random.Range(1, 3) * '2');
                    break;
                }
            }
            for (byte i = 0; i < count; i++)
            {
                if(a[i, 0] == 0 || a[i, 0] == -32768) a[i, 0] = Random.Range(222, 100000);
            }
        }
        else
        {
            int q;
            string st;
            q = 0;
            st = x.ToString();
            for (int i = 0; i < st.Length; i++)
                if (st[i] == '2') q++;
            x = q;
        }
    }

    private void FirstWithCountDel(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(1, 16);
        }
        else
        {
            if (x > 0 && x < 80)
            {
                if (x > 15 && x % 2 == 1)  x = 2147480000;
                else
                {
                    int q, w;
                    q = 0;
                    w = 1;
                    while (q != x)
                    {
                        q = 1;
                        for (int i = 1; i < w / 2 + 1; i++)
                            if (w % i == 0) q++;
                        w++;
                    }
                    x = w - 1;
                }
            }
            else  x = -1;
        }
    }

    private void CountOfDivs(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 4;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(0, 120);
        }
        else
        {
            if (x > 0)
            {
                int q;
                q = 1;
                for (int i = 1; i < x / 2 + 1; i++)
                    if (x % i == 0) q++;
                x = q;
            }
            else x = -1;
        }
    }

    private void MultiPlus(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-25, 25);
        }
        else
        {
            if (x > mx / 3) x = mx;
            else if (x < -mx / 3) x = -mx;
            else x = x * 3 + 2;
        }
    }

    private void DivFour(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(0, 60);
        }
        else x = x / 4;
    }

    private void Revolution(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if(tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-100000, 100000);
        }
        else x = -x;
    }

    private void Plus125(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-1000, 1000);
        }
        else
        {
            if(x > mx) x = mx;
            else if(x < -mx) x = -mx;
            else x = x + 125;
        }
    }

    private void Doubler(ref int x, bool tst, ref int[,] a, ref byte count)
    {
        if (tst)
        {
            count = 3;
            for (byte i = 0; i < count; i++) a[i, 0] = Random.Range(-1000, 1000);
        }
        else
        {
            if (x > mx / 2) x = mx;
            else if (x < -mx / 2) x = -mx;
            else x *= 2;
        }
    }

    private readonly int[] fib = new int[44] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733 };
    private readonly int[] primes = new int[25] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
}
