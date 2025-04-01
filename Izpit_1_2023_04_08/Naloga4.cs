using System.Security.Cryptography;
using System.Text;

namespace Izpit_2023_04_08
{
    /// <summary>
    /// NALOGA 4:
    /// Napišite metodo Poštevanka, ki za dan parameter n 
    /// izpiše poštevanko od 1 do števila n tako,
    /// da so v vsaki vrstici izpisani večkratniki enega števila.
    /// Pri tem števila, ki so na pozicijah, 
    /// katerih vsota stolpca in vrstice je liha (če jih štejemo od 0 dalje), 
    /// nadomestimo z zvezdicami (razen v primeru začetnih in končnih stolpcev in vrstic!).
    /// 
    /// Za vrednost n=5 bi bil izris kot na spodnjem primeru:                   [20 točk]
    /// 
    /// 1   2   3   4   5
    /// 2   *   6   *  10
    /// 3   6   *  12  15
    /// 4   *  12   *  20
    /// 5  10  15  20  25
    /// 
    /// V metodi ResitevNaloge pripravite klic metode, ki za parameter
    /// dobi število n, ki naj ga poda uporabnik.                               [5 točk]
    /// </summary>
    public class Naloga4
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 4
        /// </summary>
        public static void ResitevNaloge()
        {
            Console.Write("Vpišite parameter n: ");
            int n = int.Parse(Console.ReadLine());

            // Pokličemo funkcijo za izpis
            Postevanka(n);
        }

        /// Napišite metodo Poštevanka, ki za dan parameter n 
        /// izpiše poštevanko od 1 do števila n tako,
        /// da so v vsaki vrstici izpisani večkratniki enega števila.
        /// Pri tem števila, ki so na pozicijah, 
        /// katerih vsota stolpca in vrstice je liha (če jih štejemo od 0 dalje), 
        /// nadomestimo z zvezdicami (razen v primeru začetnih in končnih stolpcev in vrstic!).
        public static void Postevanka(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0 || i == 0 || j == 0 || i == n - 1 || j == n - 1)
                    {
                        int zmnozek = (i + 1) * (j + 1);
                        Console.Write(zmnozek + "\t");
                    }
                    else
                    {
                        Console.Write("*\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}