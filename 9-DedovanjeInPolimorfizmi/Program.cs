using ShoppingCartExample;
using System.Net;
using System.Numerics;

namespace DedovanjeInPolimorfizmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Naredimo instanco razreda Object
            // Vsi razredi v C# dedujejo od razreda Object
            Object obj = new Object();
            obj.ToString();

            
            // Naredimo instanci razredov Bicycle in EBike
            Bicycle kolo = new Bicycle(); // Bicycle deduje od Object
            kolo.FrameSize = 21;
            Console.WriteLine($"Opis kolesa {nameof(kolo)}: {kolo.ToString()}");

            Bicycle kolo2 = new Bicycle();
            kolo2.FrameSize = 17;
            Console.WriteLine($"Opis kolesa {nameof(kolo2)}: {kolo2.ToString()}");

            EBike eKolo = new EBike(); // EBike deduje od Bicycle
            eKolo.FrameSize = 18;
            eKolo.BateryTime = 4;
            eKolo.ChangeGear(3);
            Console.WriteLine($"Opis kolesa {nameof(eKolo)}: {eKolo.ToString()}");

            MountainBike gorsko = new MountainBike(15); // EBike deduje od Bicycle


            // Konstruktorji podrazredov
            Coffee kava = new Coffee(3);
            Turkish turska = new Turkish(0, 5);


            // Polimorfizmi
            Circle krog1 = new Circle(1, 3.4);
            Circle krog2 = new Circle(2, 1);
            Circle krog3 = new Circle(3, 2);

            Rectangle pravokotnik1 = new Rectangle(4, 2, 6);
            Rectangle pravokotnik2 = new Rectangle(5, 3, 5.7);

            // Domača naloga: dopolnite strukturo razredov še s tremi podrazredi
            // (kvadrat, trikotnik, šestkotnik)

            List<Shape> lstShapes = new List<Shape>()
            {
                krog1,
                krog2,
                krog3,
                pravokotnik1,
                pravokotnik2
            };

            foreach (Shape shp in lstShapes)
            {
                Console.WriteLine($"Obseg lika {shp.ID} je {shp.Perimeter():0.00}");

                // Če želimo preveriti, ali imamo opravka s posebnim tipom,
                // to preverimo z rezervirano besedo is
                if (shp is Circle)
                {
                    double area = ((Circle)shp).Area();
                    Console.WriteLine($"Ploščina lika {shp.ID} je {area:0.00}");
                }
            }


            // Zgled:
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

        /// <summary>
        /// Metodo ToString dedujemo iz razreda Object
        /// </summary>        
        public override string ToString()
        {
            string rezultat = $"Velikost okvirja: {this.FrameSize}\n" +
                    $"Število prestav: {this.NumGears}\n" +
                    $"Znamka: {this.Brand}";

            return rezultat;
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
            string rezultat = base.ToString() + "\n" +
                    $"Čas vzdržljivosti baterije: {BateryTime}";

            return rezultat;
        }

        // Rahlo popravimo metodo iz nadrazreda
        public override void ChangeGear(int increaseBy)
        {
            //this.CurrentGear += increaseBy;
            // ali
            base.ChangeGear(increaseBy);
            
            if(increaseBy > 0)
                Console.WriteLine("Zvišanje prestave lahko zmanjša vzdržljivost baterije!");
        }
    }

    public class MountainBike : Bicycle
    {
        public double TireWidth { get; set; }

        public MountainBike(double tireWidth)
        {
            TireWidth = tireWidth;
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