using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Workshop
{
    public static class ToolSaver
    {
         /*************************************
          * nazwa funkcji:      SaveToolsia
          * typ zwracany:       void, brak wartości zwracanej
          * informacje:         Funkcja zapisuje listę narzędzi do pliku JSON. 
          *                     W przypadku błędu podczas zapisu, wyświetla komunikat o błędzie.
          * autor:              Kornel Pakulski
          *************************************/


        public static void SaveTools(List<Tool> tools, string toolspath)
        {
            try
            {
                string json = JsonSerializer.Serialize(tools, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(toolspath, json);
                Console.WriteLine("Narzędzia zapisane");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zapisu: {ex.Message}");
            }
        }
    }
}
