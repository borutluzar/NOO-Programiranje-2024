using System.Security.Cryptography;
using System.Text;

namespace Izpit_2024_03_23
{
    /// <summary>
    /// NALOGA 4:
    /// 
    /// Med viri imate datoteko words_alpha.txt s seznamom angleških besed
    /// (ena beseda v vsaki vrstici). 
    /// V metodi imate že pripravljeno instanco razreda StreamReader,
    /// ki odpre omenjeno datoteko.
    /// 
    /// Poiščite vse besede v datoteki, ki vsebujejo črko 'x' 
    /// (veliko ali malo) in jih dodajte v seznam.                              [5 točk]
    /// 
    /// Med najdenimi besedami poiščite vse palindrome 
    /// (to so besede, ki se berejo enako naprej in nazaj, npr. kisik)
    /// in jih izpišite.                                                        [12 točk]
    /// 
    /// Na koncu izpišite število vseh besed, ki vsebujejo 'x' in 
    /// ne vsebujejo 'i' ali 'a'.                                               [8 točk]
    /// </summary>
    public class Naloga4
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 4
        /// </summary>
        public static void ResitevNaloge()
        {
            StreamReader srWords = new StreamReader("Viri/words_alpha.txt");

        }
    }
}