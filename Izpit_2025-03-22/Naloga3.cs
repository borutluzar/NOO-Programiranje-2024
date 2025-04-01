using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace Izpit_2025_03_22
{
    /// <summary>
    /// NALOGA 3:
    /// Za potrebe društva tabornikov pripravljamo aplikacijo za evidentiranje dreves v gozdovih.
    /// 
    /// Napišite razred Drevo, ki ima lastnosti Vrsta, Višina, Volumen in Starost. 
    /// V razredu pripravite še natanko en konstruktor, 
    /// ki kot parameter dobi vrsto drevesa. 
    /// Povozite tudi funkcijo ToString.                                            [6 točk]
    /// 
    /// Za razred Drevo pripravite dva podrazreda: Listavec in Iglavec. 
    /// Za vsakega od podrazredov si zamislite po eno ustrezno 
    /// specifično lastnost in jo implementirajte. 
    /// V vsakem od podrazredov ustrezno popravite še funkcijo ToString.            [7 točk]
    ///     
    /// Napišite še razred Gozd, ki naj ima lastnosti Lokacija in Drevesa.
    /// Dodajte še funkcijo, ki vrne skupen volumen iglavcev v gozdu, 
    /// in funkcijo, ki vrne povprečno starost dreves, 
    /// katera imajo višino višjo od danega parametra.                              [7 točk]
    /// 
    /// V funkciji ResitevNaloge ustvarite eno instanco razreda Gozd 
    /// in na njegov seznam dreves dodajte štiri drevesa različnih tipov. 
    /// V ukazno vrstico s pomočjo klica ustrezne funkcije 
    /// izpišite skupen volumen vseh iglavcev v gozdu.                              [5 točk]
    /// </summary>
    public class Naloga3
    {
        /// <summary>
        /// V tej funkciji se začne izvajati program za reševanje Naloge 3
        /// </summary>
        public static void ResitevNaloge()
        {
            Gozd krakovski = new Gozd();
            Listavec javor = new Listavec("javor") { Volumen = 5 };
            Listavec hrast = new Listavec("hrast") { Volumen = 10 };
            Iglavec macesen = new Iglavec("macesen") { Volumen = 3 };
            Iglavec bor = new Iglavec("bor") { Volumen = 1 };
            krakovski.Drevesa.Add(javor);
            krakovski.Drevesa.Add(hrast);
            krakovski.Drevesa.Add(macesen);
            krakovski.Drevesa.Add(bor);

            Console.WriteLine($"Skupni volumen vseh iglavcev v krakovskem gozdu je {krakovski.SkupniVolumen()}");
        }
    }

    /// Napišite razred Drevo, ki ima lastnosti Vrsta, Višina, Volumen in Starost. 
    /// V razredu pripravite še natanko en konstruktor, 
    /// ki kot parameter dobi vrsto drevesa. 
    /// Povozite tudi funkcijo ToString.                                            [6 točk]
    public class Drevo
    {
        public Drevo(string vrsta)
        {
            this.Vrsta = vrsta;
        }

        public string Vrsta { get; set; }
        public double Visina { get; set; }
        public double Volumen { get; set; }
        public int Starost { get; set; }

        public override string ToString()
        {
            return $"Drevo vrste {this.Vrsta} (volumen: {this.Volumen})";
        }
    }

    /// Za razred Drevo pripravite dva podrazreda: Listavec in Iglavec. 
    /// Za vsakega od podrazredov si zamislite po eno ustrezno 
    /// specifično lastnost in jo implementirajte. 
    /// V vsakem od podrazredov ustrezno popravite še funkcijo ToString.            [7 točk]
    public class Iglavec : Drevo
    {
        public Iglavec(string vrsta) : base(vrsta)
        {

        }

        public bool Zimzelenost { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {(this.Zimzelenost ? "je" : "ni")} zimzeleno";
        }
    }

    public class Listavec : Drevo
    {
        public Listavec(string vrsta) : base(vrsta)
        {

        }

        public double PovrsinaLista { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} s povprečno površino lista {this.PovrsinaLista}";
        }
    }

    /// Napišite še razred Gozd, ki naj ima lastnosti Lokacija in Drevesa.
    /// Dodajte še funkcijo, ki vrne skupen volumen iglavcev v gozdu, 
    /// in funkcijo, ki vrne povprečno starost dreves, 
    /// katera imajo višino višjo od danega parametra.                              [7 točk]
    public class Gozd
    {
        public string Lokacija { get; set; }
        public List<Drevo> Drevesa { get; set; } = new List<Drevo>();

        public double SkupniVolumen()
        {
            double skupniVolumen = 0;
            foreach (Drevo drevo in this.Drevesa)
            {
                if (drevo is Iglavec)
                {
                    skupniVolumen += drevo.Volumen;
                }
            }
            return skupniVolumen;
        }

        public double PovprecnaStarost(double visina)
        {
            double povprecnaStarost = 0;
            int steviloRelevantnih = 0;
            foreach (Drevo drevo in this.Drevesa)
            {
                if (drevo.Visina > visina)
                {
                    povprecnaStarost += drevo.Starost;
                    steviloRelevantnih++;
                }
            }

            return (double)povprecnaStarost / steviloRelevantnih;
        }
    }
}