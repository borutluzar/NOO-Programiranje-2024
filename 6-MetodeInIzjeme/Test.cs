using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods.MySuperApplicableMethods
{
    public class MojeMetode
    {
        /// <summary>
        /// Moj opis.
        /// </summary>
        public static void MojaMetoda()
        {
            Console.WriteLine($"Moja super nova metoda.");
        }
    }

    public class DrugRazred
    {
        public static void MojaMetoda()
        {
            Console.WriteLine($"Moja super druga nova metoda.");
        }
    }
}
namespace Methods.MySuperApplicableMethods2
{
    public class DrugRazred
    {
        public static void MojaMetoda()
        {
            Console.WriteLine($"Nekaj čisto drugega!");
        }
    }
}
