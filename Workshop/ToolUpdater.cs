using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Workshop
{
    public static class ToolUpdater
    {
        /*************************************
         * nazwa funkcji:       UpdateTool
         * informacje:          Funkcja umożliwia aktualizację danych istniejącego narzędzia 
         *                      na podstawie jego identyfikatora (ID). Wczytuje listę narzędzi z pliku, 
         *                      pozwala użytkownikowi na zmianę nazwy, ilości oraz ceny wybranego narzędzia, 
         *                      a następnie zapisuje zaktualizowaną listę z powrotem do pliku.
         * autor:               Kornel Pakulski
         *************************************/

        public static void UpdateTool(string toolspath)
        {
            if (!File.Exists(toolspath))
            {
                Console.WriteLine("Plik z narzędziami nie istnieje.");
                return;
            }

            string jsonTools = File.ReadAllText(toolspath);
            List<Tool> toolsList = JsonSerializer.Deserialize<List<Tool>>(jsonTools) ?? new List<Tool>();

            Console.Write("Podaj Id narzędzia: ");
            if (int.TryParse(Console.ReadLine(), out int toolId))
            {
                Tool toolToUpdate = toolsList.Find(t => t.Id == toolId);
                if (toolToUpdate != null)
                {
                    Console.WriteLine($"Aktualne dane narzędzia:");
                    Console.WriteLine($"ID: {toolToUpdate.Id}");
                    Console.WriteLine($"Nazwa: {toolToUpdate.Name}");
                    Console.WriteLine($"Ilość: {toolToUpdate.Amount}");
                    Console.WriteLine($"Cena: {toolToUpdate.Price} zł");

                    Console.Write("Podaj nazwę narzędzia: ");
                    string newName = Console.ReadLine();
                    toolToUpdate.Name = newName;

                    Console.Write("Podaj ilość narzędzi: ");
                    string newAmountInput = Console.ReadLine();
                    if (int.TryParse(newAmountInput, out int newAmount))
                    {
                        toolToUpdate.Amount = newAmount;
                    }

                    Console.Write("Podaj nową cenę narzędzia: ");
                    string newPriceInput = Console.ReadLine();
                    if (double.TryParse(newPriceInput, out double newPrice))
                    {
                        toolToUpdate.Price = newPrice;
                    }

                    string updatedJson = JsonSerializer.Serialize(toolsList, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(toolspath, updatedJson);
                    Console.WriteLine("Narzędzie zostało zaktualizowane.");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono narzędzia o podanym ID.");
                }
            }
            else
            {
                Console.WriteLine("Błąd: Wprowadź poprawne ID.");
            }
        }
    }
}
