using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.Models;

namespace WinFormsTest.Forms
{
    public partial class AddSymbolForm : Form
    {
        public string selectedDbPath;
        public SQLiteConnection connect;

        public AddSymbolForm()
        {
            InitializeComponent();
        }

        public AddSymbolForm(string selectedDbPath)
        {
            this.selectedDbPath = selectedDbPath;
            this.connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
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
                
                if(!isinTb.Text.Equals("") && isinTb.Text.Length.Equals(13))
                    symbol.Isin = isinTb.Text;
                else
                {
                    MessageBox.Show("Duzina Isin koda mora biti 13! Pokusajte ponovo.");
                    throw new ArgumentException("Parameter cannot be null or empty and length must be 13", nameof(isinTb.Text));
                }

                if (!currencyCodeTb.Text.Equals("") && currencyCodeTb.Text.Length.Equals(3))
                    symbol.CurrencyCode = currencyCodeTb.Text;
                else
                {
                    MessageBox.Show("Duzina Currency koda mora biti 3! Pokusajte ponovo.");
                    throw new ArgumentException("Parameter cannot be null or empty and length must be 3", nameof(currencyCodeTb.Text));
                }

                symbol.DateAdded = DateTime.Now.Date;
                symbol.Price = !priceTb.Text.Equals("") ? Convert.ToDouble(priceTb.Text) : throw new ArgumentException("Parameter cannot be null or empty", nameof(priceTb.Text));
                symbol.PriceDate = priceDateDtp.Value;

                string type = (string)typeCb.SelectedItem;
                symbol.TypeId = (int)Program.typeList.Where(x => x.Name.Equals(type)).Select(x => x.Id).FirstOrDefault();

                string exchange = (string)exchangeCb.SelectedItem;
                symbol.ExchangeId = (int)Program.exchangeList.Where(x => x.Name.Equals(exchange)).Select(x => x.Id).FirstOrDefault();

                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandType = CommandType.Text;
                fmd.CommandText = @"INSERT INTO Symbol (Name, Ticker, Isin, CurrencyCode, DateAdded, Price, PriceDate, TypeId, ExchangeId) " +
                                    "VALUES (@Name, @Ticker, @Isin, @CurrencyCode, @DateAdded, @Price, @PriceDate, @TypeId, @ExchangeId)";
                fmd.Parameters.AddWithValue("@Name", symbol.Name);
                fmd.Parameters.AddWithValue("@Ticker", symbol.Ticker);
                fmd.Parameters.AddWithValue("@Isin", symbol.Isin);
                fmd.Parameters.AddWithValue("@CurrencyCode", symbol.CurrencyCode);
                fmd.Parameters.AddWithValue("@DateAdded", symbol.DateAdded.Date);
                fmd.Parameters.AddWithValue("@Price", symbol.Price);
                fmd.Parameters.AddWithValue("@PriceDate", symbol.PriceDate.Date);
                fmd.Parameters.AddWithValue("@TypeId", symbol.TypeId);
                fmd.Parameters.AddWithValue("@ExchangeId", symbol.ExchangeId);

                int rows = fmd.ExecuteNonQuery();
                if (rows == 1)
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
            finally
            {
                closeConnection();
            }
        }

        private void closeConnection()
        {
            if (connect != null && connect.State == ConnectionState.Open)
                connect.Close();
        }

        private void openConnection()
        {
            if (connect != null && connect.State == ConnectionState.Closed)
                connect.Open();
        }
    }
}
