using System.Security.Cryptography;
using System.Text;

namespace PrimerIzpita
{
    /// <summary>
    /// V tem razredu ne spreminjajte ničesar!
    /// Vaše rešitve zapisujte v datoteke z imeni NalogaX,
    /// kjer je X številka naloge.
    /// </summary>
    public class Program
    {
        enum Naloge 
        { 
            Naloga1 = 1,
            Naloga2 = 2,
            Naloga3 = 3,
            Naloga4 = 4
        }

        static void Main(string[] args)
        {
            switch(ChooseSection<Naloge>())
            {
                case Naloge.Naloga1:
                    {
                        Naloga1.ResitevNaloge();
                    }
                    break;
                case Naloge.Naloga2:
                    {
                        Naloga2.ResitevNaloge();
                    }
                    break;
                case Naloge.Naloga3:
                    {
                        Naloga3.ResitevNaloge();
                    }
                    break;
                case Naloge.Naloga4:
                    {
                        Naloga4.ResitevNaloge();
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ta izbira ni na voljo. Zapiram program...");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            MakeFooter();
        }

        private static void MakeFooter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ----  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Konec izvajanja");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ----  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static T ChooseSection<T>() where T : Enum
        {
            // Izpis sekcij za izbiro 
            int i = 1;
            Console.WriteLine("--\t--\t--\t--");
            Console.WriteLine($"{typeof(T).Name}:\n");
            foreach (var section in Enum.GetValues(typeof(T)))
            {
                var value = Convert.ChangeType(section, Type.GetTypeCode(typeof(T)));
                Console.WriteLine($"{value}. {section}");

                if ((int)value > i)
                    i = (int)value;
            }
            Console.WriteLine("\n--\t--\t--\t--");
            Console.Write($"Choose {typeof(T).Name} to run: ");

            string input = Console.ReadLine();
            bool isFormatCorrect = int.TryParse(input, out int chosen);
            if (!isFormatCorrect)
            {
                Console.WriteLine($"\n The input {input} is not an integer! The execution is stopped.");
                return default;
            }
            else if (chosen < 0 || chosen > i)
            {
                Console.WriteLine($"\n There is no Section {input}! The execution is stopped.");
                return default;
            }

            Console.Write("\n");
            Console.WriteLine($"Running {typeof(T).Name} {(T)(object)chosen}...");
            Console.Write("\n\n");

            // Pretvorba (cast) iz int nazaj v enumeracijo ni možna 
            // neposredno iz int (saj je enumeracija lahko kakega drugega
            // celoštevilskega tipa), zato chosen najprej pretvorimo v
            // object in šele nato v T.
            return (T)(object)chosen;
        }

        public static string WriteCollection<T>(ICollection<T> collection)
        {
            StringBuilder output = new StringBuilder();
            output.Append("{");
            int counter = 0;
            foreach (var item in collection)
            {
                if (counter > 0)
                    output.Append($", {item}");
                else
                    output.Append($"{item}");
                counter++;
            }
            output.Append("}");

            return output.ToString();
        }
    }
}