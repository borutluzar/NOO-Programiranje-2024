using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpitaResitev
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
    /// -   Metodo, ki vrne vsa pisala, ki imajo ceno vsaj 3 evre. [10 točk]
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
            // Ustvarimo instanco razreda Peresnica
            Peresnica peresnica = new Peresnica();

            // Ustvarimo še štiri pisala in jih sproti dodamo v peresnico
            Pisalo pisalo1 = new Pisalo("svinčnik", 1.2);
            pisalo1.DolzinaPisala = 0.08;
            pisalo1.Proizvajalec = "Pelikan";
            peresnica.SeznamPisal.Add(pisalo1);

            Pisalo pisalo2 = new Pisalo("kemični svinčnik", 3.4);
            pisalo2.DolzinaPisala = 0.78;
            pisalo2.Proizvajalec = "Pelikan";
            peresnica.SeznamPisal.Add(pisalo2);

            Pisalo pisalo3 = new Pisalo("nalivno pero", 6.8);
            pisalo3.DolzinaPisala = 0.08;
            pisalo3.Proizvajalec = "Pelikan";
            peresnica.SeznamPisal.Add(pisalo3);

            Pisalo pisalo4 = new Pisalo("gosje pero", 0.2);
            pisalo4.DolzinaPisala = 0.20;
            pisalo4.Proizvajalec = "Domača gos";
            peresnica.SeznamPisal.Add(pisalo4);

            // Izpišemo podatke o pisalih, ki imajo ceno vsaj 3 evre
            List<Pisalo> lstFitriran = peresnica.PisalaSCeno(3);
            foreach (Pisalo pisalo in lstFitriran)
            {
                Console.WriteLine(pisalo.ToString());
            }
            // Imamo 5 točk
        }

    }

    class Peresnica
    {
        // Konstruktor
        public Peresnica()
        {
            SeznamPisal = new List<Pisalo>();
        }

        // Lastnosti
        public List<Pisalo> SeznamPisal { get; set; }
        public int Kapaciteta { get; set; }

        // Metoda za filtriranje pisal
        public List<Pisalo> PisalaSCeno(double meja)
        {
            // Seznam s pisali, ki ustrezajo kriteriju
            List<Pisalo> filtriranaPisala = new List<Pisalo>();

            // Preverimo vsa pisala
            foreach (Pisalo pisalo in SeznamPisal)
            {
                // Dodamo jih, če cena ustreza meji
                if (pisalo.CenaPisala >= meja)
                {
                    filtriranaPisala.Add(pisalo);
                }
            }
            return filtriranaPisala;
        }
    }
    // Imamo 10 točk


    class Pisalo
    {
        // Konstruktor
        public Pisalo(string vrsta, double cena)
        {
            VrstaPisala = vrsta;
            CenaPisala = cena;
        }

        // Lastnosti razreda
        public string VrstaPisala { get; set; }
        public double CenaPisala { get; set; }
        public double DolzinaPisala { get; set; }
        public string Proizvajalec { get; set; }

        // Povozimo metodo ToString
        public override string ToString()
        {
            return $"Lastnosti pisala so:\n" +
                $"\t- vrsta pisala: {VrstaPisala}\t" +
                $"\t- cena: {CenaPisala:0.00}\t" +
                $"\t- dolžina: {DolzinaPisala:0.00}\t" +
                $"\t- Proizvajalec: {Proizvajalec};";
        }
        // Imamo 10 točk
    }
}