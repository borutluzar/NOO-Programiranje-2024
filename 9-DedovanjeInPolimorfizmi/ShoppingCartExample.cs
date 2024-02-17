namespace ShoppingCartExample
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ListOfArticles = new List<Article>();
        }

        public List<Article> ListOfArticles { get; set; }

        /// <summary>
        /// Izračuna skupno vsoto vseh produktov v vozičku.
        /// </summary>
        public double TotalAmount()
        {
            double result = 0;

            foreach (Article art in ListOfArticles)
            {
                result += art.PriceWithoutVAT * (1 + art.VAT);
            }
            return result;
        }

        public double VATAmount()
        {
            double result = 0;

            foreach (Article art in ListOfArticles)
            {
                result += art.PriceWithoutVAT * art.VAT;
            }
            return result;
        }
    }

    public class Article
    {
        public Article(long code, double price, string name)
        {
            Code = code;
            PriceWithoutVAT = price;
            Name = name;
        }

        public long Code { get; set; }

        public double PriceWithoutVAT { get; set; }

        public string Name { get; set; }

        public double VAT { get; set; }
    }

    public class Food : Article
    {
        public Food(long code, double price, string name) : base(code, price, name)
        {
            VAT = 0.095;
        }

        public bool ContainsAlergenes { get; set; }

        public DateTime ExpirationDate { get; set; }
    }

    public class Cosmetics : Article
    {
        public Cosmetics(long code, double price, string name) : base(code, price, name) 
        {
            VAT = 0.22;
        }
        public bool IsNatural { get; set; }

        public bool TestedOnAnimals { get; set; }
    }

    public class Publications : Article
    {
        public Publications(long code, double price, string name) : base(code, price, name) 
        {
            VAT = 0.05;
        }
        public DateTime PublishedDate { get; set; }
    }
}