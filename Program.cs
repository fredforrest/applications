using System;
using System.Globalization;

namespace DownCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til din personlige COUNTDOWN assistent!");
            Console.Write("Du kan her indtaste en dato for en begivenhed, som du ønsker at tælle ned til (dd/mm/yyyy): ");
            string userInput = Console.ReadLine();

            DateTime eventDate;

            TimeSpan timeUntilEvent;

            if (DateTime.TryParseExact(userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out eventDate)) // disse variabler er med til indlemme andre tidszoner og kulturer i forhold til forskelle i datoer og tider. Så tager programmet den tid som er på brugerens computer.
            {
                while (true) 
                { 
                    timeUntilEvent = eventDate - DateTime.Now;
                    if (timeUntilEvent.TotalSeconds <= 0) // påsætter en tæller i realtime på eventet såfremt det er true. Altså et event i fremtiden

                    {

                        Console.WriteLine("Du kan ikke rejse tilbage i tiden kammerat!");
                        break;
                    }
                    
                    
                    Console.Clear();

                    Console.WriteLine($"Dage til begivenheden: {timeUntilEvent.Days}");
                    Console.WriteLine($"Timer til begivenheden: {timeUntilEvent.Hours}");
                    Console.WriteLine($"Minutter til begivenheden: {timeUntilEvent.Minutes}");
                    Console.WriteLine($"Sekunder til begivenheden: {timeUntilEvent.Seconds}");

                    Thread.Sleep(1000); //tæller ned med 1000 millisekunder (1 sekund)

                }
                     

             }
            else
            {
                Console.WriteLine("Ugyldigt dato er indtastet. Husk at bruge dd/mm/yyyy formatet");
                return;

            }

            

        } 


    }
}