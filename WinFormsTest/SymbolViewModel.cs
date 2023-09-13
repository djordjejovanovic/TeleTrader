using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTest
{
    class SymbolViewModel
    {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public double Price { get; set; }
        public string TypeName { get; set; }
        public string ExchangeName { get; set; }

        public SymbolViewModel(string name, string ticker, double price, string typeName, string exchangeName)
        {
            Name = name;
            Ticker = ticker;
            Price = price;
            TypeName = typeName;
            ExchangeName = exchangeName;
        }
    }
}
