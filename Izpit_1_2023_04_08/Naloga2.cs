using System.Security.Cryptography;
using System.Text;

namespace Izpit_1_2023_04_08
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

            Menu menuTorek = new Menu("Torek");
            Menu menuSreda = new Menu("Sreda");

            Jed spagetiPoMilansko = new Jed("Špageti po milansko", 7.60);
            Jed polpeti = new Jed("Polpeti", 7.60);
            Sladica tortica = new Sladica("Tortica", 2.40, kalorije: 1000);
            
            Jed bograc = new Jed("Bograč", 6.90);
            Jed polpetiVegi = new Jed("Polpeti vegi", 7.60);
            Sladica palacinke = new Sladica("Palacinke", 3.40, kalorije: 400);

            menuTorek.Jedi.Add(spagetiPoMilansko);
            menuTorek.Jedi.Add(polpeti);
            menuTorek.Jedi.Add(tortica);

            menuSreda.Jedi.Add(bograc);
            menuSreda.Jedi.Add(polpetiVegi);
            menuSreda.Jedi.Add(palacinke);

            Console.WriteLine($"{menuTorek.ToString()}");
            Console.WriteLine($"{menuSreda.ToString()}");
        }
    }

    /// Metodo ToString povozite tudi v razredu Menu,
    /// vrne naj niz z dnevom in vsemi jedmi, ki so na menuju, 
    /// med seboj pa naj bodo ločene s prazno vrstico.          [5 točk]
    public class Menu
    {
        public Menu(string dan)
        {
            Dan = dan;
            Jedi = new List<Jed>();
        }

        public string Dan { get; set; }

        public List<Jed> Jedi { get; set; }

        public override string ToString()
        {
            string rezultat = $"Dan - {this.Dan}\n";

            foreach (Jed jed in Jedi)
            {
                rezultat += jed.ToString() + "\n";
            }

            return rezultat;
        }

        /// V razredu Menu napišite še metodo, ki bo izpisala skupno ceno menuja.
        /// Metoda naj ima vhodni parameter tipa bool, ki bo določal, 
        /// ali želite ob ceni plačati še 10% napitnine ali ne.
        /// Če je vrednost parametra true, naj se skupna cena primerno izračuna.
        ///                                                         [7 točk]
        public double SkupnaCena(bool dajNapitnino)
        {
            double skupnaCena = 0.0;
            foreach(var jed in Jedi)
            {
                skupnaCena += jed.Cena;
            }

            // Preverimo dodajanje napitnine
            if (dajNapitnino == true)
            {
                skupnaCena += skupnaCena * 1.10;
            }
            return skupnaCena;
        }
    }

    /// V razredih Jed in Sladica povozite metodo ToString, 
    /// da bo ustrezno vračala vse lastnosti instanc.     [5 točk]
    public class Jed
    {
        public Jed(string naziv, double cena)
        {
            Naziv = naziv;
            Cena = cena;
        }

        public string Naziv { get; set; }
        public double Cena { get; set; }

        public override string ToString()
        {
            string rezultat = $"Naziv: {this.Naziv}\n" +
                $"Cena: {this.Cena}";
            return rezultat;
        }
    }

    /// Za razred Jed naredite podrazred Sladica, 
    /// ki bo imel dodatno lastnost Kalorije.       [3 točke]
    public class Sladica : Jed
    {
        public Sladica(string naziv, double cena, int? kalorije = null /* uporabimo opcijski parameter */)
            : base(naziv, cena)
        {
            Kalorije = kalorije;
        }

        public int? Kalorije { get; set; }

        public override string ToString()
        {
            string rezultat = base.ToString() + "\n" +
                $"Kalorije: {this.Kalorije}";
            return rezultat;
        }
    }
}

