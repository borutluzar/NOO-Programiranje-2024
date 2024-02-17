using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpita
{
    /// <summary>
    /// NALOGA 2:
    /// V metodi ResitevNaloge imate pripravljena dva seznama.
    /// Prvi je seznam predmetov, drugi pa seznam vpisnih številk študentov.
    /// 
    /// Definirana sta tudi razreda Student in Predmet.
    /// 
    /// Za vsako vpisno številko pripravite instanco razreda Student,
    /// ki bo imel dano vpisno številko in seznam vseh šestih predmetov,
    /// pri čemer za vsak predmet oceno izberete slučajno med ocenami
    /// od 6 do 10. [10 točk]
    /// 
    /// V razred Student dodajte metodo, ki izračuna in vrne povprečno oceno študenta. [5 točk]
    /// 
    /// Na koncu izpišite povprečno oceno študentov pri vsakem od predmetov. [10 točk]
    /// </summary>
    public class Naloga2
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 2
        /// </summary>
        public static void ResitevNaloge()
        {
            // *** KODE OD TUKAJ DO SPODNJE MEJE NE SPREMINJAJTE!

            // Seznam predmetov
            List<string> lstImenaPredmetov = new List<string>() 
            { 
                "Uvod v programiranje",
                "Uvod v algoritme",
                "Uvod v informatiko",
                "Spletno programiranje",
                "Baze podatkov",
                "Razvoj aplikacij"
            };

            // Seznam vpisnih številk študentov
            List<int> lstVpisneStevilke = new List<int>();
            for(int i=3530_001; i<=3530_100; i++)
            {
                lstVpisneStevilke.Add(i);
            }
            // *** KODE DO TUKAJ OD ZGORNJE MEJE NE SPREMINJAJTE!

            // Sprehodimo se čez vse vpisne številke
            Random rnd = new Random();
            List<Student> lstStudenti = new List<Student>();

            foreach(int vpSt in lstVpisneStevilke)
            {
                Student student = new Student(vpSt);

                foreach(string imePredmeta in lstImenaPredmetov)
                {
                    int ocena = rnd.Next(6, 11);
                    Predmet predmet = new Predmet(imePredmeta, ocena);
                    student.Ocene.Add(predmet);
                }

                lstStudenti.Add(student);
            }

            Console.WriteLine($"Seznam študentov vsebuje {lstStudenti.Count} študentov.");            
            Console.WriteLine($"Študent 50 ima povprečno oceno {lstStudenti[49].PovprecnaOcena():0.00}.");

            for(int i=0; i<lstImenaPredmetov.Count; i++)
            {
                double povpOc = lstStudenti.Average(student => student.Ocene[i].Ocena);
                Console.WriteLine($"Povprečna ocena pri predmetu {lstImenaPredmetov[i]} je {povpOc:0.00}");

                /*foreach(Student student in lstStudenti)
                {

                }*/
            }
        }
    }

    public class Student
    {
        public Student(int vpSt)
        {
            VpisnaStevilka = vpSt;
            Ocene = new List<Predmet>();
        }

        public int VpisnaStevilka { get; }

        public List<Predmet> Ocene { get; set; }

        public double PovprecnaOcena()
        {
            return this.Ocene.Average(predmet => predmet.Ocena);
        }
    }

    public class Predmet
    {
        public Predmet(string naziv, int ocena)
        {
            Naziv = naziv;
            Ocena = ocena;
        }

        public string Naziv { get; set; }
        public int Ocena { get; set; }
    }
}