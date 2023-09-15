namespace WinFormsTest.Models
{
    public class Symbol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime DateAdded { get; set; }
        public double Price { get; set; }
        public DateTime PriceDate { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int ExchangeId { get; set; }
        public string ExchangeName { get; set; }

        public Symbol()
        {

        }

    }
}
