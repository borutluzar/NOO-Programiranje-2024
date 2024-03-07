namespace RazrediInObjekti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            // Naredimo instanco razreda Table
            Table miza = new Table();
            miza.material = "les";
            miza.numLegs = 4;
            miza.area = 2.5;

            Table klop = new Table();
            klop.material = "les/karbonska vlakna";
            klop.numLegs = 4;
            klop.area = 1.5;


            Dress obleka = new Dress("Versaci");
            //obleka.Designer = "Gucci";


            // Primer obdelave vremenskih podatkov z objekti
            WeatherMeasurement vreme = new WeatherMeasurement(DateTime.Now);
            //vreme.measurementTime = DateTime.Now;
            vreme.Temperature = 17;
            vreme.AirPressure = 1100;
            vreme.WindSpeed = 0.2;

            // Klic objektne metode
            //vreme.WriteProperties();

            // Ponovno nastavimo lastnost merjenja
            //vreme.MeasurementTime = DateTime.Now;

            Console.WriteLine($"Vreme danes ob {vreme.MeasurementTime:HH:mm:ss} je takšno, " +
                $"da imamo:\n{vreme.Temperature} stopinj celzija, " +
                $"\n{vreme.AirPressure} mbar zračnega tlaka in " +
                $"\nhitrost vetra {vreme.WindSpeed} m/s");

            string fileName = "msrmnts.txt";
            WriteMeasurements(fileName);
            WriteMeasurements(fileName);
            WriteMeasurements(fileName);
            WriteMeasurements(fileName);
            WriteMeasurements(fileName);

            // Pokličimo metodo za zbiranje podatkov iz datoteke
            List<WeatherMeasurement> meritve = CollectMeasurements(fileName);

            // Izračunajmo povprečno temperaturo
            // naredimo statično metodo v razredu WeatherMeasurement
            double avgTemperature = WeatherMeasurement.ComputeAverageTemperature(meritve);
            Console.WriteLine($"Povprečna temperatura meritev je {avgTemperature}.");

            Console.Read();
        }

        /// <summary>
        /// Pomožna metoda za zapis slučajnih vremenskih podatkov
        /// </summary>
        static void WriteMeasurements(string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName, true);

            sw.WriteLine(DateTime.Now);
            Random rnd = new Random();
            sw.WriteLine(rnd.Next(-2, 12));
            sw.WriteLine(rnd.Next(800, 1200));
            sw.WriteLine(rnd.Next(2, 5));

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
            WeatherMeasurement weatherMeasurement = new WeatherMeasurement();
            while (srFile.EndOfStream == false)
            {
                string line = srFile.ReadLine();
                counter++;

                switch (counter % 4)
                {
                    case 1:
                        weatherMeasurement.MeasurementTime = DateTime.Parse(line);
                        break;
                    case 2:
                        weatherMeasurement.Temperature = double.Parse(line);
                        break;
                    case 3:
                        weatherMeasurement.AirPressure = double.Parse(line);
                        break;
                    case 0:
                        weatherMeasurement.WindSpeed = double.Parse(line);
                        lstMeasurements.Add(weatherMeasurement);
                        // Ponastavimo vrednosti tekoče spremenljivke
                        weatherMeasurement = new WeatherMeasurement();
                        break;
                }
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
        public string material = "";
        public int numLegs;
        public double area;
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
        public Dress(string designedBy)
        {
            Designer = designedBy;
        }

        // Inicializacija spremenljivke,
        // ki nosi vrednost za lastnost
        private string designer = string.Empty;

        // Definicija lastnosti
        public string Designer
        {
            get
            {
                return designer;
            }
            private set
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

        // Samodejna implementacija lastnosti
        public double Temperature { get; set; }
        public double AirPressure { get; set; }
        public double WindSpeed { get; set; }

        public void WriteProperties()
        {
            Console.WriteLine($"Vreme danes ob {this.MeasurementTime:HH:mm:ss} je takšno, " +
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