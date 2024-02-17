using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpita
{
    /// <summary>
    /// NALOGA 1:
    /// Pripravljate rojstnodnevno zabavo. Kot izkušeni programerji 
    /// boste pripravili aplikacijo za prijavo gostov.
    /// Vaša aplikacija (preprosta metoda, ki z uporabnikom komunicira preko ukazne vrstice)
    /// omogoča vnos imena in priimka (v tem vrstnem redu) vsakega gosta 
    /// in dodajanje teh podatkov v seznam. [8 točk]
    /// 
    /// Ker sumite, da se bo registriralo nekaj nepovabljenih gostov, 
    /// morate seznam na koncu prečistiti. 
    /// Iz njega odstranite vse vnose, v katerih ime vsebuje črko T (malo ali veliko),
    /// in vse vnose, v katerih priimek vsebuje črko N (malo ali veliko). [10 točk]
    /// 
    /// Na koncu še izpišite vse goste (iz prečiščenega seznama) in število takšnih,
    /// ki imajo ime ali priimek daljši od 6 črk. [7 točk]
    /// </summary>
    public class Naloga1
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 1
        /// </summary>
        public static void ResitevNaloge()
        {
            List<Gost> lstGostje = new List<Gost>();

            // Napolnimo seznam gostov
            while (true)
            {
                Gost tmpGost = new Gost();
                Console.Write("Vpišite ime: ");
                tmpGost.Ime = Console.ReadLine();

                Console.Write("Vpišite priimek: ");
                tmpGost.Priimek = Console.ReadLine();

                lstGostje.Add(tmpGost);

                Console.Write("Ali nadaljujem z vnosi? ");
                if (Console.ReadLine().ToLower() != "da")
                    break;
            }

            Console.WriteLine($"Imamo {lstGostje.Count} gostov.");

            // Filtriramo seznam
            List<Gost> lstPreciscen = new List<Gost>();
            foreach(Gost gost in lstGostje)
            {
                /* Zbirke v foreach zanki ne smemo modificirati!
                 * if(gost.Ime.ToLower().Contains("t") || gost.Priimek.ToLower().Contains("n"))
                {
                    lstGostje.Remove(gost);
                }*/

                if ( !(gost.Ime.ToLower().Contains("t") || gost.Priimek.ToLower().Contains("n")) )
                {
                    lstPreciscen.Add(gost);
                }
            }

            // Izpišemo goste
            int stZDolgimiImeni = 0;
            foreach(Gost gost in lstPreciscen)
            {
                Console.WriteLine($"Gost: {gost.Ime} {gost.Priimek}");

                if(gost.Ime.Length >= 6 || gost.Priimek.Length >= 6)
                {
                    stZDolgimiImeni++;
                }
            }
            Console.WriteLine($"Število gostov z dolgimi imeni je {stZDolgimiImeni}");
        }
    }

    public class Gost
    {
        public string Ime { get; set; }
        public string Priimek { get; set; }
    }
}