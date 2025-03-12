using System.Security.Cryptography;
using System.Text;

namespace Izpit_2024_04_06
{
    /// <summary>
    /// NALOGA 1:
    /// 
    /// Napišite metodo Frekvenca, ki kot parameter prejme seznam besed in znak. 
    /// Naloga metode je prešteti število besed na seznamu, 
    /// ki vsebujejo vsaj eno črko enako danemu znaku 
    /// (med velikimi in malimi črkami ne razlikujemo). 
    /// Število takih besed naj metoda vrne.                                [12 točk]
    /// 
    /// Dodatno naj ob pregledu besed iz seznama metoda v ukazno vrstico izpiše 
    /// vsako besedo, ki dani znak vsebuje vsaj dvakrat.                    [8 točk]
    /// 
    /// V metodi ResitevNaloge pripravite seznam z vsaj petimi besedami,
    /// pokličite metodo Frekvenca in izpišite število besed s seznama, 
    /// ki vsebujejo znak 'a'.                                              [5 točk]
    /// </summary>
    public class Naloga1
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 1
        /// </summary>
        public static void ResitevNaloge()
        {
            List<string> lstBesede = new List<string>() { "Danes", "je", "super", "dan", "in ", "pikado", "rabarbara", "ananas" };
            char znak = 'a';

            int stBesed = Frekvenca(lstBesede, znak);

            Console.WriteLine($"Besed, ki vsebujejo znak {znak} je {stBesed}");
        }

        /// Napišite metodo Frekvenca, ki kot parameter prejme seznam besed in znak. 
        /// Naloga metode je prešteti število besed na seznamu, 
        /// ki vsebujejo vsaj eno črko enako danemu znaku 
        /// (med velikimi in malimi črkami ne razlikujemo). 
        /// Število takih besed naj metoda vrne.  
        /// 
        /// Dodatno naj ob pregledu besed iz seznama metoda v ukazno vrstico izpiše 
        /// vsako besedo, ki dani znak vsebuje vsaj dvakrat. 
        private static int Frekvenca(List<string> seznam, char znak)
        {
            int stBesed = 0;
            foreach(string beseda in seznam)
            {
                if(beseda.ToLower().Contains(Char.ToLower(znak)))
                {
                    stBesed++;

                    int stZnakov = 0;
                    foreach(char z in beseda.ToLower())
                    {
                        if(z == Char.ToLower(znak))
                        {
                            stZnakov++;
                        }
                    }
                    if(stZnakov >= 2)
                    {
                        Console.WriteLine($"Beseda, ki ima {znak} vsaj dvakrat: {beseda}");
                    }
                }
            }
            return stBesed;
        }
    }        
}