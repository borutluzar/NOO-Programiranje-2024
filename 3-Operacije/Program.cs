namespace Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ***********************************************
            // Aritmetične operacije
                        
            // Poznamo pet osnovnih operatorjev
            int vsota = 3 + 4; // Rezultat: 7
            Console.WriteLine($"Operator + na številskih vrednosti deluje kot seštevanje: 3 + 4 = {vsota}");

            int razlika = 3 - 4; // Rezultat: -1    
            Console.WriteLine($"Operator - na številskih vrednosti deluje kot odštevanje: 3 - 4 = {razlika}");

            int produkt = 3 * 4; // Rezultat: 12
            Console.WriteLine($"Operator * na številskih vrednosti deluje kot množenje: 3 * 4 = {produkt}");

            int kvocient = 3 / 4; // Rezultat: 0
            Console.WriteLine($"Operator / na številskih vrednosti deluje kot deljenje: 3 / 4 = {kvocient}");

            int ostanek = 3 % 4; // Rezultat: 3
            Console.WriteLine($"Operator % na številskih vrednosti deluje kot ostanek pri deljenju: 3 % 4 = {ostanek}");


            // Pri deljenju moramo paziti, da upoštevamo,
            // da deljenje celih števil vrne celo število in
            // torej rezultat z odrezanimi decimalkami.
            // Če želimo decimalno vrednost,
            // moramo to označiti že pri podajanju vrednosti,
            // npr. takole:
            double realenKvocient = 3D / 4;
            Console.WriteLine($"Operator / na vsaj eni realni vrednosti vrne: 3 / 4 = {realenKvocient}");

            // Ko vrednost beremo iz spremenljivke,
            // pripone ne moremo uporabiti, zato prevedbo zapišemo takole:
            int deljenec = 3;
            realenKvocient = (double)deljenec / 4;
            Console.WriteLine($"Operator / na vsaj eni realni vrednosti vrne: 3 / 4 = {realenKvocient}");

            // Opozorimo še na to, da ne zadošča imeti ustrezno definirane spremenljivke
            // zgolj na levi strani, saj operacija deljenja upošteva le svoje argumente:
            realenKvocient = 3 / 4;
            Console.WriteLine($"Rezultat 3 / 4 = {realenKvocient}, čeprav je na levi spremenljivka tipa double!");


            // Pri izvedbi več zaporednih operacij je najboljši način,
            // da vrstni red njihovega izvajanja določimo s pomočjo oklepajev
            int rezultat = (3 + 4) * 7;
            Console.WriteLine($"Vrstni red določimo s pomočjo oklepajev. Rezultat v tem primeru je {rezultat}.");
            rezultat = 3 + (4 * 7);
            Console.WriteLine($"W tem primeru pa {rezultat}.");

            // Označevanje z oklepaji seveda še bolj prav pride pri kombiniranju različnih tipov vrednosti
            double izraz1 = (double)(3 / 4) * 5; // Rezultat: 0
            double izraz2 = ((double)3 / 4) * 5; // Rezultat: 3,75


            // Operator + lahko uporabimo tudi nad neštevilskimi vrednostmi,
            // npr. nad nizi
            string beseda1 = "Danes ";
            string beseda2 = "je lep dan";
            string vsotaBesed = beseda1 + beseda2;
            Console.WriteLine($"Vsota dveh besed je združitev obeh v eno: {vsotaBesed}");

            // Določanje zaporedja operacij je še posebej pomembno pri kombiniranju s stringi:
            Console.WriteLine("Danes je " + 10 + 5 + " stopinj celzija");
            Console.WriteLine("Danes je " + (10 + 5) + " stopinj celzija");


            // Poznamo še dodatne operatorje za izvajanje aritmetičnih operacij
            int stevec = 1;
            Console.WriteLine($"Trenutna vrednost spremenljivke stevec je {stevec}");
            stevec++; // Ekvivalenten ukaz kot stevec = stevec + 1;
            Console.WriteLine($"Trenutna vrednost spremenljivke stevec je {stevec}");
            stevec += 2; // Ekvivalenten ukaz kot stevec = stevec + 2;
            Console.WriteLine($"Trenutna vrednost spremenljivke stevec je {stevec}");
            stevec--; // Ekvivalenten ukaz kot stevec = stevec - 1;
            Console.WriteLine($"Trenutna vrednost spremenljivke stevec je {stevec}");
            stevec -= 2; // Ekvivalenten ukaz kot stevec = stevec - 2;
            Console.WriteLine($"Trenutna vrednost spremenljivke stevec je {stevec}");



            // ***********************************************
            // Knjižnica Math

            // Funkcija Pow za izračun potence dveh števil se skriva v knjižnici Math
            int osnova = 2;
            int eksponent = 3;
            double potenca = Math.Pow(osnova, eksponent);
            Console.WriteLine($"Potenca {osnova} na {eksponent} je {potenca}.");

            // Izračunajmo še obseg kroga z danim polmerom
            double polmer = 2;
            double obseg = 2 * Math.PI * polmer;
            Console.WriteLine($"Obseg kroga s polmerom {polmer} je {obseg}.");

            // Zgornji izpis nam izpiše precej decimalk. To lahko omejimo
            // kar s pomočjo oblikovanja interpolacijskega izpisa z nizom 0.00,
            // ki določi, da želimo natanko dve decimalni mesti
            Console.WriteLine($"Obseg kroga s polmerom {polmer} je {obseg:0.00}.");



            // ***********************************************
            // Logične operacije

            // Za logične operacije uporabljamo operatorje ! (negacija),
            // && (logični IN) in || (logični ALI)
            // Rezultat takšne operacije je vedno tipa bool (torej true ali false)
            bool sonce = true;
            bool sneg = false;
            bool logicniIN = sonce && sneg; // Rezultat: false
            bool logicniALI = sonce || sneg; // Rezultat: true
            bool negacijaSneg = !sneg; // Rezultat: true



            // ***********************************************
            // Enakosti in primerjanja

            // Primerjanja vrednosti izvajamo z operatorji <, >, <=, >=, ==
            // Tudi te operacije vračajo vrednosti tipa bool
            bool manjsi = 13 < 14; // Rezultat: true
            bool vecjiAliEnak = 13 >= 14; // Rezultat: false

            // Primerjamo lahko tudi nize
            // Dvojni enačaj uporabimo, ker je enojni že rezerviran za prirejanja
            string beseda = "Caramba!";
            bool enakiBesedi = beseda == "Caramba!"; // Rezultat: true


            Console.Read();
        }
    }
}