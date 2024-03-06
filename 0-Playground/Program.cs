namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("\nTestiranje prekoračenja vrednosti tipa sbyte!");

            sbyte @byte = 2; 
            for (sbyte i = 0; i < 10; i++)
            {
                @byte *= 2;
                Console.WriteLine($"Število {i} ima byte vrednost {@byte}");
            }
            */

            Queue<int> vrsta = new Queue<int>();
            vrsta.Enqueue(5);
            vrsta.Enqueue(3);
            vrsta.Enqueue(8);
            vrsta.Enqueue(2);
            vrsta.Enqueue(4);

            int rezultat = AlgoritemIzpit2022(vrsta, 4, 3);
            Console.WriteLine($"{rezultat}");

            Console.Read();
        }

        static int AlgoritemIzpit2022(Queue<int> vrsta, int a, int b)
        {
            bool vsebujeA = false;
            bool vsebujeB = false;
            int dolzinaVrste = vrsta.Count;

            int i = 0;
            // Preverimo, če vrsta vsebuje elementa a in b
            int maxVVrsti = -1;
            int minVVrsti = -1;
            while (i < dolzinaVrste)
            {
                int e = vrsta.Dequeue();
                if (e == a)
                {
                    vsebujeA = true;
                }
                if (e == b)
                {
                    vsebujeB = true;
                }

                // Poiščemo največji element v vrsti
                if (e > maxVVrsti)
                {
                    maxVVrsti = e;
                }
                if (minVVrsti == -1 || e < minVVrsti)
                {
                    minVVrsti = e;
                }

                vrsta.Enqueue(e);
                i++;
            }

            int maxAB = a > b ? a : b;
            if (vsebujeA == false && vsebujeB == false)
            {
                vrsta.Enqueue(maxAB);
                i = 0;
                while (i < dolzinaVrste)
                {
                    int e = vrsta.Dequeue();
                    vrsta.Enqueue(e);
                    i++;
                }

                return maxAB > maxVVrsti ? maxAB : maxVVrsti;
            }
            else if (vsebujeA && vsebujeB)
            {
                return maxVVrsti;
            }
            else
            {
                return minVVrsti;
            }
        }
    }
}