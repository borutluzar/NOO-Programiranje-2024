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
    /// in so mlajši od 30 let.          [5 točk]
    /// </summary>
    public class Naloga3
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 3
        /// </summary>
        public static void ResitevNaloge()
        {
            NogometniKlub krka = new NogometniKlub(2_000_000);

            Igralec ronaldo = new Igralec("Christiano", "napadalec", 38);
            ronaldo.CenaIgralca = 200_000;
            
            Igralec messi = new Igralec("Leo", "napadalec", 36);
            messi.CenaIgralca = 200_000;
            
            Igralec benzema = new Igralec("Karim", "napadalec", 35);
            benzema.CenaIgralca = 150_000;
            
            Igralec oblak = new Igralec("Janez", "golman", 38);
            oblak.CenaIgralca = 50_000;
            
            Igralec cesar = new Igralec("Boštjan", "obramba", 42);
            cesar.CenaIgralca = 100_000;

            // Dodajmo igralce na seznam
            krka.SeznamIgralcev.Add(ronaldo);
            krka.SeznamIgralcev.Add(messi);
            krka.SeznamIgralcev.Add(benzema);
            krka.SeznamIgralcev.Add(oblak);
            krka.SeznamIgralcev.Add(cesar);

            krka.IgralciMax(100_000, 30);
        }
    }

    public class NogometniKlub
    {
        // Konstruktor, ki inicializira seznam igralcev in nastavi višino proračuna.
        public NogometniKlub(int proracun) 
        {
            SeznamIgralcev = new List<Igralec>();
            VisinaProracuna = proracun;
        }

        // Lastnosti SeznamIgralcev in VišinaProračuna.
        public List<Igralec> SeznamIgralcev { get; set; }
        public int VisinaProracuna { get; set; }

        // Metodo, ki izpiše vse igralce, ki imajo ceno višjo od danega maksimuma.
        public void IgralciMax(int max)
        {
            foreach(Igralec igralec in this.SeznamIgralcev)
            {
                if(igralec.CenaIgralca > max)
                {
                    Console.WriteLine($"\n{igralec.ToString()}");
                }
            }
        }

        public void IgralciMax(int max, int starost)
        {
            foreach (Igralec igralec in this.SeznamIgralcev)
            {
                if (igralec.CenaIgralca > max && igralec.Starost <= starost)
                {
                    Console.WriteLine($"\n{igralec.ToString()}");
                }
            }
        }
    }

    public class Igralec
    {
        // Konstruktor, ki omogoča določitev natanko dveh lastnosti
        public Igralec(string ime, string polozaj)
        {
            Ime = ime;
            Polozaj = polozaj;
        }

        //  Konstruktor, ki omogoča določitev vsaj treh lastnosti.
        public Igralec(string ime, string polozaj, byte starost)
        {
            Ime = ime;
            Polozaj = polozaj;
            Starost = starost;
        }

        // Lastnosti: 
        // Ime, CenaIgralca, Položaj (napadalec, vezni, vratar, ...),
        // Starost (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!).
        public string Ime { get; set; }
        public int CenaIgralca { get; set; }
        public string Polozaj { get; set;}
        public byte Starost { get; } // Nimamo set, ker lahko pišemo vanjo samo v konstruktorju!

        // Povozite metodo ToString, ki naj izpiše vse podatke o igralcu.
        public override string ToString()
        {
            string opis = $"Ime igralca je {this.Ime}, " +
                $"njegova cena je {this.CenaIgralca}, " +
                $"igra na položaju {this.Polozaj} in " +
                $"star je {this.Starost}.";
            return opis;
        }
    }
}