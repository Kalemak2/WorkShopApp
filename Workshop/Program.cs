using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Workshop
{
    class Program
    {
        public static void Main(string[] args)
        {
            string toolspath = "tools.json";

            if (!File.Exists(toolspath))
            {
                File.Create(toolspath).Close();
                File.WriteAllText(toolspath, "[]");
            }

            AddTool tools = new AddTool();
            List<Tool> toolsList = new List<Tool>();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Witaj w menedżerze narzędzi");
                string[] options =
                {
                    "Dodaj narzędzie",
                    "Aktualizuj narzędzie",
                    "Usuń narzędzie",
                    "Zapisz narzędzie",
                    "Wyświetl pojedyncze narzędzie",
                    "Wyświetl wszystkie narzędzia",
                    "Wyjdź"
                };

                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }

                Console.Write("Wybierz opcję: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        if (File.Exists(toolspath))
                        {
                            string json_tools = File.ReadAllText(toolspath);
                            toolsList = JsonSerializer.Deserialize<List<Tool>>(json_tools) ?? new List<Tool>();
                        }

                        Console.Clear();
                        tools.AddTools(toolsList);
                        break;
                    case "2":
                        ToolUpdater.UpdateTool(toolspath);
                        break;
                    case "3":
                        ToolRemover.RemoveTool(toolspath);
                        break;
                    case "4":
                        ToolSaver.SaveTools(toolsList, toolspath);
                        break;
                    case "5":
                        ToolViewer.ViewTool(toolspath);
                        break;
                    case "6":
                        string jsonToolsAll = File.ReadAllText(toolspath);
                        toolsList = JsonSerializer.Deserialize<List<Tool>>(jsonToolsAll) ?? new List<Tool>();

                        ShowTool.ShowTools(toolsList);
                        break;
                    case "7":
                        Console.WriteLine("Zamykanie programu...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nNaciśnij dowolny klawisz, aby powrócić do menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
