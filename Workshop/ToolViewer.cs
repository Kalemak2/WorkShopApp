using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Workshop
{
    public static class ToolViewer
    {
        /*************************************
         * nazwa funkcji:   ViewTool
         * informacje:      Funkcja umożliwia wyświetlenie informacji 
         *                  o narzędziu na podstawie jego identyfikatora (ID).
         *                  Wczytuje listę narzędzi z pliku, a następnie prezentuje dane 
         *                  wybranego narzędzia, jeśli zostanie ono znalezione.
         * autor:           Kornel Pakulski
         *************************************/
        public static void ViewTool(string toolspath)
        {
            if (!File.Exists(toolspath))
            {
                Console.WriteLine("Plik z narzędziami nie istnieje.");
                return;
            }

            Console.Write("Podaj ID narzędzia do wyświetlenia: ");
            if (int.TryParse(Console.ReadLine(), out int toolId))
            {
                string jsonTools = File.ReadAllText(toolspath);
                List<Tool> toolsList = JsonSerializer.Deserialize<List<Tool>>(jsonTools) ?? new List<Tool>();

                Tool foundTool = toolsList.Find(t => t.Id == toolId);
                if (foundTool != null)
                {
                    Console.WriteLine($"ID: {foundTool.Id}, Nazwa: {foundTool.Name}, Ilość: {foundTool.Amount}, Cena: {foundTool.Price}");
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
