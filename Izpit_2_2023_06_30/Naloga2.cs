namespace Izpit_2_2023_06_30
{
    /// <summary>
    /// NALOGA 2:
    /// V tej datoteki sta definirana razreda Kuhinja in KuhinjskiElement.
    /// Kuhinja predstavlja kuhinjo v stanovanju,
    /// ki ima kot lastnost elemente (omarice, hladilnik, pečico...)
    /// in površino, ki jo ima na voljo.
    /// 
    /// Za razred KuhinjskiElement naredite podrazred Hladilnik, 
    /// ki bo imel dodatno lastnost EnergijskiRazred,
    /// in še en podrazred po lastni izbiri.                                    [3 točke]
    /// 
    /// V razredih KuhinjskiElement in Hladilnik povozite metodo ToString, 
    /// da bo ustrezno vračala vse lastnosti instanc.                           [5 točk]
    /// 
    /// Metodo ToString povozite tudi v razredu Kuhinja,
    /// vrne naj niz s površino in opisom vseh elementov kuhinje.               [5 točk]
    /// 
    /// V razredu Kuhinja napišite še metodo, ki bo izpisala skupno površino elementov.
    /// Metoda vrača površino, ki je v kuhinji še na voljo za nove elemente.    [7 točk]
    ///                                                         
    /// Pripravite instanco razreda Kuhinja,
    /// ki bo imela na seznamu vsaj štiri elemente 
    /// od tega natanko element tipa Hladilnik in eno instanco razreda, 
    /// ki ste ga definirali sami.
    /// Na koncu instanco kuhinje tudi izpišite.                                [5 točk]
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

    public class Kuhinja
    {
        public Kuhinja(double povrsina)
        {
            Povrsina = povrsina;
            KuhinjskiElementi = new List<KuhinjskiElement>();
        }

        public double Povrsina { get; set; }

        public List<KuhinjskiElement> KuhinjskiElementi { get; set; }
    }

    public class KuhinjskiElement
    {
        public KuhinjskiElement(string naziv, double cena, double povrsina)
        {
            Naziv = naziv;
            Cena = cena;
            Povrsina = povrsina;
        }

        public string Naziv { get; set; }
        public double Cena { get; set; }
        public double Povrsina { get; set; }
    }
}