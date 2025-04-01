using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Izpit_2025_03_22
{
    /// <summary>
    /// NALOGA 4:
    /// 
    /// V mapi Viri imate pripravljeni dve datoteki s tabelama števil. 
    /// Števila so v posamezni vrstici ločena s tabulatorjem.
    /// 
    /// Pripravite metodo AnalizaZadnjih, ki kot parameter dobi 
    /// pot do datoteke s tabelo števil. 
    /// Prebere naj zadnje število v vsaki vrstici, 
    /// poišče najmanjše med vsemi in ga prišteje prvemu številu vsake vrstice. 
    /// Tako popravljeno tabelo zapišite v novo datoteko, 
    /// katere ime prav tako prejmete kot parameter metode.                         [20 točk]
    /// 
    /// V metodi ResitevNaloge že imate pripravljeni dve spremenljivki 
    /// s potema do datotek s primeroma tabel.
    /// V tej metodi pokličite pripravljeno metodo za obe datoteki. 
    /// Rezultat bosta dve novi datoteki.                                           [5 točke]
    /// </summary>
    public class Naloga4
    {
        /// <summary>
        /// V tej metodi se začne izvajati program za reševanje Naloge 4
        /// </summary>
        public static void ResitevNaloge()
        {
            string filePath1 = "Viri/matrix.txt";
            string filePath2 = "Viri/matrixBig.txt";

            AnalizaZadnjih(filePath1, "naloga4.txt");
            AnalizaZadnjih(filePath2, "naloga4Big.txt");
        }

        /// Pripravite metodo AnalizaZadnjih, ki kot parameter dobi 
        /// pot do datoteke s tabelo števil. 
        /// Prebere naj zadnje število v vsaki vrstici, 
        /// poišče najmanjše med vsemi in ga prišteje prvemu številu vsake vrstice. 
        /// Tako popravljeno tabelo zapišite v novo datoteko, 
        /// katere ime prav tako prejmete kot parameter metode.                         [20 točk]
        public static void AnalizaZadnjih(string potDoDatoteke, string novaDatoteka)
        {
            StreamReader srFile = new StreamReader(potDoDatoteke);

            List<List<int>> lstMatrika = new List<List<int>>();

            int min = int.MaxValue;

            while (srFile.EndOfStream == false)
            {
                string vrstica = srFile.ReadLine();
                string[] tblStevila = vrstica.Split("\t");
                int zadnjeStevilo = int.Parse(tblStevila[tblStevila.Length - 1]);

                if (min > zadnjeStevilo)
                {
                    min = zadnjeStevilo;
                }

                List<int> lstVrstica = new List<int>();
                foreach (string st in tblStevila)
                {
                    lstVrstica.Add(int.Parse(st));
                }
                lstMatrika.Add(lstVrstica);
            }
            srFile.Close();

            StreamWriter sw = new StreamWriter(novaDatoteka);

            foreach (List<int> lstVrstica in lstMatrika)
            {
                // Zapis posamezne vrstice
                for (int i = 0; i < lstVrstica.Count; i++)
                {
                    if (i == 0)
                    {
                        sw.Write((lstVrstica[i] + min) + "\t");
                    }
                    else
                    {
                        sw.Write(lstVrstica[i] + "\t");
                    }
                }
                sw.WriteLine();
            }   
            sw.Close();
        }
    }
}