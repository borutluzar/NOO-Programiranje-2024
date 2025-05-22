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