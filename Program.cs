using System;

namespace telprov
{
    class Program
    {
            
            static void Main(string[] args)
            {

                bool exit = false;
                string car;
                string num;
                float credit;

                string dest;
                int min;


                Console.WriteLine($"inserisci un numero di telefono:");
               
                num = EnterPhoneNumber();

                Console.WriteLine($"inserisci il credito iniziale:");
                credit = float.Parse(Console.ReadLine());
                Sim s1 = new Sim(num, credit);
                Proceed();

                do
                {
                    Console.Clear();

                    Console.WriteLine("Cosa vuoi fare?");
                    Console.WriteLine("[0] - inserisci una chiamata");
                    Console.WriteLine("[1] - visualizza il totale dei minuti chiamate");
                    Console.WriteLine("[2] - totale dei minuti verso un numero");
                    Console.WriteLine("[3] - totale delle chiamate verso un numero");
                    Console.WriteLine("[4] - stampa info sim");
                    Console.WriteLine("[5] - aggiungi credito");
                    Console.WriteLine("[6] - esci");

                car = Console.ReadLine();
                    Console.Clear();

                switch (car)
                {
                    case "0":
                        Console.WriteLine("inserisci il destinatario:");

                        dest = EnterPhoneNumber();

                        Console.WriteLine("inserisci la durata in minuti");
                        min = int.Parse(Console.ReadLine());


                        float? payed = s1.addCall(dest, min);
                        if (payed != null)
                        {
                            Console.WriteLine($"hai inserito una chiamata di {min}minuti verso {dest} e hai speso {payed}");
                        }
                        else
                        {
                            Console.WriteLine("credito non sufficiente. Ricaricare");
                        }
                      
                        break;
                    case "1":
                        Console.WriteLine($"il totale dei minuti passati in chiamata è: {s1.getTotalMinutes()}");
                        break;
                    case "2":
                        Console.WriteLine("inserisci il numero del destinatario");

                        dest = EnterPhoneNumber();

                        min = s1.getMinutesFromNumber(dest);

                        Console.WriteLine($"Hai effettuato {min} minuti verso {dest}");
                        break;
                    case "3":
                        Console.WriteLine("inserisci il numero del destinatario");

                        dest = EnterPhoneNumber();

                        Console.WriteLine($"hai chiamato {dest} per {s1.getCallsFromNumber(dest)} volte");
                        break;
                    case "4":
                        s1.printSimInfo();
                        break;
                    case "5":
                        Console.WriteLine("inserisci la ricarica");
                        float charge = float.Parse(Console.ReadLine());
                        float newCredit = s1.addCredit(charge);
                        Console.WriteLine($"il tuo credito è: {newCredit}");
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("io sono bionda ma tu non sai inserire un numero da 0 a 5.\nRiprova ");
                        break;
                }
                if (!exit)  
                    Proceed();

            } while (!exit);

            }

        static string EnterPhoneNumber()
        {
            bool numValid;
            string num;

            do
            {
                num = Console.ReadLine();
                numValid = Utility.isPhoneNumber(num);
                if (!numValid)
                {
                    Console.WriteLine("numero sbagliato. inseriscine uno nuovo");
                }
            } while (!numValid);

            return num;
        }

        static void Proceed()
        {
            Console.WriteLine("procedi un tasto per continuare");
            Console.ReadKey();
        }
    }
}
