using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Workshop
{
    public static class ToolRemover
    {
        /*************************************
        * nazwa funkcji:        RemoveTool
        * informacje:           Funkcja usuwa narzędzie z listy. Wczytuje dane z pliku, prosi użytkownika o 
        *                       podanie ID narzędzia, usuwa wybrane narzędzie (jeśli istnieje) i 
        *                       zapisuje zaktualizowaną listę z powrotem do pliku.
        * autor:                Kornel Pakulski
        *************************************/

        public static void RemoveTool(string toolspath)
        {
            if (!File.Exists(toolspath))
            {
                Console.WriteLine("Plik z narzędziami nie istnieje");
                return;
            }

            string jsonToDelete = File.ReadAllText(toolspath);
            List<Tool> toolsList = JsonSerializer.Deserialize<List<Tool>>(jsonToDelete) ?? new List<Tool>();

            Console.Write("Podaj ID narzędzia: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Tool toolToRemove = toolsList.Find(t => t.Id == deleteId);
                if (toolToRemove != null)
                {
                    Console.WriteLine($"Usunięto narzędzie {toolToRemove.Name}");
                    toolsList.Remove(toolToRemove);
                    string updatedJson = JsonSerializer.Serialize(toolsList, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(toolspath, updatedJson);
                    
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
