using System.Security.Cryptography;
using System.Text;

namespace Izpit_2023_04_08
{
    /// <summary>
    /// NALOGA 3:
    /// Pripravite razreda Igralec in NogometniKlub.
    /// 
    /// Razred Igralec naj vsebuje: 
    /// -   Lastnosti Ime, CenaIgralca, Položaj (napadalec, vezni, vratar,...), 
    ///     Starost (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!).
    /// -   En konstruktor, ki omogoča določitev natanko dveh lastnosti, 
    ///     in en konstruktor, ki omogoča določitev vsaj treh lastnosti.
    /// -   Povozite metodo ToString, ki naj izpiše vse podatke o igralcu.              [10 točk]
    /// 
    /// Razred NogometniKlub naj vsebuje:
    /// -   Lastnosti SeznamIgralcev in VišinaProračuna.
    /// -   Konstruktor, ki inicializira seznam igralcev in nastavi višino proračuna.
    /// -   Metodo, ki izpiše vse igralce, ki imajo ceno višjo od danega maksimuma.     [10 točk]
    /// 
    /// V metodi ResitevNaloge kreirajte instanco razreda NogometniKlub, ki naj vsebuje vsaj pet igralcev
    /// in izpišite podatke o vseh igralcih, ki imajo ceno vsaj 100_000 evrov 
    /// in so mlajši od 30 let.                                                         [5 točk]
    /// </summary>
    public class Naloga3
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 3
        /// </summary>
        public static void ResitevNaloge()
        {
            /// V metodi ResitevNaloge kreirajte instanco razreda NogometniKlub, ki naj vsebuje vsaj pet igralcev
            /// in izpišite podatke o vseh igralcih, ki imajo ceno vsaj 100_000 evrov 
            /// in so mlajši od 30 let.          [5 točk]

            NogometniKlub nkAtletico = new NogometniKlub(200_000_000);
            Igralec oblak = new Igralec("Jan Oblak", 36, 50_000_000);
            Igralec ronaldo = new Igralec("Christiano Ronaldo", 37, 50_000);
            Igralec messi = new Igralec("Lionel Messi", 38, 100_000);
            Igralec neymar = new Igralec("Neymar", 28, 500_000);
            Igralec mbappe = new Igralec("Killian Mbappe", 26, 2_000_000);

            nkAtletico.Igralci.Add(oblak);
            nkAtletico.Igralci.Add(ronaldo);
            nkAtletico.Igralci.Add(messi);
            nkAtletico.Igralci.Add(neymar);
            nkAtletico.Igralci.Add(mbappe);

            // Dodamo še parameter za omejitev starosti
            nkAtletico.IzpisNajdrazjih(100_000, 30);
        }
    }

    /// Razred Igralec naj vsebuje: 
    /// -   Lastnosti Ime, CenaIgralca, Položaj (napadalec, vezni, vratar,...), 
    ///     Starost (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!).
    /// -   En konstruktor, ki omogoča določitev natanko dveh lastnosti, 
    ///     in en konstruktor, ki omogoča določitev vsaj treh lastnosti.
    /// -   Povozite metodo ToString, ki naj izpiše vse podatke o igralcu.              [10 točk]
    public class Igralec
    {
        public Igralec(string ime, int starost)
        {
            this.Ime = ime;
            this.Starost = starost;
            this.Polozaj = "vratar";
        }

        public Igralec(string ime, int starost, int cena)
        {
            this.Ime = ime;
            this.Starost = starost;
            this.Cena = cena;
            this.Polozaj = "vratar";
        }

        public string Ime { get; set; }

        public int Cena { get; set; }

        public string Polozaj { get; set; }

        public int Starost { get; } // Brez set, ker jo nastavljamo samo v konstruktorju

        public override string ToString()
        {
            return $"Ime: {this.Ime}\n" +
                $"Cena: {this.Cena}\n" +
                $"Starost: {this.Starost}\n" +
                $"Položaj: {this.Polozaj}";
        }
    }

    /// Razred NogometniKlub naj vsebuje:
    /// -   Lastnosti SeznamIgralcev in VišinaProračuna.
    /// -   Konstruktor, ki inicializira seznam igralcev in nastavi višino proračuna.
    /// -   Metodo, ki izpiše vse igralce, ki imajo ceno višjo od danega maksimuma.     [10 točk]
    public class NogometniKlub
    {
        public NogometniKlub(int visinaProracuna)
        {
            this.Igralci = new List<Igralec>();
            this.VisinaProracuna = visinaProracuna;
        }

        public List<Igralec> Igralci { get; set; }

        public int VisinaProracuna { get; set; }

        public void IzpisNajdrazjih(int max, int mejnaStarost)
        {
            Console.WriteLine($"Igralci s ceno višjo od {max} so:");

            foreach (Igralec igralec in this.Igralci)
            {
                if (igralec.Cena > max && igralec.Starost < mejnaStarost)
                {
                    //Console.WriteLine($"{igralec.ToString()}");
                    Console.WriteLine(igralec.Ime);
                }
            }
        }
    }
}