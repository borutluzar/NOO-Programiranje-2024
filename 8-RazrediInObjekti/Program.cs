using System.Runtime.CompilerServices;

namespace RazrediInObjekti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Naredimo instanco razreda Table
            Table miza = new Table(); // Privzeti konstruktor
            miza.material = "les";
            miza.numLegs = 4;
            miza.area = 2.5;
            miza.color = "beljena bukev";
            miza.personSeats = 2;

            Table klubska = new Table();
            klubska.material = "steklo";
            klubska.numLegs = 0;
            klubska.personSeats = 8;

            Table klop = new Table();
            klop.material = "les/karbonska vlakna";
            klop.numLegs = 4;
            klop.area = 1.5;

            // Določimo še vrednost statične spremenljivke,
            // ki je enaka za izdelavo vsake mize
            Table.hourlyRate = 50.0;


            Dress obleka = new Dress("Versaci");
            Dress oblekaZaVSluzbo = new Dress("Versaci");
            Dress oblekaZaNaRekreacijo = new Dress("Mura");
            Dress oblekaZaPosebnePriložnosti = new Dress();

            // Pridobivanje vrednosti - get
            Console.WriteLine($"Designer obleke je {obleka.Designer}");
            // Nastavljanje vrednosti - set
            obleka.Designer = "Gucci";


            // Primer obdelave vremenskih podatkov z objekti
            WeatherMeasurement vreme = new WeatherMeasurement(DateTime.Now);
            //vreme.measurementTime = DateTime.Now;
            vreme.Temperature = 17;
            vreme.AirPressure = 1100;
            vreme.WindSpeed = 0.2;

            WeatherMeasurement vremeJutri = new WeatherMeasurement(DateTime.Now.AddDays(1));
            //vreme.measurementTime = DateTime.Now;
            vremeJutri.Temperature = 23;
            vremeJutri.AirPressure = 1200;
            vremeJutri.WindSpeed = 1.2;

            // Klic objektne metode
            vreme.WriteProperties();
            vremeJutri.WriteProperties();

            // Ponovno nastavimo lastnost merjenja
            //vreme.MeasurementTime = DateTime.Now;

            Console.WriteLine($"Vreme danes ob {vreme.MeasurementTime:HH:mm:ss} je takšno, " +
                $"da imamo:\n{vreme.Temperature} stopinj celzija, " +
                $"\n{vreme.AirPressure} mbar zračnega tlaka in " +
                $"\nhitrost vetra {vreme.WindSpeed} m/s");


            string fileName = "msrmnts.mes";

            int stMeritev = 100;
            for (int i = 0; i < stMeritev; i++)
            {
                WriteMeasurements(fileName, DateTime.Now.AddDays(-stMeritev + i + 1));
            }

            // Pokličimo metodo za zbiranje podatkov iz datoteke
            List<WeatherMeasurement> meritve = CollectMeasurements(fileName);

            // Izračunajmo povprečno temperaturo
            // naredimo statično metodo v razredu WeatherMeasurement
            double avgTemperature = WeatherMeasurement.ComputeAverageTemperature(meritve);
            Console.WriteLine($"Povprečna temperatura meritev je {avgTemperature}.");
            // Lahko uporabimo tudi že obstoječo metodo,
            // ki uporablja lambda izraze...
            double avgTemperature2 = meritve.Average(obj => obj.Temperature);
            Console.WriteLine($"Povprečna temperatura meritev (z lambdo) je {avgTemperature2}.");

            double avgHitrostVetra = meritve.Average(obj => obj.WindSpeed);
            Console.WriteLine($"Povprečna hitrost vetra meritev (z lambdo) je {avgHitrostVetra}.");

            double maxZracniTlak = meritve.Max(obj => obj.AirPressure);
            Console.WriteLine($"Maksimalni zračni tlak meritev (z lambdo) je {maxZracniTlak}.");

            Console.Read();
        }

        /// <summary>
        /// Pomožna metoda za zapis slučajnih vremenskih podatkov
        /// </summary>
        static void WriteMeasurements(string fileName, DateTime time)
        {
            StreamWriter sw = new StreamWriter(fileName, true);

            // Zapišimo eno meritev v vrstico
            sw.Write($"{time}\t");
            Random rnd = new Random();
            sw.Write(rnd.Next(-2, 23) + "\t");
            sw.Write(rnd.Next(800, 1200) + "\t");
            sw.WriteLine(rnd.Next(0, 36));

            sw.Close();
        }

        /// <summary>
        /// Metoda, s katero preberemo vremenske podatke iz datoteke
        /// in jih zapišemo v objekte za vsako meritev posebej.
        /// Na koncu vrnemo seznam vseh meritev.
        /// </summary>
        static List<WeatherMeasurement> CollectMeasurements(string fileName)
        {
            StreamReader srFile = new StreamReader(fileName);
            List<WeatherMeasurement> lstMeasurements = new List<WeatherMeasurement>();

            int counter = 0;            
            while (srFile.EndOfStream == false)
            {
                string[] line = srFile.ReadLine().Split('\t');
                counter++;

                WeatherMeasurement weatherMeasurement = new WeatherMeasurement(DateTime.Parse(line[0]));
                weatherMeasurement.Temperature = double.Parse(line[1]);
                weatherMeasurement.AirPressure = double.Parse(line[2]);
                weatherMeasurement.WindSpeed = double.Parse(line[3]);
                
                lstMeasurements.Add(weatherMeasurement);
            }
            srFile.Close();
            return lstMeasurements;
        }
    }

    /// <summary>
    /// Pripravimo preprost razred 
    /// s spremenljivkami, ki predstavljajo lastnosti, 
    /// ki so za nas pri mizi pomembne.
    /// </summary>
    public class Table
    {
        // Spremenljivke morajo imeti
        // določilo public, da jih
        // lahko nastavljamo tudi izven razreda
        // To so objektne spremenljivke (nimajo določila statičnosti)
        public string material;
        public int numLegs;
        public double area;
        public string color;
        public int personSeats;

        /// <summary>
        /// Urna postavka za izdelavo
        /// Spremenljivka je statična
        /// </summary>
        public static double hourlyRate;
    }

    public class Book
    {
        public Book(int pages, int year)
        {
            numPages = pages;
            yearPublished = year;
        }

        public int numPages;
        public int yearPublished;
    }

    public class Dress
    {
        // Konstruktor
        public Dress(string designedBy)
        {
            this.Designer = designedBy;
        }

        // Prazen konstruktor
        public Dress()
        {
            Designer = "Gucci";
        }

        // Inicializacija spremenljivke,
        // ki nosi vrednost za lastnost
        private string designer = string.Empty;

        // Definicija lastnosti
        public string Designer
        {
            get // Element za pridobivanje vrednosti lastnosti
            {
                return designer;
            }
            set
            {
                designer = value;
            }
        }
    }

    /// <summary>
    /// Razred za shranjevanje vremenskih podatkov za eno meritev
    /// </summary>
    public class WeatherMeasurement
    {
        // Prazen konstruktor
        public WeatherMeasurement() { }

        // Konstruktor z enim parametrom
        public WeatherMeasurement(DateTime time)
        {
            measurementTime = time;
        }

        private DateTime measurementTime;
        // Definicija lastnosti
        public DateTime MeasurementTime
        {
            // Določimo lastnosti branja
            get
            {
                return measurementTime;
            }
            // Določimo lastnosti pisanja
            set
            {
                measurementTime = value;
            }
        }

        private double temperature;
        public double Temperature
        {
            get { return temperature; }
            set
            {
                if (value < -40 || value > 55)
                    throw new ArgumentException("Vnesite temperaturo, ki je v predvidenih okvirjih.");

                temperature = value;
            }
        }

        // Samodejna implementacija lastnosti
        public double AirPressure { get; set; }
        public double WindSpeed { get; set; }

        /// <summary>
        /// Prva definicija objektne naše metode
        /// </summary>
        public void WriteProperties()
        {
            Console.WriteLine($"Vreme dne {this.MeasurementTime:d. M. yyyy} ob {this.MeasurementTime:HH:mm:ss} " +
                $"je takšno, " +
                $"da imamo:\n{this.Temperature} stopinj celzija, \n" +
                $"{this.AirPressure} mbar zračnega tlaka in \n" +
                $"hitrost vetra {this.WindSpeed} m/s");
        }

        /// <summary>
        /// Izračuna povprečno temperaturo iz danega seznama objektov.
        /// </summary>
        public static double ComputeAverageTemperature(List<WeatherMeasurement> lstWeatherMsrmnts)
        {
            // Način, ki ga poznamo
            double sum = 0;
            foreach (var wm in lstWeatherMsrmnts)
            {
                sum += wm.Temperature;
            }
            double avg = sum / lstWeatherMsrmnts.Count;

            // Izračun s pomočjo lambda izrazov
            // double avg = lstWeatherMsrmnts.Average(wm => wm.Temperature);

            return avg;
        }
    }
}