using System;

namespace Workshop
{
    internal class AddTool
    {
        /*************************************
         * nazwa funkcji:   AddTools
         * informacje:      Funkcja umożliwia dodanie nowego narzędzia do listy. 
         *                  Użytkownik wprowadza nazwę, ilość oraz cenę narzędzia. 
         *                  Funkcja oblicza nowe ID na podstawie istniejących narzędzi 
         *                  (jeśli lista nie jest pusta) lub przyjmuje wartość 1, jeśli lista jest pusta, 
         *                  a następnie tworzy i dodaje nowe narzędzie do listy.
         * autor:           Kornel Pakulski
         *************************************/
        public void AddTools(List<Tool> tools)
        {
            Console.Write("Podaj nazwę narzędzia: ");
            string name = Console.ReadLine();

            Console.Write("Podaj ilość narzędzi: ");
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                Console.WriteLine("Błąd: Wprowadź poprawną liczbę całkowitą!");
                return;
            }
            if(amount < 0)
             {
                 Console.WriteLine("Błąd: Wprowadź poprawną liczbę całkowitą!");
                 return;
             }

            Console.Write("Podaj cenę narzędzia: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Błąd: Wprowadź poprawną liczbę dziesiętną!");
                return;
            }

            int newId = tools.Count > 0 ? tools.Max(t => t.Id) + 1 : 1;
            Tool newTool = new Tool(newId, name, amount, price);
            tools.Add(newTool);

            Console.WriteLine($"Dodano narzędzie {name}");
        }
    }
}
