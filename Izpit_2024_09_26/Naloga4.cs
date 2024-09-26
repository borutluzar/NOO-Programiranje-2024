using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Izpit_2024_09_26
{
    /// <summary>
    /// NALOGA 4:
    /// 
    /// V mapi Viri imate pripravljeni dve datoteki s tabelama števil. 
    /// Števila so v posamezni vrstici ločena s tabulatorjem.
    /// 
    /// Pripravite metodo AnalizaZadnjih, ki kot parameter dobi 
    /// pot do datoteke s tabelo števil. 
    /// Prebere naj zadnje število v vsaki vrstici, 
    /// poišče najmanjše med vsemi in ga prišteje prvemu številu vsake vrstice. 
    /// Tako popravljeno tabelo zapišite v novo datoteko, 
    /// katere ime prav tako prejmete kot parameter metode.                         [20 točk]
    /// 
    /// V metodi ResitevNaloge že imate pripravljeni dve spremenljivki 
    /// s potema do datotek s primeroma tabel.
    /// V tej metodi pokličite pripravljeno metodo za obe datoteki. 
    /// Rezultat bosta dve novi datoteki.                                           [5 točke]
    /// </summary>
    public class Naloga4
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 4
        /// </summary>
        public static void ResitevNaloge()
        {
            string filePath1 = "Viri/matrix.txt";
            string filePath2 = "Viri/matrixBig.txt";

        }                
    }
}