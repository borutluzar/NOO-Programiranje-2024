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

            int rezultat1 = Analiziraj(filePath1);
            int rezultat2 = Analiziraj(filePath2);

            Console.WriteLine(rezultat1);
            Console.WriteLine(rezultat2);
        }

        /// Pripravite funkcijo, ki kot parameter dobi pot do datoteke. 
        /// V podani datoteki naj prešteje vse nize, ki se končajo s črko 'a',
        /// in dobljeno število vrne.           
        /// Ob pregledu nizov naj na zaslon izpiše vsak niz, ki vsebuje števko 1.       [20 točk]
        public static int Analiziraj(string pot)
        {
            StreamReader sr = new StreamReader(pot);
            int vsota = 0;
            while (!sr.EndOfStream)
            {
                string vrstica = sr.ReadLine();
                string[] nizi = vrstica.Split("\t");

                foreach (string beseda in nizi)
                {
                    if (beseda.EndsWith('a') || beseda.EndsWith('A'))
                    {
                        vsota++;
                    }

                    if (beseda.Contains("1"))
                    {
                        Console.WriteLine(beseda);
                    }
                }
            }
            sr.Close();
            return vsota;
        }
    }
}