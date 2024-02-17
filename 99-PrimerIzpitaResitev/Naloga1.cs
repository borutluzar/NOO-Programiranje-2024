using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpitaResitev
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
            // Definiramo seznam za imena in priimke
            List<string> seznamImen = new List<string>();

            // Pripravimo števec vnosov
            int stevec = 0;

            // Zanka, ki zahteva vpis do 6 oseb
            while (stevec < 6)
            {
                // Najprej povemo uporabniku, kaj od njega pričakujemo
                Console.Write($"Vpišite ime in priimek: ");
                // Preberemo njegov vnos
                string imeInPriimek = Console.ReadLine();
                // Vse črke pretvorimo v velike, zaradi primerjav v drugem delu
                imeInPriimek = imeInPriimek.ToUpper();
                // Shranimo vnos v seznam
                seznamImen.Add(imeInPriimek);
                // Povečamo števec
                stevec = stevec + 1;
            }
            // Imamo prvih 8 točk

            // Preverjanje, če ime vsebuje T in če priimek vsebuje N
            List<string> filtriranSeznam = new List<string>();
            // Spremenljivka, ki šteje goste z imenom ali priimkom daljšim od 6 črk
            int stGostovZImenomInPriimkomVsaj7 = 0;
            foreach (string imeInPriimek in seznamImen)
            {
                // "Borut Lužar" -- Split --> ["Borut", "Lužar"]
                string[] tabImePriimek = imeInPriimek.Split(' ');

                string ime = tabImePriimek[0];
                string priimek = tabImePriimek[1];

                // Če ime ne vsebuje T in priimek ne vsebuje N, dodamo v nov seznam
                if (!(VsebujeZnak(ime, 'T') || VsebujeZnak(priimek, 'N')))
                {
                    filtriranSeznam.Add(imeInPriimek);

                    // Preverimo dolžino imena in priimka
                    if(ime.Length > 6 || priimek.Length > 6)
                    {
                        stGostovZImenomInPriimkomVsaj7++;
                    }
                }
            }
            // Imamo še 10 točk


            // Izpišemo vse goste iz prečiščenega seznama
            foreach (string ime in filtriranSeznam)
            {
                Console.WriteLine(ime);
            }
            // Izpis števila gostov
            Console.WriteLine($"Število gostov z imenom ali priimkom " +
                $"daljšim od 6 znakov je {stGostovZImenomInPriimkomVsaj7}.");
            // Imamo vseh 25 točk
        }

        private static bool VsebujeZnak(string beseda, char znak)
        {
            int indeksZnaka = beseda.IndexOf(znak);

            if (indeksZnaka != -1)
                return true;
            return false;
        }
    }
}