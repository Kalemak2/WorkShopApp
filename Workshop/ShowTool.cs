using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    class ShowTool
    {
        /*************************************
        * nazwa funkcji:    ShowTools
        * informacje:       Funkcja iteruje przez listę narzędzi i 
        *                   wyświetla ich identyfikator, nazwę, ilość oraz cenę. 
        *                   Jeśli lista jest pusta, informuje użytkownika o braku narzędzi w magazynie.
        * autor:            Kornel Pakulski
        *************************************/
        public static void ShowTools(List<Tool> toolList)
        {
            if (toolList.Count == 0)
            {
                Console.WriteLine("Brak narzędzi w magazynie!");
            }
            else
            {
                foreach (var tool in toolList)
                {
                    Console.WriteLine($"Id: {tool.Id}, Nazwa: {tool.Name}, Ilość: {tool.Amount}, Cena: {tool.Price}");
                }
            }
        }
    }
}
