using System.Diagnostics;

namespace VariablesAndTypes
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Definirajmo nekaj spremenljivk različnih tipov


            // ***********************************************
            // Začnimo s spremenljivkami, ki kot
            // vrednosti sprejemajo cela števila:
            Console.WriteLine($"Izpis celoštevilskih spremenljivk: \n");

            // Najbolj običajen tip je int.            
            // Vrednost lahko zapišemo v desetiškem sistemu...
            int celoStevilo = 21;
            Console.WriteLine($"Izpis vrednosti spremenljivke celoStevilo v desetiškem sistemu: {celoStevilo}");
            // ali v dvojiškem...
            celoStevilo = 0b10101;
            Console.WriteLine($"Izpis vrednosti spremenljivke celoStevilo v dvojiškem sistemu: {celoStevilo}");
            // ali v šestnajstiškem.
            celoStevilo = 0x15;
            Console.WriteLine($"Izpis vrednosti spremenljivke celoStevilo v šestnajstiškem sistemu: {celoStevilo}");

            // Cela števila lahko definiramo tudi z drugimi tipi,
            // ki porabijo manj ali več prostora za shranjevanje, npr.
            sbyte celoSteviloSByte = 21;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa sbyte: {celoSteviloSByte}");

            short celoSteviloShort = 21;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa short: {celoSteviloShort}");

            long celoSteviloLong = 21;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa long: {celoSteviloLong}");

            // Ali pa poleg zgornjega, zavzamejo le nenegativne vrednosti:
            byte celoSteviloByte = 21;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa byte: {celoSteviloByte}");

            ushort celoSteviloUShort = 21;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa short: {celoSteviloUShort}");

            ulong celoSteviloULong = 21;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa ulong: {celoSteviloULong}");



            // ***********************************************
            // Nadaljujmo s spremenljivkami, ki kot
            // vrednosti sprejemajo realna števila:
            Console.WriteLine($"\n\nIzpis realnih spremenljivk: \n");

            // Najbolj običajen tip je double.            
            double realnoStevilo = 3.14; // Vedno uporabljamo decimalno piko
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa double: {realnoStevilo}");

            // Pri vrednosti lahko dodamo pripono D,
            // da eksplicitno povemo, da gre za tip double (ni pa nujno)
            realnoStevilo = 3.14D;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa double s pripono D: {realnoStevilo}");

            // Imamo še dva druga tipa, vsakemu moramo pri vrednosti pripisati
            // ustrezno pripono.
            float realnoSteviloFloat = 3.14F; // Uporabimo pripono F
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa float: {realnoSteviloFloat}");

            decimal realnoSteviloDecimal = 3.14M; // Uporabimo pripono M
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa decimal: {realnoSteviloDecimal}");



            // ***********************************************
            // Tip, ki sprejema le dve logični vrednosti true in false, je bool
            Console.WriteLine($"\n\nIzpis logične spremenljivke: \n");

            bool logicnaVrednost = true;
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa bool: {logicnaVrednost}");



            // ***********************************************
            // Tip, ki sprejema znake, je char
            Console.WriteLine($"\n\nIzpis spremenljivke, ki sprejema znake: \n");

            char znak = 'A'; // Vrednost je lahko samo en znak, pisati ga moramo v enojnih narekovajih
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa char: {znak}");



            // ***********************************************
            // Tip, ki sprejema besedila, je string
            Console.WriteLine($"\n\nIzpis spremenljivk z besedilom: \n");

            string besedilo = "Danes je lep dan!"; // Vrednost moramo pisati v dvojnih narekovajih
            Console.WriteLine($"Izpis vrednosti spremenljivke tipa string: {besedilo}");

            // Uporabljamo lahko tudi posebne znake (ubežna zaporedja)
            // Npr. znak za novo vrstico zapišemo z \n
            string naslov = "Ime in priimek\nUlica in hišna številka\nPošta";
            Console.WriteLine($"Izpis vrednosti spremenljivke z ubežnimi zaporedji:\n{naslov}");



            // ***********************************************
            // Spremenljivkam namesto eksplicitnih vrednosti lahko
            // priredimo kar vrednost, ki je shranjena v neki drugi spremenljivki.
            // Na primer:
            besedilo = naslov;
            Console.WriteLine($"Spremenljivka {nameof(besedilo)} ima novo vrednost:\n{besedilo}");

            Console.Read();
        }
    }
}