namespace Izpit_2025_04_19
{
    /// <summary>
    /// NALOGA 1:
    /// 
    /// Napišite funkcijo ProduktStevk, ki kot parameter prejme seznam celih števil. 
    /// Za vsako število iz seznama naj izračuna produkt njegovih števk 
    /// (npr. produkt števk števila 23 je 6) in na zaslon izpiše tista
    /// (originalna) števila, katerih produkt je manjši od 50.                      [15 točk]
    /// 
    /// Funkcija naj produkte števk vseh števil iz danega seznama sešteje 
    /// in ta seštevek vrne.                                                        [5 točk]
    /// 
    /// V funkciji ResitevNaloge pripravite seznam z vsaj petimi celimi števili, 
    /// pokličite funkcijo ProduktStevk in izpišite skupno vsoto vseh števk, 
    /// ki jo metoda vrne, v ukazno vrstico.                                        [5 točk]
    /// </summary>
    public class Naloga1
    {
        /// <summary>
        /// V tej funkciji se začne izvajati program za reševanje Naloge 1
        /// </summary>
        public static void ResitevNaloge()
        {
            List<int> stevila = new List<int>() { 23, 125, 9, 1287, 11111111 };
            Console.WriteLine($"Skupna vsota vseh štvil je: {ProduktStevk(stevila)}");

            /*
            string pod = "Ananas je 54 južno 093 sa5dj32e, ki je 109 lah0ko ki78sl0o";

            string rezultat = PrimerNaPonavljanju(pod);
            Console.WriteLine($"Rešitev je: {rezultat}");

            // ali

            Console.WriteLine($"Rešitev je: {PrimerNaPonavljanju(pod)}");
            */
        }

        public static int ProduktStevk(List<int> stevila)
        {
            int vsota = 0;
            foreach (int stevilo in stevila)
            {
                //razbijemo st. 23 na števke
                string str = stevilo.ToString();
                int produkt = 1;
                foreach (char chrStevka in str)
                {
                    int stevka = int.Parse(chrStevka.ToString());
                    produkt *= stevka;

                }
                vsota += produkt;
                if (produkt < 50)
                {
                    Console.WriteLine(stevilo);
                }
            }
            return vsota;

        }

        /// <summary>
        /// Iz besedila pobriše vse števke.
        /// </summary>
        private static string PrimerNaPonavljanju(string podatek)
        {
            char[] stevila = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string novPodatek = "";

            
            // Prvi način
            foreach (char znak in podatek)
            {
                // Če znak ni število, ga dodamo v nov niz
                if (stevila.Contains(znak) == false) // lahko tudi: if (!stevila.Contains(znak))
                {
                    novPodatek += znak;
                }
            }            

            /*
            // Drugi način
            for (int i = 0; i < podatek.Length; i++)
            {
                // Če znak je število, ga nadomestimo s praznim stringom ("")
                if (stevila.Contains(podatek[i]))
                {
                    podatek = podatek.Remove(i, 1);
                    i = i - 1;
                }
            }
            novPodatek = podatek;
            */

            return novPodatek;
        }
    }
}