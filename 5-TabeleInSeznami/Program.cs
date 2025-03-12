using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

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
            int indeks = 7;
            tabela[indeks] = 13;

            // Če imamo podatke znane že v naprej, lahko tabelo inicializiramo skupaj z njimi,
            // pri čemer nam ni treba povedati njene dimenzije
            string[] dnevi = new string[] { "ponedeljek", "torek", "sreda" };

            // Za izpis vrednosti v tabeli uporabimo npr.
            // zanko foreach            
            foreach (string dan in dnevi)
            {
                Console.WriteLine(dan);
            }
            // ali z zanko for
            for (int d = 0; d < dnevi.Length; d++)
            {
                Console.WriteLine(dnevi[d]);
            }
            // ali z zanko while - doma!



            // ZGLED 1
            // Pripravimo zapis stanja na varčevalnem računu v tabelo
            // v danem številu mesecev ob dani obrestni meri in glavnici.

            // Določimo število mesecev varčevanja
            int months = 24;
            // Določimo glavnico
            decimal principalAmount = 1000M;
            // Določimo obrestno mero
            decimal intRate = 0.0678M; // 6,78%

            // Definiramo tabelo za shranjevanje
            decimal[] amountsPerMonth = new decimal[months + 1]; // 24 mesecev + začetek
            amountsPerMonth[0] = principalAmount;
            for (int i = 1; i < amountsPerMonth.Length; i++) // Dolžino tabele pridobimo z lastnostjo Length
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

            // Še enkrat izpišimo zadnjo vrednost za vajo:
            Console.WriteLine($"V zadnjem mesecu imamo na računu " +
                $"{amountsPerMonth[amountsPerMonth.Length - 1]:0.00} evrov.");



            // ***********************************************
            // Večdimenzionalne tabele

            // Tabelo z dvema dimenzijama definiramo tako,
            // da pri tipu dodama dva para oglatih oklepajev
            int[][] tabela2D = new int[10][];

            // Podobno definiramo tabelo s 3 dimenzijami itd.
            int[][][] tabela3D = new int[10][][];


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
            Console.WriteLine("\n\n\n");
            // Oglejmo si primer izrisa mreže z danimi znaki na izbranih poljih
            // (spodnja koda med znakoma '#' in '.' izbira naključno).
            int width = 8;
            int height = 8;
            // Uporabimo objekt za slučajno generiranje števil
            Random rnd = new Random();

            // Definirajmo 2D-tabelo znakov
            char[][] mreza = new char[height][];
            int countHash = 0;
            for (int i = 0; i < height; i++)
            {
                // Najprej instanciramo tabelo 
                // v vsakem polju prve dimenzije
                mreza[i] = new char[width];
                for (int j = 0; j < width; j++)
                {
                    // Slučajno izberemo celo število 
                    // med 0, 1 in 2
                    int type = rnd.Next(5);

                    // Glede na rezultat zapišemo vrednost
                    switch (type)
                    {
                        case 0:
                            mreza[i][j] = '#';
                            countHash++;
                            break;
                        case >= 1:
                            mreza[i][j] = '.';
                            break;
                    }
                    Console.Write(mreza[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Lojtr imamo {countHash}, pik pa {width * height - countHash}");

            // Dolžine tabel v posameznih poljih dobimo z lastnostjo Length
            Console.WriteLine(mreza.Length);
            Console.WriteLine(mreza[0].Length);


            // Preverimo razred Random pri metu kocke
            int[] tblSestevki = new int[6];
            int stevec = 10_000_000;

            for (int i = 0; i < stevec; i++)
            {
                int met = rnd.Next(1, 7); // Vržemo kocko
                tblSestevki[met - 1] = tblSestevki[met - 1] + 1; // Povečamo seštevek na ustreznem polju
            }

            Console.WriteLine($"\nŠtevilo seštevkov po posameznih vrednostih: \n");
            int stPik = 1;
            foreach (int vrednost in tblSestevki)
            {
                Console.WriteLine($"Število metov {stPik} je {vrednost} " +
                    $"(relativni delež je {(double)vrednost / stevec:0.####})");
                stPik++;
            }


            // ***********************************************
            // Seznami

            // Nov seznam definiramo podobno kot tabelo - določiti moramo
            // tip vrednosti, ki jih sprejema
            List<int> seznamStevil = new List<int>(); // Pri inicializaciji ne določimo njegove velikosti

            // Podobno kot pri tabelah, lahko že ob inicializaciji naštejemo nekaj vrednosti
            List<string> seznamNakupovalni = new List<string>() { "čokolada", "bonboni", "pralni prašek" };

            Console.WriteLine($"Število elementov v seznamu je {seznamNakupovalni.Count}");

            // Ali pa jih naknadno dodamo z ukazom Add
            seznamNakupovalni.Add("banane");
            seznamNakupovalni.Add("burek");
            seznamNakupovalni.Add("jogurt");
            seznamNakupovalni.Add("časopis");

            // Če želimo prepisati vrednost na točno določenem indeksu,
            // to storimo enako kot pri tabelah
            seznamNakupovalni[0] = "ananas";
            seznamNakupovalni[3] = "avokado";

            seznamNakupovalni.Insert(0, "čokolada");

            // Uporabimo lahko še ukaz RemoveAt, ki vrednost z določenega
            // indeksa izbriše
            seznamNakupovalni.RemoveAt(1);

            // Če želimo izbrisati točno določen element,
            // to storimo z ukazom Remove
            seznamNakupovalni.Remove("avokado");

            foreach (string article in seznamNakupovalni)
            {
                Console.WriteLine(article);
                // POZOR - V zanki foreach ne moremo spreminjati tabele,
                // po kateri iteriramo niti elementa, ki vsebuje iterativne vrednosti!
                // Npr. ukaz:
                //seznamNakupovalni.RemoveAt(0);
                // javi napako ob izvajanju!
            }

            // Odstranjevanje elementa lahko naredimo
            // s pomočjo zanke for
            for (int i = 0; seznamNakupovalni.Count > 0; /* Ta stavek izpustimo, ker ga ne rabimo */)
            {
                Console.WriteLine(seznamNakupovalni[i]);
                seznamNakupovalni.RemoveAt(i);
            }
            Console.WriteLine($"V našem seznamu je {seznamNakupovalni.Count} elementov.");

            // Primer 2: enako kot zgoraj, vendar z izpisovanjem
            // od zadnjega k prvemu elementu
            seznamNakupovalni.Add("brokoli");
            seznamNakupovalni.Add("zelena");
            seznamNakupovalni.Add("riž");
            seznamNakupovalni.Add("koleraba");

            for (int i = seznamNakupovalni.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(seznamNakupovalni[i]);
                seznamNakupovalni.RemoveAt(i);
            }
            Console.WriteLine($"V našem seznamu je {seznamNakupovalni.Count} elementov.");


            // ZGLED
            // 	Oglejmo si primer dodajanja sodih števil v seznam, pri čemer jih izbiramo
            // 	med  n  naključno izbranimi števili, kar pomeni, da v naprej ne poznamo
            // 	števila polj seznama.
            rnd = new Random();
            int n = 100_000;

            List<int> lstSeznamSodih = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int val = rnd.Next(n);
                if (val % 2 == 0)
                {
                    lstSeznamSodih.Add(val);
                }
            }

            // Še izpišemo rezultat algoritma
            Console.WriteLine($"Med izbranimi števili je "
                + $"{lstSeznamSodih.Count} sodih.");


            Console.Read();
        }
    }
}