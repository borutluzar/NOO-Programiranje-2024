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
            Zaposleni Marko = new Zaposleni();
            MobilnaNaprava naprava1 = new Prenosnik("AMD", 20, 1982) { Cena = 6000.01 };
            MobilnaNaprava naprava2 = new Telefon(true, "metal", 1999) { Cena = 2.99 };
            MobilnaNaprava naprava3 = new Tablica("Windows", 15, 2022) { Cena = 179.99 };
            Marko.Seznam.Add(naprava1);
            Marko.Seznam.Add(naprava2);
            Marko.Seznam.Add(naprava3);
            MobilnaNaprava najdrazja = Marko.Najdrazja();
            Console.WriteLine(najdrazja.Cena);
        }
    }

    /// Napišite razred MobilnaNaprava, ki ima lastnosti LetoIzdelave, 
    /// Cena, Ima5GModul in TipProcesorja. 
    /// V razredu pripravite še natanko en konstruktor,  
    /// ki kot parameter dobi leto izdelave. 
    /// Povozite tudi metodo ToString.       
    public class MobilnaNaprava
    {
        public int LetoIzdelave { get; set; }
        public double Cena { get; set; }
        public bool Ima5GModul { get; set; }
        public string TipProcesorja { get; set; }

        public MobilnaNaprava(int letoIzdelave)
        {
            LetoIzdelave = letoIzdelave;
        }

        public override string ToString()
        {
            return $"Leto izdelave: {LetoIzdelave}, Cena: {Cena}, Vsebuje modul:{Ima5GModul}, Procesor: {TipProcesorja}";
        }
    }

    /// Za razred MobilnaNaprava pripravite tri podrazrede: 
    /// Telefon, Tablica in Prenosnik. 
    /// Za vsako od naprav si zamislite po dve ustrezni specifični lastnosti 
    /// in ju implementirajte. 
    /// V vsakem od podrazredov ustrezno popravite še funkcijo ToString.    
    public class Telefon : MobilnaNaprava
    {
        public bool Zložljiv { get; set; }
        public string Barva { get; set; }

        public Telefon(bool zložljiv, string barva, int letoIzdelave) : base(letoIzdelave)
        {
            Zložljiv = zložljiv;
            Barva = barva;
        }
        public override string ToString()
        {
            return base.ToString() + $"Zložljivost:{Zložljiv}, Barva:{Barva}";
        }
    }

    public class Tablica : MobilnaNaprava
    {
        public string Vrsta { get; set; }
        public double Velikost { get; set; }

        public Tablica(string vrsta, double velikost, int letoIzdelave) : base(letoIzdelave)
        {
            Vrsta = vrsta;
            Velikost = velikost;
        }
        public override string ToString()
        {
            return base.ToString() + $"Vrsta: {Vrsta}, Velikost: {Velikost}";
        }
    }

    public class Prenosnik : MobilnaNaprava
    {
        public string Vrsta { get; set; }
        public double Velikost { get; set; }

        public Prenosnik(string vrsta, double velikost, int letoIzdelave) : base(letoIzdelave)
        {
            Vrsta = vrsta;
            Velikost = velikost;
        }
        public override string ToString()
        {
            return base.ToString() + $"Vrsta: {Vrsta}, Velikost: {Velikost}";
        }
    }

    /// Napišite razred Zaposleni, 
    /// ki naj ima lastnosti Naprave (seznam naprav, ki jih ima zaposleni) 
    /// in SkupnaVrednost (vsota cen vseh naprav zaposlenega). 
    /// Dodajte še funkcijo, ki vrne najdražjo napravo zaposlenega, 
    /// in funkcijo, ki vrne najstarejšo napravo zaposlenega.                   [9 točk]
    public class Zaposleni
    {
        public List<MobilnaNaprava> Seznam { get; set; } = new List<MobilnaNaprava>();
        public double SkupnaVrednost { get; set; }

        public MobilnaNaprava Najdrazja()
        {
            MobilnaNaprava najdrazja = Seznam[0];
            foreach (MobilnaNaprava naprava in Seznam)
            {
                if (naprava.Cena > najdrazja.Cena)
                {
                    najdrazja = naprava;
                }
            }
            return najdrazja;
        }

        /// V funkciji ResitevNaloge ustvarite eno instanco razreda Zaposleni 
        /// in na njegov seznam dodajte tri naprave različnih tipov. 
        /// Na zaslon s pomočjo klica ustrezne funkcije izpišite 
        /// ceno najdražje naprave tega zaposlenega.    
        public MobilnaNaprava Najstarejsa()
        {
            MobilnaNaprava najstarejsa = Seznam[0];
            foreach (MobilnaNaprava naprava in Seznam)
            {

                if (naprava.LetoIzdelave < najstarejsa.LetoIzdelave)
                {
                    najstarejsa = naprava;
                }
            }
            return najstarejsa;
        }
    }
}