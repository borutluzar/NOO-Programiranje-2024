namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTestiranje prekoračenja vrednosti tipa sbyte!");

            sbyte @byte = 2; 
            for (sbyte i = 0; i < 10; i++)
            {
                @byte *= 2;
                Console.WriteLine($"Število {i} ima byte vrednost {@byte}");
            }

            Console.Read();
        }
    }
}