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
            IzpitnaNaloga a = new IzpitnaNaloga(1, 5, 20, "besedilo1");
            IzpitnaNaloga b = new IzpitnaNaloga(2, 3, 20, "besedilo2");
            IzpitnaNaloga c = new IzpitnaNaloga(3, 2, 20, "besedilo3");
            IzpitnaNaloga d = new IzpitnaNaloga(4, 1, 20, "besedilo4");
            IzpitnaNaloga e = new IzpitnaNaloga(5, 5, 20, "besedilo5");

            Izpit izpit = new Izpit();
            izpit.Naloge.Add(a);
            izpit.Naloge.Add(b);
            izpit.Naloge.Add(c);
            izpit.Naloge.Add(d);
            izpit.Naloge.Add(e);

            /// in izpišite podatke o vseh nalogah, pri katerih lahko dosežemo vsaj 10 točk 
            /// in katerih težavnost je nižja od 4. 
            
        }
    }

    public class Izpit
    {
        public Izpit(string imePredmeta, string zaporednaStevilka)
        {
            ImePredmeta = imePredmeta;
            ZaporednaStevilka = zaporednaStevilka;
        }

        public Izpit()
        {
            CasPisanja = 90;
            Naloge = new List<IzpitnaNaloga>();
        }
        public string ImePredmeta { get; set; }
        public string ZaporednaStevilka { get; set; }
        public DateOnly Datum { get; set; }
        public int CasPisanja { get; }
        public List<IzpitnaNaloga> Naloge { get; set; }

        public override string ToString()
        {
            string izpis = $"\nPodatki o izpitue: \n" +
                $"\nIme predmetaa: {ImePredmeta}\n" +
                $"\nZaporedna Stevilka: {ZaporednaStevilka}\n" +
                $"\nDatum: {Datum}\n" +
                $"\nCas Pisanja: {CasPisanja}\n";
            foreach (IzpitnaNaloga n in Naloge)
            {
                izpis += n.ToString();
            }
            return izpis;
        }

        public List<IzpitnaNaloga> VecKot300()
        {
            List<IzpitnaNaloga> seznamDolgih = new List<IzpitnaNaloga>();
            foreach (IzpitnaNaloga n in Naloge)
            {
                if (n.Besedilo.Count() >= 300)
                {
                    seznamDolgih.Add(n);

                }
            }
            return seznamDolgih;
        }
    }

    public class IzpitnaNaloga
    {
        public int ZaporednaStevilka { get; set; }
        public int Tezavnost { get; set; }
        public int SteviloTock { get; set; }
        public string Besedilo { get; set; }

        public IzpitnaNaloga(int zapSt, int tezavnost, int steviloTock, string besedilo)
        {
            ZaporednaStevilka = zapSt;
            Tezavnost = tezavnost;
            SteviloTock = steviloTock;
            Besedilo = besedilo;
        }
        public override string ToString()
        {
            string izpis = $"\nLastnosti izpitne naloge: \n" +
                $"\nZaporedna Številka: {ZaporednaStevilka}\n" +
                $"\nTežavnost: {Tezavnost}\n" +
                $"\nŠtevilo točk: {SteviloTock}\n" +
                $"\nBesedilo: {Besedilo}\n";
            return izpis;
        }



    }
}