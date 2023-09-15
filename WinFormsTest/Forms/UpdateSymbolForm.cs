using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.Models;
using WinFormsTest.Repository;

namespace WinFormsTest.Forms
{
    public partial class UpdateSymbolForm : Form
    {

        public string selectedDbPath;
        public SQLiteConnection connect;
        public SymbolRepository symbolRepo { get; set; }
        public TypeRepository typeRepo { get; set; }
        public ExchangeRepository exchangeRepo { get; set; }

        public UpdateSymbolForm()
        {
            InitializeComponent();
        }

        public UpdateSymbolForm(SymbolRepository symbolRepo, TypeRepository typeRepo, ExchangeRepository exchangeRepo)
        {
            this.symbolRepo = symbolRepo;
            this.typeRepo = typeRepo;
            this.exchangeRepo = exchangeRepo;
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateSymbolBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Symbol symbol = new Symbol();

                symbol.Id = id;
                symbol.Name = !nameTb.Text.Equals("") ? nameTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(nameTb.Text));
                symbol.Ticker = !tickerTb.Text.Equals("") ? tickerTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(tickerTb.Text));
                symbol.Isin = !isinTb.Text.Equals("") ? isinTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(isinTb.Text));
                symbol.CurrencyCode = !currencyCodeTb.Text.Equals("") ? currencyCodeTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(currencyCodeTb.Text));
                symbol.DateAdded = DateTime.Now.Date;
                symbol.Price = !priceTb.Text.Equals("") ? Convert.ToDouble(priceTb.Text) : throw new ArgumentException("Parameter cannot be null or empty", nameof(priceTb.Text));
                symbol.PriceDate = priceDateDp.Value;

                string type = (string)typeCb.SelectedItem;
                symbol.TypeId = (int)typeRepo.typeList.Where(x => x.Name.Equals(type)).Select(x => x.Id).FirstOrDefault();

                string exchange = (string)exchangeCb.SelectedItem;
                symbol.ExchangeId = (int)exchangeRepo.exchangeList.Where(x => x.Name.Equals(exchange)).Select(x => x.Id).FirstOrDefault();

                bool ok = symbolRepo.updateSymbol(symbol);

                if (ok)
                {
                    MessageBox.Show("Uspesno promenjen Symbol.");
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
