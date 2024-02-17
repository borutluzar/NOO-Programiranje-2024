// Najvišji bloki kode so imenski prostori oziroma
// angleško "namespaces"
namespace Introduction
{
    // Razredi so posebne strukture, o katerih več povemo v posebnem poglavju
    class Program
    {
        // Program se vedno začne izvajati v metodi Main,
        // metode pa so sklopi kode, ki jih najdemo v razredih in
        // predstavljajo 'algoritme' oziroma 'postopke', ki glede na 
        // dane vhodne podatke izvedejo zaporedje ukazov in vrnejo rezultat
        static void Main(string[] args)
        {
            // Spodnji ukaz ob zagonu izpiše besedilo v narekovajih - Pozdravljen, svet!
            Console.WriteLine("Pozdravljen, svet!");
            
            // Ukaz Read zadrži okno ukazne vrstice (pričakuje vnos uporabnika)
            Console.Read();
        }
    }
}