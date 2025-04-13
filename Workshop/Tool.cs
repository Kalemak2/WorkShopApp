using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Tool() { }

        public Tool(int id, string name, int amount, double price)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Price = price;
        }
    }
}
