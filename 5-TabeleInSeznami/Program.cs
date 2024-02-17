using System;
using System.Reflection.Emit;

namespace ArraysAndLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Če imamo več podatkov oziroma vrednosti, jih seveda ne zapišemo vsakega v svojo spremenljivko,
            // ampak za to uporabimo spremenljivke, ki so tabele, seznami
            // ali kakšna druga primerna podatkovna struktura


            // ***********************************************
            // Tabele

            // Spremenljivko, ki predstavlja tabelo celih števil, definiramo
            // tako, da povemo tip vrednosti, ki jih sprejema in dodamo oglate oklepaje
            int[] tabela;

            // Naslednji korak je instanciranje tabele.
            // Za to imamo več možnosti, najbolj običajen pa je naslednji ukaz:
            tabela = new int[10]; // 10 določa število polj, ki jih imamo na voljo

            // Vrednost v tabeli na indeksu k določimo takole:
            int k = 7;
            tabela[k] = 13;

            // Če imamo podatke znane že v naprej, lahko tabelo inicializiramo skupaj z njimi,
            // pri čemer nam ni treba povedati njene dimenzije
            string[] dnevi = new string[] { "ponedeljek", "torek", "sreda" };

            // Za izpis vrednosti v tabeli uporabimo npr.
            // zanko foreach
            foreach (string dan in dnevi)
            {
                Console.WriteLine(dan);
            }


            // ZGLED 1
            // Pripravimo zapis stanja na varčevalnem računu v tabelo v danem številu mesecev ob dani obrestni meri in glavnici.

            // Določimo število mesecev varčevanja
            int months = 24;
            // Določimo glavnico
            decimal principalAmount = 1000;
            // Določimo obrestno mero
            decimal intRate = 0.0678M; // 6,78%

            // Definiramo tabelo za shranjevanje
            decimal[] amountsPerMonth = new decimal[months + 1]; // 24 mesecev + začetek
            amountsPerMonth[0] = principalAmount;
            for (int i = 1; i < amountsPerMonth.Length; i++)
            {
                // Vsak mesec se znesek poveča za znesek prejšnjega meseca
                // plus obresti
                amountsPerMonth[i] = amountsPerMonth[i - 1] * (1 + intRate);
            }

            int countMonth = 0;
            foreach (decimal amount in amountsPerMonth)
            {
                Console.WriteLine($"V {countMonth}. mesecu imamo na računu {amount:0.00} evrov.");
                countMonth++;
            }



            // ***********************************************
            // Večdimenzionalne tabele

            // Tabelo z dvema dimenzijama definiramo tako,
            // da pri tipu dodama dva para oglatih oklepajev
            int[][] tabela2D = new int[10][];

            // Število polj povemo le za prvo dimenzijo.
            // Vsako polje v prvi dimenziji vsebuje enodimenzionalno
            // tabelo, ki jo moramo instancirati posebej
            tabela2D[0] = new int[5];

            // Ker vsako tabelo v posameznih poljih definiramo posebej,
            // lahko imajo različne dolžine
            tabela2D[1] = new int[13];

            // Posamezne vrednosti zapišemo z določitvijo obeh koordinat
            tabela2D[0][3] = 7;
            tabela2D[1][11] = 2;


            // ZGLED
            // Oglejmo si primer izrisa mreže z danimi znaki na izbranih poljih
            // (spodnja koda med znakoma '#' in '.' izbira naključno).
            int width = 25;
            int height = 10;
            // Uporabimo objekt za slučajno generiranje števil
            Random rnd = new Random();

            // Definirajmo 2D-tabelo znakov
            char[][] mreza = new char[height][];
            for (int i = 0; i < height; i++)
            {
                // Najprej instanciramo tabelo 
                // v vsakem polju prve dimenzije
                mreza[i] = new char[width];
                for (int j = 0; j < width; j++)
                {
                    // Slučajno izberemo celo število 
                    // med 0, 1 in 2
                    int type = rnd.Next(3);
                    // Glede na rezultat zapišemo vrednost
                    switch (type)
                    {
                        case 0:
                            mreza[i][j] = '#';
                            break;
                        case >= 1:
                            mreza[i][j] = '.';
                            break;
                    }
                    Console.Write(mreza[i][j]);
                }
                Console.WriteLine();
            }

            // Dolžine tabel v posameznih poljih dobimo z lastnostjo Length
            Console.WriteLine(mreza.Length);
            Console.WriteLine(mreza[0].Length);



            // ***********************************************
            // Seznami

            // Nov seznam definiramo podobno kot tabelo - določiti moramo
            // tip vrednosti, ki jih sprejema
            List<int> seznamStevil = new List<int>(); // Pri inicializaciji ne določimo njegove velikosti

            // Podobno kot pri tabelah, lahko že ob inicializaciji naštejemo nekaj vrednosti
            List<string> lstShopping = new List<string>() { "čokolada", "bonboni" };

            // Ali pa jih naknadno dodamo z ukazom Add
            lstShopping.Add("banane");
            lstShopping.Add("burek");
            lstShopping.Add("jogurt");
            lstShopping.Add("časopis");

            // Če želimo prepisati vrednost na točno določenem indeksu,
            // to storimo enako kot pri tabelah
            lstShopping[0] = "ananas";

            // Uporabimo lahko še ukaz RemoveAt, ki vrednost z določenega
            // indeksa izbriše
            lstShopping.RemoveAt(1);

            foreach (string article in lstShopping)
            {
                Console.WriteLine(article);
                // POZOR - V zanki foreach ne moremo spreminjati tabele,
                // po kateri iteriramo niti elementa, ki vsebuje iterativne vrednosti!
                // Npr. ukaz:
                // lstShopping.RemoveAt(0);
                // javi napako ob izvajanju!
            }


            // ZGLED
            // 	Oglejmo si primer dodajanja sodih števil v seznam, pri čemer jih izbiramo
            // 	med 100 naključno izbranimi števili, kar pomeni, da v naprej ne poznamo števila polj seznama.
            rnd = new Random();
            List<int> seznamSodih = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int rndChosen = rnd.Next(1001);
                if (rndChosen % 2 == 0)
                {
                    seznamSodih.Add(rndChosen);
                }
            }

            // Še izpišemo rezultat algoritma
            Console.WriteLine($"Med izbranimi števili je "
                + "{seznamSodih.Count} sodih.");


            Console.Read();
        }
    }
}