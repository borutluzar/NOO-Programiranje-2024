using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;

namespace Izpit_2025_03_22
{
    /// <summary>
    /// NALOGA 2:
    /// 
    /// Pripravljamo aplikacijo za samodejno generiranje izpitov. 
    /// Zanjo bomo pripravili dva razreda: razred Naloga, ki bo predstavljal izpitno nalogo, 
    /// in razred Izpit, ki bo predstavljal izpit iz programiranja. 
    /// 
    /// Razred Naloga naj vsebuje: 
    /// - Lastnosti Besedilo, MozneTocke, DosezeneTocke, Avtor in Tezavnost.
    /// - Natanko en konstruktor, ki nastavi lastnost Sestavljalec.
    /// - Funkcijo, ki vrne odstotek doseženih točk.
    /// - Metodo ToString, ki izpiše vse lastnosti naloge.                              [10 točk]
    /// 
    /// Razred Izpit naj vsebuje: 
    /// - Lastnosti Predmet, DatumPisanja, Naloge in CasPisanja.
    /// - Konstruktor, ki kot parameter dobi datum pisanja.
    /// - Funkcijo ToString, ki naj izpiše vse podrobnosti izpita.
    /// - Funkcijo, ki izračuna skupno število doseženih točk na izpitu.                [10 točk]
    /// 
    /// V funkciji ResitevNaloge kreirajte tri instance razreda Naloga 
    /// in eno instanco razreda Izpit ter naloge dodajte k nalogam izpita. 
    /// Vsem instancam za vse lastnosti določite neke vrednosti. 
    /// Nato v ukazno vrstico izpišite število doseženih točk na izpitu.                [5 točk]
    /// </summary>
    public class Naloga2
    {
        /// <summary>
        /// V tej funkciji se začne izvajati program za reševanje Naloge 2
        /// </summary>
        public static void ResitevNaloge()
        {

        }
    }
}