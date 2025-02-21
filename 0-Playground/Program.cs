using Izpit_2023_04_08;

namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            Naloga3.ResitevNaloge();

            /*
            Console.WriteLine("\nTestiranje prekoračenja vrednosti tipa sbyte!");

            sbyte @byte = 2; 
            for (sbyte i = 0; i < 10; i++)
            {
                @byte *= 2;
                Console.WriteLine($"Število {i} ima byte vrednost {@byte}");
            }
            */

            Sahovnica();
            Console.Read();
        }

        public static void Sahovnica()
        {
            int n = 8;

            string belaVrstica = "";
            string crnaVrstica = "";

            char belo = 'B';
            char crno = 'C';
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0) // Če je i sod (oz. prvi znak in potem vsak drugi)
                {
                    belaVrstica = belaVrstica + belo;
                    crnaVrstica = crnaVrstica + crno;
                }
                else
                {
                    belaVrstica = belaVrstica + crno;
                    crnaVrstica = crnaVrstica + belo;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if ((i + n) % 2 == 0)
                {
                    Console.WriteLine(belaVrstica);
                }
                else
                {
                    Console.WriteLine(crnaVrstica);
                }

                /*
                if (n % 2 == 0)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(belaVrstica);
                    }
                    else
                    {
                        Console.WriteLine(crnaVrstica);
                    }
                }
                else
                {
                    if (i % 2 == 1)
                    {
                        Console.WriteLine(belaVrstica);
                    }
                    else
                    {
                        Console.WriteLine(crnaVrstica);
                    }
                }
                */
            }
        }
    }
}