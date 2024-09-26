using static System.Net.Mime.MediaTypeNames;

namespace Izpit_2024_09_26
{
    /// <summary>
    /// NALOGA 2:
    /// 
    /// Večina večjih podjetij ima tudi svoj vozni park, za katerega je treba ustrezno skrbeti. 
    /// Vsako vozilo mora imeti redno servisiranje, registracijo ipd. 
    /// Pripravite razreda Podjetje in Vozilo. 
    /// Vsako podjetje ima seznam vozil, ki predstavljajo vozni park podjetja.
    /// 
    /// Razred Vozilo naj vsebuje: 
    /// - Lastnosti RegistrskaStevilka, Znamka, Letnik, Tip (kombi, avto, kamion) in DatumRegistracije.
    /// - Natanko en konstruktor, ki nastavi lastnost RegistrskaStevilka.
    /// - Metodo ToString, ki izpiše vse lastnosti vozila.                              [5 točk]
    /// 
    /// Razred Podjetje naj vsebuje: 
    /// - Lastnosti Naziv, Naslov, Dejavnost in VozniPark.
    ///   Vse lastnosti naj imajo ustrezen tip.
    /// - En prazen konstruktor.
    /// - Metodo ToString, ki naj izpiše vse podrobnosti o podjetju.
    /// - Metodo, ki vrne skupno število vozil letnika manjšega od danega parametra.
    /// - Metodo, ki vrne vozilo, katero ima najbližji datum registracije.              [15 točk]
    /// 
    /// V metodi ResitevNaloge kreirajte tri instance razreda Vozilo in 
    /// eno instanco razreda Podjetje. 
    /// Nato v ukazno vrstico izpišite podatke o podjetju 
    /// ter katero vozilo iz voznega parka podjetja ima najbližji datum registracije.   [5 točk]
    /// </summary>
    public class Naloga2
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 2
        /// </summary>
        public static void ResitevNaloge()
        {

        }
    }
}