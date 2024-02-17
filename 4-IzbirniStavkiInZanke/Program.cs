using System;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.ConstrainedExecution;
using System.Reflection.Emit;

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

            // Če izbiram med dvema ukazoma glede na dani pogoj,
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
            // spremenljivki, lahko uporabimo ternarni operator.
            int temperatura = 9;
            string rezultat = temperatura < 5 ? "Vreme je normalno" : "Vreme je nenormalno";
            Console.WriteLine($"{rezultat}");



            // ***********************************************
            // Stavek switch

            // Kadar želimo ukaze razdeliti in izvesti glede na nekaj različnih možnosti,
            // namesto strukture if - else if raje uporabimo stavek switch.
            // .Pri njem v glavi podamo spremenljivko, za katero opazujemo vrednost, 
            // nato pa v stavkih case določimo, kaj se v vsakem od možnih primerov lahko zgodi.
            int danVTednu = 3;
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
                default:
                    Console.WriteLine("Danes je podaljšan vikend!");
                    break;
            }


            // Če se ob različnih vrednostih ukazi v jedru ponovijo, jih lahko združimo.
            danVTednu = 3;
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
            }
            // Pazimo le, da za logične operacije uporabimo
            // rezervirani besedi and in or namesto && in ||



            // ***********************************************
            // Zanke

            // Zanka while je najbolj preprosta.
            // Njena struktura je zelo podobna stavku if - najprej se preveri pogoj
            // in če je izpolnjen, se izvedejo še ukazi v jedru zanke.
            int i = 1;
            while (i < 4)
            {
                Console.WriteLine($"i je enako {i}!");
                i += 1;
            }


            // Naslednji tip zanke je do while
            // Ta pogoj preveri šele, ko se ukazi v jedru izvedejo.
            // Zato se vedno izvedejo vsaj enkrat!
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


            // ZGLED 1
            // Za dano velikost stranice kvadrata a želimo na zaslon izrisati kvadrat iz zvezdic.
            // Stranice kvadrata bodo zvezdice, notranjost pa bomo predstavili s presledki.
            // V prvi vrstici bomo tako izpisali $a$ zvezdic, v naslednjih bo zvezdica samo prvi in zadnji znak,
            // ostali bodo presledki, medtem ko bodo v zadnji vrstici spet samo zvezdice.
            // V vsaki vrstici bo $a$ znakov.Za njihov izris bo poskrbela posebna zanka, ki bo gnezdena v
            // zanki, katera bo skrbela za prehod v novo vrstico.
            // Primer rešene naloge je naslednji:
            int a = 5;
            for (i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    char znakec = ' ';
                    if (j == 0 || i == 0 || j == a - 1 || i == a - 1)
                        znakec = '*';
                    Console.Write(znakec);
                }
                Console.WriteLine();
            }



            // ***********************************************
            // Stavka break in continue

            // V nekaterih primerih namesto ustavitvenega pogoja zanke uporabimo poseben stavek \code{break},
            // ki zaključi izvajanje zanke takoj, ko program naleti nanj.

            // Za primer vzemimo zanko while, ki uporabnika sprašuje po rešitvi danega problema
            // in prebira njegove odgovore, dokler ne odgovori pravilno.
            // Odgovore uporabnika prebiramo z ukazom Console.ReadLine(), ki vrača vrednost tipa string.
            Console.WriteLine("Kdo je najboljši nogometaš na svetu?");
            while (true)
            {
                string odgovor = Console.ReadLine();
                if (odgovor == "Messi")
                {
                    Console.WriteLine("Odgovor je pravilen!");
                    break;
                }
                else
                    Console.WriteLine("Odgovor ni pravilen!");
            }


            // Če zanke ne želimo zaključiti popolnoma, ampak samo zaključiti izvajanje trenutnega koraka
            // in nadaljevati z naslednjim, uporabimo stavek continue.
            int stDeljivihZVsajEnim = 0;
            for (i = 1; i < 100; i++)
            {
                if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0)
                {
                    stDeljivihZVsajEnim++;
                    continue;
                }
                Console.WriteLine($"Število {i} ni deljivo z 2, 3 ali 5.");
            }
            Console.WriteLine($"Število deljivih z 2, 3 ali 5 je {stDeljivihZVsajEnim}.");

            Console.Read();
        }
    }
}