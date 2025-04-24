namespace Izpit_2025_04_19
{
    /// <summary>
    /// NALOGA 4:
    /// 
    /// V mapi Viri imate pripravljeni dve datoteki z nizi (ki vsebujejo črke ali številke). 
    /// Nizi so v posamezni vrstici ločeni s tabulatorjem.
    /// 
    /// Pripravite funkcijo, ki kot parameter dobi pot do datoteke. 
    /// V podani datoteki naj prešteje vse nize, ki se končajo s črko 'a',
    /// in dobljeno število vrne.           
    /// Ob pregledu nizov naj na zaslon izpiše vsak niz, ki vsebuje števko 1.       [20 točk]
    /// 
    /// V funkciji ResitevNaloge že imate pripravljeni dve spremenljivki 
    /// s potema do obeh datotek.
    /// V tej funkciji pokličite pripravljeno funkcijo za vsako datoteko posebej
    /// in zanju izpišite rezultat.                                                 [5 točk]
    /// </summary>
    public class Naloga4
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 4
        /// </summary>
        public static void ResitevNaloge()
        {
            string filePath1 = "Viri/besede.txt";
            string filePath2 = "Viri/besedeBig.txt";

        }

        public int ReadingFromFiles(string pot)
        {
            int stNizov = 0;

            StreamReader srFile = new StreamReader(pot);

            while (srFile.EndOfStream == false)
            {
                string line = srFile.ReadLine();

                string[] tblPodatki = line.Split("\t");
                // Izpišimo jih
                foreach (string podatek in tblPodatki)
                {
                    int zadnji = podatek.Length;
                    if ((podatek[zadnji - 1] == 'a') || (podatek[zadnji - 1] == 'A'))
                    {
                        stNizov++;
                    }

                    /// Ob pregledu nizov naj na zaslon izpiše vsak niz, ki vsebuje števko 1. 
                    
                }
            }
            srFile.Close();
            return stNizov;
        }
    }
}