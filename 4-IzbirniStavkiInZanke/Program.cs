﻿using System.Runtime.InteropServices;

namespace SelectStatementsAndLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ***********************************************
            // Stavek if

            // Ko želimo nek ukaz izvesti samo, če je izpolnjen dan pogoj,
            // uporabimo stavek if
            int x = 3;
            if (x > 4)
            {
                Console.WriteLine("Tole se ne bo izpisalo!");
            }

            x = 5;
            if (x > 4)
            {
                Console.WriteLine("Zdaj se pa bo!");
            }

            // Če izbiramo med dvema ukazoma glede na dani pogoj,
            // stavku if dodamo še else
            x = 3;
            if (x > 4)
            {
                Console.WriteLine("Tole se ne bo izpisalo!");
            }
            else
            {
                Console.WriteLine("Tole se pa bo!");
            }


            // Za izbiro ene med več različnimi možnostmi
            // dodamo še stavek else-if
            // Izvedel se bo samo PRVI stavek, ki ima pravilen pogoj
            int test = 6;
            if (test < 6) // false
            {
                Console.WriteLine($"{test} je manjše kot 6");
            }
            else if (test == 6) // true - se izvede
            {
                Console.WriteLine($"{test} je enako kot 6");
            }
            else if (test > 5) // true - se ne izvede
            {
                Console.WriteLine($"{test} je večje kot 5");
            }
            else // false
            {
                Console.WriteLine($"{test} ni nič od zgornjega");
            }


            // Če želimo izvedbo vseh ukazov, pri katerih je pogoj pravilen,
            // moramo uporabiti zaporedne stavke if
            if (test < 6) // false
            {
                Console.WriteLine($"{test} je manjše kot 6");
            }

            if (test == 6) // true - se izvede
            {
                Console.WriteLine($"{test} je enako kot 6");
            }

            if (test > 5) // true - se izvede
            {
                Console.WriteLine($"{test} je večje kot 5");
            }


            // Kadar v stavku if - else zgolj prirejamo vrednost neki 
            // spremenljivki, lahko uporabimo trojiški (ternarni) operator.
            // Sintaksa: POGOJ  ?  vrednost, če pogoj TRUE    :    vrednost, če pogoj FALSE 
            int temperatura = 10;
            string rezultat = temperatura < 15 ? "Vreme je normalno" : "Vreme je nenormalno";
            Console.WriteLine($"{rezultat}");


            // Zgled: zapišimo zgornjo kodo z običajnim stavkom IF
            rezultat = "";
            if (temperatura < 15)
            {
                rezultat = "Vreme je normalno";
            }
            else
            {
                rezultat = "Vreme je nenormalno";
            }
            Console.WriteLine($"Izpis: {rezultat}");


            Console.Write($"Vnesite temperaturo: ");
            int temp = int.Parse(Console.ReadLine());
            bool sneg = true;
            bool pocitnice = true;

            // (a) Če so počitnice in je sneg in manj kot 5 stopinj => gremo smučat
            // (b) Če niso počitnice in je sneg in manj kot 5 stopinj => učimo se doma
            // (c) Če so počitnice in ni snega in je manj kot 5 stopinj => igramo karte
            // (d) Če so počitnice in je sneg in je več kot 15 stopinj => čakamo, da se sneg stopi

            bool moznostA = pocitnice == true && sneg == true && temp < 5;
            if (moznostA)
            {
                Console.WriteLine("Gremo smučat.");
            }
            // ...


            if (temp < 5) // (a), (b), (c)
            {
                if (pocitnice == true && sneg == true) // (a)
                {
                    Console.WriteLine("Gremo smučat.");
                }
                else if (!pocitnice && sneg == true) // (b)
                {
                    Console.WriteLine("Učimo se doma.");
                }
                else if (pocitnice && sneg == false) // (c)
                {
                    Console.WriteLine("Igramo karte.");
                }
            }
            else // (d)
            {
                if (temp > 15 && pocitnice == true && sneg == true)
                {
                    Console.WriteLine("Čakamo, da se sneg stopi.");
                }
            }


            // ***********************************************
            // Stavek switch

            // Kadar želimo ukaze razdeliti in izvesti glede na nekaj različnih možnosti,
            // namesto strukture if - else if raje uporabimo stavek switch.
            // .Pri njem v glavi podamo spremenljivko, za katero opazujemo vrednost, 
            // nato pa v stavkih case določimo, kaj se v vsakem od možnih primerov lahko zgodi.
            int danVTednu = 5;
            switch (danVTednu)
            {
                case 1: // V primeru, da je vrednost danVTednu enaka 1
                    Console.WriteLine("Danes je ponedeljek!");
                    Console.WriteLine("Garfield ga ne mara!");
                    break;
                case 2:
                    Console.WriteLine("Danes je torek!");
                    break;
                case 3:
                    Console.WriteLine("Danes je sreda!");
                    break;
                default:
                    Console.WriteLine("Danes je podaljšan vikend!");
                    break;
            }


            // Če se ob različnih vrednostih ukazi v jedru ponovijo, jih lahko združimo.
            danVTednu = 8;
            switch (danVTednu)
            {
                case 1:
                    Console.WriteLine("Danes je ponedeljek!");
                    break;
                case 2:
                    Console.WriteLine("Danes je torek!");
                    break;
                case 3:
                    Console.WriteLine("Danes je sreda!");
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    Console.WriteLine("Danes je podaljšan vikend!");
                    break;
            }


            // Če je možnosti za naštevanje vrednosti (pre)več
            // in imajo nekatere enake ukaze, jih lahko združimo kar
            // s primerjalnimi operacijami
            danVTednu = 8;
            switch (danVTednu)
            {
                case 1:
                    Console.WriteLine("Danes je ponedeljek!");
                    break;
                case 2:
                    Console.WriteLine("Danes je torek!");
                    break;
                case 3:
                    Console.WriteLine("Danes je sreda!");
                    break;
                case >= 4 and < 8:
                    Console.WriteLine("Danes je podaljšan vikend!");
                    break;
                case > 7 or < 1:
                    Console.WriteLine("Takega dneva pa v tednu ni!");
                    break;
            }
            // Pazimo le, da za logične operacije uporabimo
            // rezervirani besedi and in or namesto && in ||

            char testniZnak = 'A';
            switch (testniZnak)
            {
                case 'b':
                    Console.WriteLine($"Znakec je {testniZnak}");
                    break;
                case 'c':
                    Console.WriteLine($"Znakec je {testniZnak}");
                    break;
                case 'A':
                    Console.WriteLine($"Znakec je {testniZnak}");
                    break;
            }


            // ***********************************************
            // Zanke

            // Zanka while je najbolj preprosta.
            // Njena struktura je zelo podobna stavku if - najprej se preveri pogoj
            // in če je izpolnjen, se izvedejo še ukazi v jedru zanke.
            Console.WriteLine("\nZanka WHILE\n");
            int i = 1;
            while (i < 4)
            {
                Console.WriteLine($"{nameof(i)} je enako {i}!");
                i += 1; // i = i + 1;
            }


            // Naslednji tip zanke je do while
            // Ta pogoj preveri šele, ko se ukazi v jedru izvedejo.
            // Zato se vedno izvedejo vsaj enkrat!

            Console.WriteLine("\nZanka DO-WHILE\n");
            i = 4;
            do
            {
                Console.WriteLine($"i je enako {i}!");
                i += 1;
            }
            while (i < 4);


            // Za iteriranje po znanem intervalu vrednosti uporabljamo zanko for.
            // Tej v glavi poleg pogoja povemo še začetno vrednost
            // spremenljivke, ki jo uporabljamo za iterator
            // (običajno to spremenljivko v glavi zanke tudi definiramo),
            // ter korak oziroma spremembo vrednosti spremenljivke ob vsakem  prehodu zanke.
            for (int k = 0; k < 4; k++)
            {
                Console.WriteLine($"k je enako {k}!");
            }


            // Zadnja in verjetno najbolj pogosto uporabljena je zanka foreach.
            // To uporabimo, kadar želimo iterirati neposredno po objektih dane zbirke
            // (tabele, seznama itd.).
            // V glavi tako definiramo spremenljivko, v katero se v vsakem koraku zanke
            // shrani naslednja vrednost iz zbirke.
            List<string> besede = new List<string>() { "jutri", "bom", "doma" };
            foreach (string beseda in besede)
            {
                Console.WriteLine($"Beseda je {beseda}!");
            }

            // Ekvivalent z zanko for bi bil (ampak sintakse za tabele in sezname še ne poznamo):
            for (i = 0; i < besede.Count; i++)
            {
                Console.WriteLine($"Beseda je {besede[i]}!");
            }


            // ZGLED 1
            // Za dano velikost stranice kvadrata  a  želimo na zaslon izrisati kvadrat iz zvezdic.
            // Stranice kvadrata bodo zvezdice, notranjost pa bomo predstavili s presledki.
            // V prvi vrstici bomo tako izpisali a zvezdic, v naslednjih bo zvezdica samo prvi in zadnji znak,
            // ostali bodo presledki, medtem ko bodo v zadnji vrstici spet samo zvezdice.
            // V vsaki vrstici bo $a$ znakov.Za njihov izris bo poskrbela posebna zanka, ki bo gnezdena v
            // zanki, katera bo skrbela za prehod v novo vrstico.
            // Primer rešene naloge je naslednji:
            int a = 10;

            for (int vrstica = 0; vrstica < a; vrstica++) // Zanka, ki ob vsakem prehodu ustvari vrstico 
            {
                for (int stolpec = 0; stolpec < a; stolpec++) // // Zanka, ki ob vsakem prehodu zapiše en znak
                {
                    // Preverimo, če smo v prvem stolpcu ali prvi vrstici
                    // ali zadnjem stolpcu ali zadnji vrstici
                    // - v tem primeru napišemo zvezdico
                    if (stolpec == 0 || vrstica == 0 || stolpec == a - 1 || vrstica == a - 1)
                    {
                        Console.Write('*'); // Uporabimo ukaz Write, da ne skočimo v novo vrstico!
                    }
                    else
                    {
                        Console.Write(' '); // Uporabimo ukaz Write, da ne skočimo v novo vrstico!
                    }
                }
                Console.WriteLine(); // Ko končamo zapis ene vrstice, gremo v novo
            }


            // ZGLED 2
            // Za dano velikost šahovnice a želimo na zaslon izrisati 
            // šahovnico, kjer so bela polja označena z O, črna pa z X.
            // Spodnje levo polje naj bo črno!
            // Primer rešene naloge je naslednji:
            a = 8;
            for (i = 0; i < a; i++) // Zanka, ki ob vsakem prehodu ustvari vrstico 
            {
                for (int j = 0; j < a; j++) // // Zanka, ki ob vsakem prehodu zapiše en znak
                {
                    char znakec = a % 2 == 0 ? 'X' : 'O';
                    if (i % 2 == 1 && j % 2 == 1 || i % 2 == 0 && j % 2 == 0)
                    {
                        znakec = a % 2 == 0 ? 'O' : 'X';
                    }
                    Console.Write(znakec); // Uporabimo ukaz Write, da ne skočimo v novo vrstico!
                }
                Console.WriteLine(); // Ko končamo zapis ene vrstice, gremo v novo
            }



            // ***********************************************
            // Stavka break in continue

            // V nekaterih primerih namesto ustavitvenega pogoja zanke uporabimo poseben stavek \code{break},
            // ki zaključi izvajanje zanke takoj, ko program naleti nanj.

            // Za primer vzemimo zanko while, ki uporabnika sprašuje po rešitvi danega problema
            // in prebira njegove odgovore, dokler ne odgovori pravilno.
            // Odgovore uporabnika prebiramo z ukazom Console.ReadLine(), ki vrača vrednost tipa string.            
            while (true)
            {
                Console.Write("Kdo je najboljši nogometaš na svetu? ");
                string odgovor = Console.ReadLine();
                if (odgovor == "Messi")
                {
                    Console.WriteLine("Odgovor je pravilen!");
                    break; // Prekinemo izvajanje zanke
                }
                else
                {
                    Console.WriteLine("Odgovor ni pravilen!");
                }
            }

            // To isto sicer lahko implementiramo tudi brez stavka break:
            bool nadaljuj = true;
            while (nadaljuj /* Na začetku je true */)
            {
                Console.Write("Kdo je najboljši nogometaš na svetu?");
                string odgovor = Console.ReadLine();
                if (odgovor == "Messi")
                {
                    Console.WriteLine("Odgovor je pravilen!");
                    nadaljuj = false; // Nadomestimo break
                }
                else
                {
                    Console.WriteLine("Odgovor ni pravilen!");
                }
            }
            // V zgornjem primeru ni velike razlike od uporabe break,
            // lahko pa nastane, če imamo v zanki bolj kompleksno kodo
            // oziroma več ukazov, pri katerih moramo preverjati,
            // če želimo zanko prekiniti...


            // Če zanke ne želimo zaključiti popolnoma, ampak samo zaključiti izvajanje trenutnega koraka
            // in nadaljevati z naslednjim, uporabimo stavek continue.
            int stDeljivihZVsajEnim = 0;
            for (int ii = 1; ii < 100; ii++)
            {
                if (ii % 2 == 0 || ii % 3 == 0 || ii % 5 == 0)
                {
                    stDeljivihZVsajEnim++;
                    continue;
                }
                Console.WriteLine($"Število {ii} ni deljivo z 2, 3 ali 5.");
            }
            Console.WriteLine($"Število deljivih z 2, 3 ali 5 je {stDeljivihZVsajEnim}.");


            // Zgled 3: Izpišimo prvih n členov Fibonacijevega zaporedja
            // f[n+2] = f[n+1] + f[n]
            // f[0] = 1, f[1] = 1
            // 1, 1, 2, 3, 5, 8, 13, 21, 34...
            Console.WriteLine($"\nIzpis členov Fibonacijevega zaporedja:\n");
            int n = 50;

            long prva = 1;
            Console.WriteLine($"1. člen: {prva}");
            long druga = 1;
            Console.WriteLine($"2. člen: {druga}");
            long tekoca = druga + prva;
            Console.WriteLine($"3. člen: {tekoca}");

            for (i = 4; i <= n; i++)
            {
                // Ideja: f[4] = f[3] + f[2] (f[1] ne potrebujemo več...)
                prva = druga;
                druga = tekoca;
                tekoca = druga + prva;
                Console.WriteLine($"{i}. člen: {tekoca}");
            }

            Console.Read();
        }
    }
}