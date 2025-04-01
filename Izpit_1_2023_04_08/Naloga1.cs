using System.Security.Cryptography;
using System.Text;

namespace Izpit_2023_04_08
{
    /// <summary>
    /// NALOGA 1:
    /// Napišite metodo za igro ugibanja besed.
    /// Metoda naj od prvega uporabnika (skrbnika) zahteva vnos neke besede s petimi črkami.
    /// Če je vnešena beseda z drugim številom črk, metoda zahteva ponoven vnos,
    /// dokler ni vnešena beseda s petimi črkami.                       [5 točk]
    /// 
    /// Igro nato nadaljuje drug uporabnik (igralec).
    /// Igralcu se izpiše prva črka izbrane besede, 
    /// igralec pa poskuša uganiti besedo.
    /// Za vsako vnešeno besedo mu metoda izpiše, 
    /// katere črke so v izbrani besedi in katere so na pravih mestih.  [15 točk]
    /// 
    /// Ko igralec ugane besedo, se mu izpiše čestitka in število
    /// poskusov, ki jih je porabil.                                    [5 točk]
    /// </summary>
    public class Naloga1
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 1
        /// </summary>
        public static void ResitevNaloge()
        {
            /// Napišite metodo za igro ugibanja besed.
            /// Metoda naj od prvega uporabnika (skrbnika) zahteva vnos neke besede s petimi črkami.
            /// Če je vnešena beseda z drugim številom črk, metoda zahteva ponoven vnos,
            /// dokler ni vnešena beseda s petimi črkami.                       [5 točk]

            string skrivnaBeseda = "";
            while (skrivnaBeseda.Length != 5)
            {
                Console.Write("Vnesi besedo s petimi črkami: ");
                skrivnaBeseda = Console.ReadLine().ToUpper();
            }

            /// Igro nato nadaljuje drug uporabnik (igralec).
            /// Igralcu se izpiše prva črka izbrane besede, 
            /// igralec pa poskuša uganiti besedo.
            /// Za vsako vnešeno besedo mu metoda izpiše, 
            /// katere črke so v izbrani besedi in katere so na pravih mestih.  [15 točk]

            Console.WriteLine("Začenjamo z ugibanjem:\n");
            Console.WriteLine(skrivnaBeseda[0] + " _ _ _ _");

            int stevecPoskusov = 0;
            while (true) // Zanka, ki se izvede ob vsakem poskusu/vnosu uporabnika
            {
                Console.Write("Vnesite svoj poskus: ");
                string poskus = Console.ReadLine().ToUpper();
                stevecPoskusov++;

                if (poskus == skrivnaBeseda)
                {
                    Console.WriteLine($"Čestitamo! Uganili ste v {stevecPoskusov} poskusih, vi ste najboljši!");
                    break;
                }
                else
                {
                    string prikaz = "";
                    for (int i = 0; i < poskus.Length; i++) 
                    {
                        if (poskus[i] == skrivnaBeseda[i])
                        {
                            //Console.BackgroundColor = ConsoleColor.Green;
                            prikaz += poskus[i] + " ";
                            //Console.Write(poskus[i] + " ");
                            //Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (skrivnaBeseda.Contains(poskus[i]))
                        {
                            //Console.BackgroundColor = ConsoleColor.Red;
                            prikaz += poskus[i].ToString().ToLower() + " ";
                            //Console.Write(poskus[i].ToString().ToLower() + " ");
                            //Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            prikaz += "_ ";
                            //Console.Write("_ ");
                        }
                    }
                    Console.WriteLine(prikaz);
                }
            }
        }
    }
}