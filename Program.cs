using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201015
{
    class Program
    {
        static int[] tomb = new int[200]; //megoszott tömb a 4-es feladathoz
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //#1: készítsünk olyan függvényt, amely kap paraméterként két számot, és visszaadja a két szám közül a nagyobbik értékét! Amennyiben a két szám egyenlő, úgy az első szám értékét kell visszaadni!

            Console.WriteLine("Adjon meg két számot:");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"A(z) {a} és a(z) {b} közül a(z) {NagyobbSzam(a, b)} a nagyobb.");
            Console.ReadKey();
            Console.Clear();

            //#2: készítsünk olyan függvényt, amely kap két int tömböt paraméterként, mindkét tömbben 3-3 szám van! A tömbök egy-egy háromszög oldalainak hosszát írják le! Adjuk vissza a nagyobb kerületű háromszög kerületének értékét!

            int[] c = { 2, 4, 6 };
            int[] d = { 3, 5, 7 };
            Console.WriteLine($"A(z) {{{c[0]},{c[1]},{c[2]}}} és a(z) {{{d[0]},{d[1]},{d[2]}}} háromszögek közül a(z) nagyobbiknak {NagyobbHaromszog(c, d)} egység a kerülete.");
            Console.ReadKey();
            Console.Clear();

            //#3: készítsünk olyan függvényt, amely meghatározza egy paraméterben megadott, int típusú tömbben a leghosszabb egyenlő elemekből álló szakasz hosszát!

            int[] e = { 0, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 6, 7, 7, 8, 9, 10, 10, 10 };
            Console.WriteLine($"A leghosszabb elemekből álló szakasz hossza {SzakaszHossz(e)}.");
            Console.ReadKey();
            Console.Clear();

            //#4: készítsünk olyan eljárást, amely egy megosztott tömböt feltölt véletlen elemekkel egy megadott intervallum elemei közül úgy, hogy két egyenlő érték ne forduljon elő a tömbben! Az intervallum kezdő és végértékeit paraméterként adjuk át!

            TombFeltolt(1000, 1501);
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.Write($"{tomb[i]} ");
            }
            Console.ReadKey();
        }

        static int NagyobbSzam(int a = 0, int b = 0)
        {
            if (a == b || a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static int NagyobbHaromszog(int[] a, int[] b)
        {
            int aKer = a.Sum();
            int bKer = b.Sum();
            return NagyobbSzam(aKer, bKer);
        }

        static int SzakaszHossz(int[] a)
        {
            int maxl = 1;
            int l = 1;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] == a[i]) l++;
                else l = 1;
                if (l > maxl) maxl = l;
            }
            return maxl;
        }

        static void TombFeltolt(int minInterval, int maxInterval)
        {
            List<int> volt = new List<int>();
            for (int i = 0; i < tomb.Length; i++)
            {
                int elem;
                do
                {
                    elem = rnd.Next(minInterval, maxInterval);
                } while (volt.Contains(elem));
                tomb[i] = elem;
                volt.Add(elem);
            }
        }
    }
}
