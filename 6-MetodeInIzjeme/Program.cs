using System;

namespace Methods
{
    internal class Program
    {
        /*
         * Ko pišemo programe, jih vedno poskušamo razdeliti na majhne, čim bolj neodvisne sklope kode. 
         * Na ta način se izognemo podvojenemu pisanju kode, 
         * saj delček kode, ki je nekje že napisan, le ``pokličemo'' in izvedemo na ustreznih mestih, 
         * namesto da bi vse ukaze napisali znova.
         * Zapisovanje posameznih delčkov kode nam omogočajo metode.
         */

        static void Main(string[] args)
        {
            // V tem projektu bomo v metodi Main druge metode samo klicali,
            // zapisovali pa jih bomo izven nje, kot samostojne delčke kode

            // Izvedimo metodo Kvocient in izpišimo njen rezultat
            int a = 7;
            int b = 13;
            double result = Kvocient(a, b);
            Console.WriteLine($"Rezultat metode {nameof(Kvocient)} za parametra {a} in {b} je {result:0.0000}");

            double aa = 9.0;
            double result2 = Kvocient(aa, b);


            // Pokličemo metodo SumThree
            int sum = SumThree(1, 10, 100);
            Console.WriteLine($"Naš rezultat je {sum}");

            // Zgled: Metoda za izračun indeksa telesne mase
            /*
            Console.Write("Vpišite svojo telesno maso (v kg): ");
            double mass = double.Parse(Console.ReadLine());
            Console.Write("Vpišite svojo telesno višino (v m): ");
            double height = double.Parse(Console.ReadLine());

            double bmi = BodyMassIndex(mass,height);
            Console.WriteLine($"Indeks naše telesne mase je: {bmi:0.00}");

            // Klic metode Quotient
            double quotient = Quotient(12, 13);
            Console.WriteLine($"Rezultat deljenja je {quotient:0.000}");
            */


            // Zgled: Metoda, ki dobi podatke o študentih,
            // ki so pisali izpit in njihovo število točk,
            // izračuna pa povprečno oceno vseh.
            /*
            double rezultat = PovprecnaOcena();
            Console.WriteLine($"Povprečna ocena izpita je bila {rezultat:0.00}");
            */

            // Zgled - Naloga 1 iz drugega izpita 2023
            /*
            Izpit2023_Naloga1();
            */

            // Primer klica metode iz novega (razred MojeMetode) razreda
            Methods.MySuperApplicableMethods.MojeMetode.MojaMetoda();


            // Izjeme
            /*
            Console.Write($"Vpišite vaše število: ");            
            int mojeStevilo = int.Parse(Console.ReadLine());
            */

            //string oprt2 = GetOperator(5);

            // Pokličimo metodo GetOperator (vpeljava stavkov throw in try-catch)
            try
            {
                string oprt = GetOperator(5);
                Console.WriteLine($"Operator je {oprt}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Prišlo je do napake:\n{ex.Message}");
            }

            // Primer napake pri delu s tabelo
            string[] tblZivali = new string[5] { "puran", "glista", "svinja", "zebra", "mravljinčar" };

            try
            {
                Console.WriteLine($"{tblZivali[5]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Napaka! Smo izven intervala vrednosti:\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Prišlo je do neke popolnoma druge napake:\n{ex.Message}");
            }

            // In še klic metode GetPatientsHeight
            int patientsHeight = GetPatientsHeight();
            Console.WriteLine($"Višina pacienta je {patientsHeight}");

            //Console.Read();


            // Izpiši GCD za vse pare števil od 1 do n
            //WriteGCDForPairs(15);

            // Pokličimo še metodo, ki lovi izjeme
            CatchException();

            // Še ena funkcija z nekaj več opravili
            ComputingQuestions();

            Console.Read();
        }

        static double PovprecnaOcena()
        {
            // Definiramo seznam, ki mu za tip podatkov podamo (urejen) par tipov
            // Paru tipov lahko celo damo imena!
            /* Primer:
             * Borut 68
             * Boris 73
             * Bine 98
             * Boštjan 87
             */
            List<(string Ime, int Tocke)> lstPodatki = new List<(string, int)>();

            while (true)
            {
                Console.Write("Vpišite ime študenta (ali 0 za izhod): ");
                string ime = Console.ReadLine();
                if (ime == "0")
                {
                    Console.Write("\nPrenehali ste z vpisovanjem!\n");
                    break;
                }
                Console.Write("Vpišite število točk: ");
                int tocke = int.Parse(Console.ReadLine());
                lstPodatki.Add((ime, tocke));
            }

            double vsota = 0;
            // Ker vemo, za akšen tip podatka gre, lahko uporabimo var
            foreach (var par in lstPodatki)
            {
                vsota += par.Tocke;
            }

            // Izpišimo frekvenco posameznih ocen
            int[] tblFrekvenca = new int[6];
            foreach (var par in lstPodatki)
            {
                int ocena = (int)Math.Max(Math.Ceiling(par.Tocke / 10D), 5);
                tblFrekvenca[ocena - 5]++;
            }
            for (int i = 0; i < tblFrekvenca.Length; i++)
            {
                Console.WriteLine($"Število ocen {i + 5} je {tblFrekvenca[i]}");
            }

            // Izračunajmo povprečno oceno
            double povprecnaOcena = (vsota / lstPodatki.Count) / 10;

            return povprecnaOcena;
        }


        /// <summary>
        /// Izračuna indeks telesne mase.
        /// </summary>
        /// <param name="mass">Telesna masa</param>
        /// <param name="height">Telesna višina</param>
        /// <returns>BMI</returns>
        static double BodyMassIndex(double mass, double height)
        {
            double bmi = mass / (height * height);
            return bmi;
        }


        /// <summary>
        /// Metoda kot parametra prejme dve celi števili,
        /// vrača pa realno število, ki predstavlja
        /// kvocient parametrov.
        /// </summary>
        static double Kvocient(int a, int b)
        {
            double result = (double)a / b;

            // Stavek return pove, katero vrednost vračamo
            return result;
        }

        /// <summary>
        /// Moja nova metoda s super opisom...
        /// </summary>
        /// <param name="a">Moj parameter a</param>
        /// <param name="b">Njen parameter b</param>
        /// <returns>Kvocient a in b</returns>
        static double Kvocient(double a, int b)
        {
            double result = a / b;

            // Stavek return pove, katero vrednost vračamo
            return result;
        }

        static int GetPatientsHeight()
        {
            int height = 0;
            while (height == 0)
            {
                Console.Write($"Vpišite svojo višino: ");
                string answer = Console.ReadLine();

                try
                {
                    height = int.Parse(answer);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Prišlo je do napake, " +
                        $"zaradi nepravilne oblike vnosa (ni število)!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Prišlo je do napake, " +
                        $"zaradi vnosa števila, ki je preveliko ali premajhno za int!");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Prišlo je do napake:\n{ex.Message}");
                    throw new Exception($"Nekaj je šlo hudo narobe!\n{ex.Message}");
                }
            }

            return height;
        }

        /// <summary>
        /// Sešteje tri podana števila.
        /// </summary>
        /// <param name="num1">Prvo število</param>
        /// <param name="num2">Drugo število</param>
        /// <param name="num3">Tretjo število</param>
        /// <returns>Vsoto treh podanih števil.</returns>
        static int SumThree(int num1, int num2, int num3) // Glava metode
        {
            int result = num1 + num2 + num3;

            return result;
        }

        static double Quotient(int num1, int num2)
        {
            double result = num1 / (double)num2;
            return result;
        }

        /// <summary>
        /// Poišče največji skupni delitelj dveh števil
        /// </summary>
        public static int GreatestCommonDivisor(int a, int b)
        {
            int gcd = 1;
            for (int i = 2; i < Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    gcd = i;
                }
            }
            return gcd;
        }

        /// <summary>
        /// Izpiše GCD za vse pare od 1 do n
        /// </summary>
        public static void WriteGCDForPairs(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    int gcd = GreatestCommonDivisor(i, j);
                    Console.WriteLine($"Največji skupni delitelj števil {i} in {j} je {gcd}.");
                }
                Console.WriteLine();
            }
        }

        static void CatchException()
        {
            string? input = null;

            while (true)
            {
                try
                {
                    Console.Write("Vnesite število, jaz pa bom izračunal njegov kvadrat: ");
                    input = Console.ReadLine();
                    if (input == "")
                        input = null;

                    // Pretvorimo dane vhodne podatke v celo število
                    int inputInt = int.Parse(input);
                    Console.WriteLine($"Kvadrat števila {inputInt} je {inputInt * inputInt}");
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine($"Vnos je prazen! Podajte število.");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Vnos {input} ni v pravilni obliki!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Prišlo je do nepredvidene napake!\n" +
                        $"{ex.Message}");
                }
                // V stavku finally izvedemo ukaze, ki se naj izvedejo v vsakem primeru, ko pride do napake
                finally
                {
                    Console.WriteLine("Na tem mestu se metoda zaključi!\n");
                }
            }
        }

        /// <summary>
        /// Metoda uporabniku podaja računske naloge, dokler se ta ne zmoti,
        /// in vrne število pravilnih odgovorov
        /// </summary>
        static int ComputingQuestions()
        {
            Random rnd = new Random();
            int countCorrect = 0;
            int upperLimit = 8;
            while (true)
            {
                upperLimit *= (countCorrect / 5) + 1;
                int num1 = rnd.Next(1, upperLimit);
                int num2 = rnd.Next(1, upperLimit);
                int num3 = rnd.Next(1, 10);

                byte operation1 = (byte)rnd.Next(0, 4);
                byte operation2 = (byte)rnd.Next(0, 4);

                int correctAnswer = Compute(num1, num2, num3, operation1, operation2);
                string question = $"{num1} {GetOperator(operation1)} {num2} {GetOperator(operation2)} {num3}";

                Console.WriteLine($"Zapišite rezultat izraza: {question}");
                Console.Write("Odgovor: ");
                string answer = Console.ReadLine();

                try
                {
                    int answerInt = int.Parse(answer);
                    if (answerInt == correctAnswer)
                    {
                        countCorrect++;
                        Console.WriteLine($"Odgovor {answerInt} je pravilen! Imate že {countCorrect} pravilnih odgovorov!");
                    }
                    else
                    {
                        Console.WriteLine($"Odgovor {answerInt} ni pravilen! " +
                            $"Igra je zaključena. Zbrali ste {countCorrect} pravilnih odgovorov!");
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Vaš odgovor ni število, zato je žal napačen!\n\nGAME OVER!\n\n");
                    Console.WriteLine($"Pravilno ste odgovorili na {countCorrect} vprašanj!");
                    break;
                }
                finally
                {
                    Console.WriteLine();
                }
            }
            return countCorrect;
        }

        /// <summary>
        /// Funkcija vrne znak, ki predstavlja operacijo
        /// glede na podano vrednost.
        /// </summary>
        /// <param name="operation">Številska vrednost operacije (0-seštevanje, 1-odštevanje, 2-množenje in 3-deljenje)</param>
        /// <returns>Znak za operacijo</returns>
        /// <exception cref="Exception">Napaka, če podana vrednost ni celo število iz intervala [0,3]</exception>
        static string GetOperator(byte operation)
        {
            switch (operation)
            {
                case 0:
                    return "+";
                case 1:
                    return "-";
                case 2:
                    return "*";
                case 3:
                    return "/";
                default:
                    // Vržemo izjemo nazaj na pozicijo klica metode
                    throw new Exception("GetOperator::Operacija s to vrednostjo ni predvidena!");
            }
        }

        static int Compute(int num1, int num2, int num3, byte op1, byte op2)
        {
            int finalResult = 0;
            if (op1 == 2 || op1 == 3)
            {
                finalResult = ComputeSimple(num1, num2, op1);
                finalResult = ComputeSimple(finalResult, num3, op2);
            }
            else if (op2 == 2 || op2 == 3)
            {
                finalResult = ComputeSimple(num2, num3, op2);
                finalResult = ComputeSimple(num1, finalResult, op1);
            }
            else
            {
                finalResult = ComputeSimple(num1, num2, op1);
                finalResult = ComputeSimple(finalResult, num3, op2);
            }
            return finalResult;
        }

        /// <summary>
        /// Izračuna vrednost izraza za dani operator.
        /// </summary>
        static int ComputeSimple(int num1, int num2, byte op)
        {
            switch (op)
            {
                case 0: return num1 + num2;
                case 1: return num1 - num2;
                case 2: return num1 * num2;
                case 3: return num1 / num2;
                default: return 0;
            }
        }

        /// NALOGA 1:
        /// Napišite metodo, ki uporabniku ponudi možnost 
        /// vnosa artikla na nakupovalni seznam skupaj 
        /// s številom kosov teh artiklov (npr. jogurt, 2).
        /// Glede poziva uporabniku se lahko odločite sami
        /// (npr. najprej ga pozovete, naj vnese naziv artikla, 
        /// in nato še, naj vnese število kosov oziroma količino).
        /// 
        /// Uporabnik naj artikle vnaša, dokler se ne odloči, 
        /// da je vnesel vse, in zaključi (tudi za to naj ima na voljo ukaz). [15 točk]
        /// 
        /// Na koncu izpišite vse artikle na seznamu uporabnika in skupno število kosov. [5 točk]
        static void Izpit2023_Naloga1()
        {
            List<(string Naziv, int Kolicina)> lstNakupovalniSeznam = new List<(string, int)>();
            string kodaZaIzhod = "K";
            int skupnoSteviloKosov = 0;
            while (true)
            {
                Console.Write($"Vnesite ime artikla (ali '{kodaZaIzhod}' za izhod iz programa): ");
                string nazivArtikla = Console.ReadLine();
                if (nazivArtikla.ToUpper() == kodaZaIzhod)
                {
                    break;
                }

                Console.Write("Vnesite še količino: ");
                int kolicina = int.Parse(Console.ReadLine()); // Domača naloga - dopolniti s try-catch

                skupnoSteviloKosov = skupnoSteviloKosov + kolicina;
                lstNakupovalniSeznam.Add((nazivArtikla, kolicina));
            }
            Console.Write("Zapisovanje je končano. na seznamu imate naslednje artikle:\n");

            // Izpišimo vse artikle
            foreach (var artikel in lstNakupovalniSeznam)
            {
                Console.WriteLine($"Artikel: {artikel.Naziv}, količina: {artikel.Kolicina}");
            }
            Console.Write($"Skupno število kosov na seznamu je: {skupnoSteviloKosov}");
        }
    }
}