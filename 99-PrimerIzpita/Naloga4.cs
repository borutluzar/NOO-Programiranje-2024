using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpita
{
    /// <summary>
    /// NALOGA 4:
    /// Napišite metodo Metuljcek, ki za dan parameter n 
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
            Metuljcek(9);
        }

        public static void Metuljcek(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("\t\t\t\t");
                for (int j = 0; j < n; j++)
                {
                    string znak = "  ";
                    if (j == 0 || j == n - 1 || i == j || i + j == n - 1)
                    {
                        znak = "* ";
                    }

                    Console.Write(znak);
                }
                Console.WriteLine("");
            }
        }
    }
}