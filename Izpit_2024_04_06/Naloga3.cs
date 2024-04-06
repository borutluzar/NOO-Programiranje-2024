using System.Security.Cryptography;
using System.Text;

namespace Izpit_2024_04_06
{
    /// <summary>
    /// NALOGA 3:
    /// Pripravite razrede Kviz, Vprasanje in Odgovor.
    /// 
    /// Razred Odgovor naj vsebuje:
    /// -   Lastnosti Besedilo in Oznaka (oznaka je črka, ki označuje odgovor, 
    ///     ko imamo na vprašanja na voljo nekaj odgovorov).
    /// -   Konstruktor, ki omogoča določitev obeh lastnosti.                   [3 točke]
    /// 
    /// Razred Vprasanje naj vsebuje:
    /// -   Lastnosti Besedilo (tu bo besedilo vprašanja), 
    ///     MozniOdgovori (to bo seznam možnih odgovorov) in SteviloTock.
    /// -   Natanko en konstruktor, ki nastavi vsaj dve lastnosti.                      
    /// -   Povozite metodo ToString, ki izpiše vprašanje skupaj z možnimi odgovori 
    ///     in številom točk za pravilen odgovor.               
    /// -   Napišite objektno metodo PodajVprasanje, ki izpiše vprašanje 
    ///     in od uporabnika pričakuje odgovor - črko oznake odgovora - 
    ///     ter to črko vrne.                                                   [12 točk]
    /// 
    /// Razred Kviz naj vsebuje: 
    /// -   Lastnosti Naziv, Datum, 
    ///     CasResevanja (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!),
    ///     Vprasanja (seznam vprasanj).
    /// -   En konstruktor, ki omogoča določitev natanko ene lastnosti, 
    ///     in en prazen konstruktor, v katerem določimo čas reševanja.
    /// -   Povozite metodo ToString, ki naj izpiše kviz z vsemi vprašanji.     [5 točk]
    /// 
    /// V metodi ResitevNaloge kreirajte instanco razreda Kviz, 
    /// ki naj vsebuje vsaj pet vprašanj, vsako vprašanje pa naj ima 
    /// vsaj dva možna odgovora. 
    /// Za vsa vprašanja na kvizu pokličite metodo PodajVprasanje.              [5 točk]
    /// </summary>
    public class Naloga3
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 3
        /// </summary>
        public static void ResitevNaloge()
        {
            
        }
    }
}