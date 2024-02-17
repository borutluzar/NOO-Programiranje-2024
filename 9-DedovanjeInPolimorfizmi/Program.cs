using ShoppingCartExample;
using System.Numerics;

namespace DedovanjeInPolimorfizmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> lstShapes = new List<Shape>()
            {
                new Circle(1, 3.4),
                new Circle(2, 1),
                new Circle(3, 2),
                new Rectangle(4, 2, 6),
                new Rectangle(5, 3, 5.7)
            };

            foreach (Shape shp in lstShapes)
            {
                Console.WriteLine($"Obseg lika {shp.ID} je {shp.Perimeter()}");

                // Če želimo preveriti, ali imamo opravka s posebnim tipom,
                // to preverimo z rezervirano besedo is
                if (shp is Circle)
                {
                    double area = ((Circle)shp).Area();
                }

            }


            // Primer ShoppingCart           

            ShoppingCart myCart = new ShoppingCart();
            myCart.ListOfArticles.Add(new Food(230142123202, 9.83, "Goveji biftek"));
            myCart.ListOfArticles.Add(new Cosmetics(232011, 19.00, "Šampon"));
            myCart.ListOfArticles.Add(new Publications(144352544, 2.40, "Delo"));
            myCart.ListOfArticles.Add(new Food(2324352544, 4.41, "Peresniki"));

            Console.WriteLine($"Skupna cena mojega vozička je {myCart.TotalAmount()}€, " +
                $"od tega sem plačal {myCart.VATAmount():0.00} davka.");


            ShoppingCart sosedovCart = new ShoppingCart();
            sosedovCart.ListOfArticles.Add(new Food(12424, 20.64, "Belgijski vaflji"));

            Console.WriteLine($"Skupna cena mojega vozička je {sosedovCart.TotalAmount()}€, " +
                $"od tega sem plačal {sosedovCart.VATAmount():0.00} davka.");

            Console.Read();
        }
    }

    public class Bicycle
    {
        public int FrameSize { get; set; }

        public int NumGears { get; set; }

        public string Brand { get; set; }

        public int CurrentGear { get; set; }

        public override string ToString()
        {
            return $"Velikost okvirja: {FrameSize}\n" +
                    $"Število prestav: {NumGears}\n" +
                    $"Znamka: {Brand}";
        }

        public virtual void ChangeGear(int increaseBy)
        {
            this.CurrentGear += increaseBy;
        }
    }

    // Nadrazred označimo za dvopičjem
    public class EBike : Bicycle
    {
        public double BateryTime { get; set; }

        public override string ToString()
        {
            // Z rezervirano besedo base povemo, da se sklicujemo na nadrazred.
            return base.ToString() +
                    $"Čas vzdržljivosti baterije: {BateryTime}";
        }

        // Rahlo popravimo metodo iz nadrazreda
        public override void ChangeGear(int increaseBy)
        {
            this.CurrentGear += increaseBy;
            Console.WriteLine("Zvišanje prestave lahko zmanjša vzdržljivost baterije!");
        }
    }

    public class Coffee
    {
        public Coffee(double quantity)
        {
            Quantity = quantity;
        }

        public double Quantity { get; set; }
    }

    // Nadrazred označimo za dvopičjem
    public class Turkish : Coffee
    {
        // Ob klicu konstruktorja moramo poskrbeti še za
        // parametre konstruktorja v nadrazredu
        public Turkish(double quantity, int preparationTime) : base(quantity)
        {
            PreparationTime = preparationTime;
        }

        public int PreparationTime { get; set; }
    }



    public class Shape
    {
        public Shape(int id)
        {
            ID = id;
        }

        public int ID { get; set; }

        /// <summary>
        ///  Pripravimo si metodo za izračun obsega, ki jo bomo v podrazredih povozili.
        /// </summary>
        public virtual double Perimeter()
        {
            return 0;
        }
    }

    public class Circle : Shape
    {
        public Circle(int id, double radius) : base(id)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public override double Perimeter()
        {
            return 2 * Radius * Math.PI;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(int id, double a, double b) : base(id)
        {
            A = a;
            B = b;
        }

        public double A { get; set; }

        public double B { get; set; }

        public override double Perimeter()
        {
            return 2 * A + 2 * B;
        }
    }
}