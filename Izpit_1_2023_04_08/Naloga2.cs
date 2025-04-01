using System.Security.Cryptography;
using System.Text;

namespace Izpit_2023_04_08
{
    /// <summary>
    /// NALOGA 2:
    /// V tej datoteki sta definirana razreda Menu in Jed.
    /// Menu predstavlja dnevni menu v restavraciji (glede na dan),
    /// ki ima kot lastnost tudi seznam jedi.
    /// Posamezna jed ima lastnosti naziv in cena.
    /// 
    /// Za razred Jed naredite podrazred Sladica, 
    /// ki bo imel dodatno lastnost Kalorije.                   [3 točke]
    /// 
    /// V razredih Jed in Sladica povozite metodo ToString, 
    /// da bo ustrezno vračala vse lastnosti instanc.           [5 točk]
    /// 
    /// Metodo ToString povozite tudi v razredu Menu,
    /// vrne naj niz z dnevom in vsemi jedmi, ki so na menuju, 
    /// med seboj pa naj bodo ločene s prazno vrstico.          [5 točk]
    /// 
    /// V razredu Menu napišite še metodo, ki bo izpisala skupno ceno menuja.
    /// Metoda naj ima vhodni parameter tipa bool, ki bo določal, 
    /// ali želite ob ceni plačati še 10% napitnine ali ne.
    /// Če je vrednost parametra true, naj se skupna cena primerno izračuna.
    ///                                                         [7 točk]
    ///                                                         
    /// Za vsaj dva dni v tednu pripravite instanci razreda Menu,
    /// ki bosta imeli na seznamu jedi vsaj po tri jedi, 
    /// od tega vsak natanko eno jed tipa Sladica. 
    /// Na koncu oba menuja tudi izpišite                       [5 točk]
    /// </summary>
    public class Naloga2
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 2
        /// </summary>
        public static void ResitevNaloge()
        {
            /// Za vsaj dva dni v tednu pripravite instanci razreda Menu,
            /// ki bosta imeli na seznamu jedi vsaj po tri jedi, 
            /// od tega vsak natanko eno jed tipa Sladica. 
            /// Na koncu oba menuja tudi izpišite                       [5 točk]

            Menu menuPon = new Menu("Ponedeljek");
            Menu menuTor = new Menu("Torek");

            Jed jetrca = new Jed("Jetrca", 5.50);
            Jed bograc = new Jed("Bograč", 6.50);
            Sladica tiramisu = new Sladica("Tiramisu", 3.00, 400);
            menuPon.Jedi.Add(jetrca);
            menuPon.Jedi.Add(bograc);
            menuPon.Jedi.Add(tiramisu);

            Jed minestra = new Jed("Minestra", 5.40);
            Jed spageti = new Jed("Špageti po milansko", 7.20);
            Sladica puding = new Sladica("Čokoladni puding", 2.80, 400);
            menuTor.Jedi.Add(minestra);
            menuTor.Jedi.Add(spageti);
            menuTor.Jedi.Add(puding);

            Console.WriteLine($"{menuPon.ToString()}");
            Console.WriteLine($"Skupna cena menuja za {menuPon.Dan} je {menuPon.CenaMenuja(true):0.00}");

            Console.WriteLine($"{menuTor.ToString()}");
            Console.WriteLine($"Skupna cena menuja za {menuTor.Dan} je {menuTor.CenaMenuja(false):0.00}");
        }
    }

    public class Menu
    {
        public Menu(string dan)
        {
            Dan = dan;
            Jedi = new List<Jed>();
        }

        public string Dan { get; set; }

        public List<Jed> Jedi { get; set; }

        /// Metodo ToString povozite tudi v razredu Menu,
        /// vrne naj niz z dnevom in vsemi jedmi, ki so na menuju, 
        /// med seboj pa naj bodo ločene s prazno vrstico.          [5 točk]
        public override string ToString()
        {
            string izpisMenuja = $"Menu za {this.Dan}\n\n";

            foreach (Jed jed in this.Jedi)
            {
                izpisMenuja += jed.ToString() + "\n";
            }

            return izpisMenuja;
        }

        /// V razredu Menu napišite še metodo, ki bo izpisala skupno ceno menuja.
        /// Metoda naj ima vhodni parameter tipa bool, ki bo določal, 
        /// ali želite ob ceni plačati še 10% napitnine ali ne.
        /// Če je vrednost parametra true, naj se skupna cena primerno izračuna.
        ///                                                         [7 točk]
        public double CenaMenuja(bool napitnina)
        {
            double cena = 0;

            foreach (Jed jed in this.Jedi)
            {
                cena += jed.Cena;
            }

            if(napitnina == true)
            {
                cena *= 1.10;
            }

            return cena;
        }
    }

    public class Jed
    {
        public Jed(string naziv, double cena)
        {
            Naziv = naziv;
            Cena = cena;
        }

        public string Naziv { get; set; }
        public double Cena { get; set; }

        /// V razredih Jed in Sladica povozite metodo ToString, 
        /// da bo ustrezno vračala vse lastnosti instanc.           [5 točk]
        public override string ToString()
        {
            return $"{this.Naziv} : \t{this.Cena}";
        }
    }

    /// Za razred Jed naredite podrazred Sladica, 
    /// ki bo imel dodatno lastnost Kalorije.                   [3 točke]
    public class Sladica : Jed
    {
        public Sladica(string naziv, double cena, int kalorije) : base(naziv, cena)
        {
            Kalorije = kalorije;
        }

        public int Kalorije { get; set; }

        /// V razredih Jed in Sladica povozite metodo ToString, 
        /// da bo ustrezno vračala vse lastnosti instanc.           
        public override string ToString()
        {
            return $"{base.ToString()}\nPozor, tale jed ima {this.Kalorije} kcal!";
        }
    }
}

