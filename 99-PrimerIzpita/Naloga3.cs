using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpita
{
    /// <summary>
    /// NALOGA 3:
    /// Pripravite razreda Pisalo in Peresnica.
    /// 
    /// Razred Pisalo naj vsebuje: 
    /// -   Lastnosti VrstaPisala (svinčnik, kemični svinčnik, nalivno pero...),
    ///     CenaPisala, DolžinaPisala, Proizvajalec (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!).
    /// -   Konstruktor, ki omogoča določitev vsaj dveh lastnosti.
    /// -   Povozite metodo ToString, ki naj izpiše vse podatke o pisalu. [10 točk]
    /// 
    /// Razred Peresnica naj vsebuje:
    /// -   Lastnosti SeznamPisal in Kapaciteta (t.j., maksimalno število pisal v peresnici).
    /// -   Konstruktor, ki inicializira seznam pisal.
    /// -   Metodo, ki izpiše vsa pisala, ki imajo ceno vsaj 3 evre. [10 točk]
    /// 
    /// V metodi ResitevNaloge kreirajte instanco razreda Peresnica, ki naj vsebuje vsaj štiri pisala
    /// in izpišite podatke o vseh pisalih, ki imajo ceno vsaj 3 evre. [5 točk]
    /// </summary>
    public class Naloga3
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 3
        /// </summary>
        public static void ResitevNaloge()
        {
            Peresnica mojaLepaPeresnica = new Peresnica();
            mojaLepaPeresnica.Kapaciteta = 4;

            Pisalo pisalo1 = new Pisalo("keminčni svinčnik", "Pelikan");
            pisalo1.Cena = 3.5;
            Pisalo pisalo2 = new Pisalo("nalivnik", "Pelikan");
            pisalo2.Cena = 3;
            Pisalo pisalo3 = new Pisalo("keminčni svinčnik", "Pilot");
            pisalo3.Cena = 2.5;
            Pisalo pisalo4 = new Pisalo("navadni svinčnik", "Drevesarstvo");
            pisalo4.Cena = 4.5;

            mojaLepaPeresnica.SeznamPisal.Add(pisalo1);
            mojaLepaPeresnica.SeznamPisal.Add(pisalo2);
            mojaLepaPeresnica.SeznamPisal.Add(pisalo3);
            mojaLepaPeresnica.SeznamPisal.Add(pisalo4);

            Console.WriteLine(mojaLepaPeresnica.IzpisiDrazjaOd3());
        }
    }



    /// Razred Pisalo naj vsebuje: 
    /// -   Lastnosti VrstaPisala (svinčnik, kemični svinčnik, nalivno pero...),
    ///     CenaPisala, DolžinaPisala, Proizvajalec (tej lastnosti lahko vrednost nastavimo samo v konstruktorju!).
    /// -   Konstruktor, ki omogoča določitev vsaj dveh lastnosti.
    /// -   Povozite metodo ToString, ki naj izpiše vse podatke o pisalu. [10 točk]
    public class Pisalo
    {
        public Pisalo(string vrsta, string proizvajalec)
        {
            Vrsta = vrsta;
            Proizvajalec = proizvajalec;
        }

        public string Vrsta { get; set; }

        public double Cena { get; set; }

        public double Dolzina { get; set; }

        public string Proizvajalec { get; }

        public override string ToString()
        {
            return $"Vrsta: {this.Vrsta}\n" + 
                $"Cena: {this.Cena:0.00}\n" +
                $"Dolžina: {this.Dolzina}\n" +
                $"Proizvajalec: {this.Proizvajalec}";
        }
    }

    /// Razred Peresnica naj vsebuje:
    /// -   Lastnosti SeznamPisal in Kapaciteta (t.j., maksimalno število pisal v peresnici).
    /// -   Konstruktor, ki inicializira seznam pisal.
    /// -   Metodo, ki izpiše vsa pisala, ki imajo ceno vsaj 3 evre. [10 točk]

    public class Peresnica
    {
        public Peresnica()
        {
            SeznamPisal = new List<Pisalo>();
        }

        public List<Pisalo> SeznamPisal { get; set; }
        
        public int Kapaciteta { get; set; }

        public string IzpisiDrazjaOd3()
        {
            string rezultat = "";

            foreach (Pisalo pisalo in SeznamPisal)
            {
                if(pisalo.Cena >= 3)
                {
                    rezultat += pisalo.ToString() + "\n\n";
                }
            }

            return rezultat;
        }
    }
}