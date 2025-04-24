namespace Izpit_2025_04_19
{
    /// <summary>
    /// NALOGA 2:
    /// 
    /// V podjetju ima vsak zaposleni nekaj različnih prenosnih naprav. 
    /// Da bi imel IT oddelek nadzor nad inventarjem, pripravlja aplikacijo, 
    /// za katero pa potrebuje vašo pomoč.
    /// 
    /// Napišite razred MobilnaNaprava, ki ima lastnosti LetoIzdelave, 
    /// Cena, Ima5GModul in TipProcesorja. 
    /// V razredu pripravite še natanko en konstruktor,  
    /// ki kot parameter dobi leto izdelave. 
    /// Povozite tudi metodo ToString.                                          [5 točk]
    /// 
    /// Za razred MobilnaNaprava pripravite tri podrazrede: 
    /// Telefon, Tablica in Prenosnik. 
    /// Za vsako od naprav si zamislite po dve ustrezni specifični lastnosti 
    /// in ju implementirajte. 
    /// V vsakem od podrazredov ustrezno popravite še funkcijo ToString.          [6 točk]
    ///     
    /// Napišite razred Zaposleni, 
    /// ki naj ima lastnosti Naprave (seznam naprav, ki jih ima zaposleni) 
    /// in SkupnaVrednost (vsota cen vseh naprav zaposlenega). 
    /// Dodajte še funkcijo, ki vrne najdražjo napravo zaposlenega, 
    /// in funkcijo, ki vrne najstarejšo napravo zaposlenega.                   [9 točk]
    /// 
    /// V funkciji ResitevNaloge ustvarite eno instanco razreda Zaposleni 
    /// in na njegov seznam dodajte tri naprave različnih tipov. 
    /// Na zaslon s pomočjo klica ustrezne funkcije izpišite 
    /// ceno najdražje naprave tega zaposlenega.                                [5 točk]
    /// </summary>
    public class Naloga2
    {
        /// <summary>
        /// V tej funkciji se začne izvajati program za reševanje Naloge 2
        /// </summary>
        public static void ResitevNaloge()
        {
            /*
            Prenosnik prenosnik = new Prenosnik(true, "srebrn", 2020);
            prenosnik.Ima5GModul = true;
            prenosnik.TipProcesorja = "tip1";
            */

            Tablica tablica = new Tablica(2023, 30, 7.5);
            tablica.Ima5GModul = false;
            tablica.TipProcesorja = "tip2";

            Telefon telefon = new Telefon(true, "Nokia", 2000);
            telefon.Ima5GModul = true;
            telefon.TipProcesorja = "tip3";

            Zaposleni z = new Zaposleni();
            //z.Naprave.Add(prenosnik);
            z.Naprave.Add(tablica);
            z.Naprave.Add(telefon);

            Console.WriteLine("Cena najdražje naprave zaposlenega je: " + z.Najdrazja().Cena);
        }

        /// Napišite razred Zaposleni, 
        /// ki naj ima lastnosti Naprave (seznam naprav, ki jih ima zaposleni) 
        /// in SkupnaVrednost (vsota cen vseh naprav zaposlenega). 
        /// Dodajte še funkcijo, ki vrne najdražjo napravo zaposlenega, 
        /// in funkcijo, ki vrne najstarejšo napravo zaposlenega.
        /// 
        public class Zaposleni
        {

            public List<MobilnaNaprava> Naprave { get; set; } = new List<MobilnaNaprava>();
            public MobilnaNaprava SkupnaVrednost { get; set; }

            /// Dodajte še funkcijo, ki vrne najdražjo napravo zaposlenega, 
            /// in funkcijo, ki vrne najstarejšo napravo zaposlenega.
            public MobilnaNaprava Najstarejsa()
            {
                int najstarejsa = 2025;
                MobilnaNaprava najstar = Naprave[0];
                for (int i = 0; i < Naprave.Count(); i++)
                {
                    /* */
                }
                return najstar;

            }

            public MobilnaNaprava Najdrazja()
            {
                return new MobilnaNaprava(2000);
            }
        }

        public class MobilnaNaprava
        {
            public MobilnaNaprava(int letoIzdelave)
            {
                LetoIzdelave = letoIzdelave;
            }
            public int LetoIzdelave { get; set; }
            public int Cena { get; set; }
            public bool Ima5GModul { get; set; }
            public string TipProcesorja { get; set; }

            public override string ToString()
            {
                string izpis = $"\nLastnosti mobilne naprave: \n" +
                    $"\nLeto izdelave: {LetoIzdelave}\n" +
                    $"\nCena: {Cena}\n" +
                    $"\nIma 5G modul: {(Ima5GModul ? "da" : "ne")}\n" +
                    $"\nTip procesorja: {TipProcesorja}\n";

                return izpis;
            }
        }

        public class Tablica : MobilnaNaprava
        {

            public Tablica(int letoIzdelave, int casPolnjena, double velikostZaslona) : base(letoIzdelave)
            {
                Cena = casPolnjena;
                VelikostZaslona = velikostZaslona;
            }
            public int CasPolnjenja { get; set; }
            public double VelikostZaslona { get; set; }

            public override string ToString()
            {
                string izpis = base.ToString() +
                    $"Čas polnjenja: {CasPolnjenja}\n" +
                    $"Velikost zaslona: {VelikostZaslona}\n";
                return izpis;
            }
        }
        /// <summary>
        /// telefon, prenosnik
        /// </summary>
        public class Telefon : MobilnaNaprava
        {
            public Telefon(bool vhodZaSlusalke, string znamka, int letoIzdelave) : base(letoIzdelave)
            {
                VhodZaSlusalke = vhodZaSlusalke;
                Znamka = znamka;
            }
            public bool VhodZaSlusalke { get; set; }
            public string Znamka { get; set; }

            public override string ToString()
            {
                string izpis = base.ToString() +
                    $"\nIma vhod za slusalke: {(VhodZaSlusalke ? "da" : "ne")}\n" +
                    $"Znamka: {Znamka}\n";
                return izpis;
            }
        }
        public class Prenosnik
        {

        }
    }
}