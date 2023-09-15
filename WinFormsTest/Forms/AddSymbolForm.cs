using System.Data;
using WinFormsTest.Models;
using WinFormsTest.Repository;

namespace WinFormsTest.Forms
{
    public partial class AddSymbolForm : Form
    {
        public SymbolRepository symbolRepo { get; set; }
        public TypeRepository typeRepo { get; set; }
        public ExchangeRepository exchangeRepo { get; set; }

        public AddSymbolForm()
        {
            InitializeComponent();
        }

        public AddSymbolForm(SymbolRepository symbolRepo, TypeRepository typeRepo, ExchangeRepository exchangeRepo)
        {
            this.symbolRepo = symbolRepo;
            this.typeRepo = typeRepo;
            this.exchangeRepo = exchangeRepo;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Symbol symbol = new Symbol();

                symbol.Name = !addNameTb.Text.Equals("") ? addNameTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(addNameTb.Text));
                symbol.Ticker = !tickerTb.Text.Equals("") ? tickerTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(tickerTb.Text));
                symbol.Isin = !isinTb.Text.Equals("") ? isinTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(isinTb.Text));
                symbol.CurrencyCode = !currencyCodeTb.Text.Equals("") ? currencyCodeTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(currencyCodeTb.Text));
                symbol.DateAdded = DateTime.Now.Date;
                symbol.Price = !priceTb.Text.Equals("") ? Convert.ToDouble(priceTb.Text) : throw new ArgumentException("Parameter cannot be null or empty", nameof(priceTb.Text));
                symbol.PriceDate = priceDateDtp.Value;

                string type = (string)typeCb.SelectedItem;
                symbol.TypeId = (int)typeRepo.typeList.Where(x => x.Name.Equals(type)).Select(x => x.Id).FirstOrDefault();

                string exchange = (string)exchangeCb.SelectedItem;
                symbol.ExchangeId = (int)exchangeRepo.exchangeList.Where(x => x.Name.Equals(exchange)).Select(x => x.Id).FirstOrDefault();

                bool ok = symbolRepo.createNewSymbol(symbol);
                
                if (ok)
                {
                    MessageBox.Show("Uspesno dodat Symbol.");
                    this.Close();
                }
                else
                    MessageBox.Show("Doslo je do greske! Pokusajte ponovo.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
