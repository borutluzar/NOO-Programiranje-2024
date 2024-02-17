using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpitaResitev
{
    /// <summary>
    /// NALOGA 4:
    /// Napišite metodo Metuljcek, ki za dan lih parameter n 
    /// izrise metuljčka. Za vrednost n=5 bi bil izris kot
    /// na spodnjem primeru:                        [20 točk]
    /// 
    /// *       *
    /// * *   * *
    /// *   *   *
    /// * *   * *
    /// *       *
    /// 
    /// V metodi ResitevNaloge pripravite klic metode, ki za parameter
    /// dobi število n, ki naj ga poda uporabnik.   [5 točk]
    /// </summary>
    public class Naloga4
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 4
        /// </summary>
        public static void ResitevNaloge()
        {
            Console.Write("Vpišite (liho) dimenzijo metuljčka: ");
            int n = int.Parse(Console.ReadLine());

            /*
                int.TryParse(Console.ReadLine(), out int test);
            */
            // Pokličemo metodo za izris
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Metuljcek(n);
            Console.ForegroundColor = ConsoleColor.White;
            // Imamo zadnjih 5 točk!
        }

        private static void Metuljcek(int n)
        {
            // Sprehod po vrsticah (n vrstic)
            for (int i = 0; i < n; i++)
            {
                Console.Write("\t");
                // Sprehod po stolpcih (2*n stolpcev)
                for (int j = 0; j < n; j++)
                {
                    if (j == 0 || j == n - 1 || i == j || i == (n - 1) - j)
                    {
                        // Izpis zvezdic
                        Console.Write("* ");
                    }
                    else
                    {
                        // Izpis presledka
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        // Imamo 20 točk
    }
}