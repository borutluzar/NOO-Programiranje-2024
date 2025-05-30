﻿// Najvišji bloki kode so imenski prostori oziroma
// angleško "namespaces"
namespace Introduction
{
    // Razredi so posebne strukture, o katerih več povemo v 8. poglavju
    class Program
    {
        // Program se vedno začne izvajati v metodi Main,
        // metode pa so sklopi kode, ki jih najdemo v razredih in
        // predstavljajo 'algoritme' oziroma 'postopke', ki glede na 
        // dane vhodne podatke izvedejo zaporedje ukazov in vrnejo rezultat
        static void Main(string[] args)
        {
            /*
             Moj komentar, ki je postavljen
            preko nekaj vrstic
             */            

            // Spodnji ukaz 'WriteLine' ob zagonu v ukazni vrstici izpiše besedilo v narekovajih - Pozdravljen, svet!
            Console.WriteLine("Pozdravljen, svet!");
            
            // Ukaz 'Read' zadrži okno ukazne vrstice (pričakuje vnos uporabnika)
            Console.Read();
        }
    }
}