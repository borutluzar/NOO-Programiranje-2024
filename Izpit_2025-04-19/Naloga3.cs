namespace Izpit_2025_04_19
{
    /// <summary>
    /// NALOGA 3:
    /// Pripravite razreda Izpit in IzpitnaNaloga.
    /// 
    /// Razred IzpitnaNaloga naj vsebuje:
    /// -   Lastnosti ZaporednaStevilka, Tezavnost (od 1 do 5), SteviloTock, Besedilo.
    /// -   Natanko en konstruktor, ki nastavi vsaj dve lastnosti.                      
    /// -   Funkcijo ToString, ki naj izpiše vse podatke o nalogi.         [8 točk]
    /// 
    /// Razred Izpit naj vsebuje: 
    /// -   Lastnosti ImePredmeta, ZaporednaStevilka (prvi, drugi, ...), Datum, 
    ///     CasPisanja (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!),
    ///     Naloge (seznam nalog).
    /// -   En konstruktor, ki omogoča določitev natanko dveh lastnosti, 
    ///     in en prazen konstruktor, ki naj vseeno določi čas pisanja.
    ///     V obeh konstruktorjih inicializirajte seznam nalog.
    /// -   Funkcijo ToString, ki naj izpiše vse podatke o izpitu.               
    /// -   Funkcijo, ki izpiše vse izpitne naloge, 
    ///     katerih besedilo vsebuje vsaj 300 znakov.                               [12 točk]
    /// 
    /// V funkciji ResitevNaloge kreirajte instanco razreda Izpit, 
    /// ki naj vsebuje vsaj pet izpitnih nalog
    /// in izpišite podatke o vseh nalogah, pri katerih lahko dosežemo vsaj 10 točk 
    /// in katerih težavnost je nižja od 4.                                         [5 točk]
    /// </summary>
    public class Naloga3
    {
        /// <summary>
        /// V tej funkciji se začne izvajati program za reševanje Naloge 3
        /// </summary>
        public static void ResitevNaloge()
        {
            Izpit izpProg = new Izpit();
            izpProg.ImePredmeta = "Programiranje";
            
            IzpitnaNaloga nal1 = new IzpitnaNaloga(1, 20);
            nal1.Besedilo = "Lorem ipsum etc.";
            nal1.Tezavnost = 3;

            IzpitnaNaloga nal2 = new IzpitnaNaloga(2, 30);
            nal2.Besedilo = "Lorem ipsum etc.";
            nal2.Tezavnost = 4;

            IzpitnaNaloga nal3 = new IzpitnaNaloga(3, 20);
            nal3.Besedilo = "Lorem ipsum etc.";
            nal3.Tezavnost = 3;

            IzpitnaNaloga nal4 = new IzpitnaNaloga(4, 20);
            nal4.Besedilo = "Krokodil Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.Lorem ipsum etc.";
            nal4.Tezavnost = 3;

            izpProg.Naloge.Add(nal1);
            izpProg.Naloge.Add(nal2);
            izpProg.Naloge.Add(nal3);
            izpProg.Naloge.Add(nal4);

            // izpišite podatke o vseh nalogah,
            // pri katerih lahko dosežemo vsaj 10 točk 
            // in katerih težavnost je nižja od 4.
            foreach (IzpitnaNaloga naloga in izpProg.Naloge)
            {
                if(naloga.Tezavnost < 4 && naloga.SteviloTock >= 10)
                {
                    Console.WriteLine(naloga.ToString());
                }
            }
        }
    }

    /// Pripravite razreda Izpit in IzpitnaNaloga.

    /// Razred IzpitnaNaloga naj vsebuje:
    /// -   Lastnosti ZaporednaStevilka, Tezavnost (od 1 do 5), SteviloTock, Besedilo.
    /// -   Natanko en konstruktor, ki nastavi vsaj dve lastnosti.                      
    /// -   Funkcijo ToString, ki naj izpiše vse podatke o nalogi.         [8 točk]
    public class IzpitnaNaloga
    {
        public int ZaporednaStevilka { get; set; }
        public int Tezavnost { get; set; }
        public double SteviloTock { get; set; }
        public string Besedilo { get; set; }

        public IzpitnaNaloga(int zapSt, double stTock)
        {
            ZaporednaStevilka = zapSt;
            SteviloTock = stTock;
        }

        public override string ToString()
        {
            return $"{ZaporednaStevilka}. ({Tezavnost})\t {Besedilo}\n{SteviloTock}";
        }
    }

    /// Razred Izpit naj vsebuje: 
    /// -   Lastnosti ImePredmeta, ZaporednaStevilka (prvi, drugi, ...), Datum, 
    ///     CasPisanja (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!),
    ///     Naloge (seznam nalog).
    /// -   En konstruktor, ki omogoča določitev natanko dveh lastnosti, 
    ///     in en prazen konstruktor, ki naj vseeno določi čas pisanja.
    ///     V obeh konstruktorjih inicializirajte seznam nalog.
    /// -   Funkcijo ToString, ki naj izpiše vse podatke o izpitu.               
    /// -   Funkcijo, ki izpiše vse izpitne naloge, 
    ///     katerih besedilo vsebuje vsaj 300 znakov.                               [12 točk]
    public class Izpit
    {
        public string ImePredmeta { get; set; }
        public int ZaporednaStevilka { get; set; }
        public DateTime Datum { get; set; }
        public int CasPisanja { get; }
        public List<IzpitnaNaloga> Naloge { get; set; }

        public Izpit(string ime, List<IzpitnaNaloga> naloge)
        {
            ImePredmeta = ime;
            Naloge = naloge;
        }

        public Izpit()
        {
            CasPisanja = 90;
            Naloge = new List<IzpitnaNaloga>();
        }

        public override string ToString()
        {
            string rezultat = $"Izpit za predmet {ImePredmeta}\n\n" +
                $"{ZaporednaStevilka}. izpit\t(Čas pisanja: {CasPisanja})\n" +
                $"{Datum:dd. MM. yyyy}\n";

            foreach (var naloga in Naloge)
            {
                rezultat += "\n" + naloga.ToString();
            }

            return rezultat;
        }

        public void DolgeNaloge()
        {
            foreach (IzpitnaNaloga naloga in Naloge)
            {
                if (naloga.Besedilo.Length > 300)
                {
                    Console.WriteLine(naloga);
                }
            }
        }
    }
}