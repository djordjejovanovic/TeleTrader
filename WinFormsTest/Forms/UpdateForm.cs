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

namespace WinFormsTest.Forms
{
    public partial class UpdateForm : Form
    {

        public string selectedDbPath;
        private static SQLiteConnection connect;

        public UpdateForm()
        {
            InitializeComponent();

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Symbol symbol = new Symbol();

                symbol.Id = id;
                symbol.Name = nameTb.Text != null || !nameTb.Text.Equals("") ? nameTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(nameTb.Text));
                symbol.Ticker = tickerTb.Text != null || !tickerTb.Text.Equals("") ? tickerTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(tickerTb.Text));
                symbol.Isin = isinTb.Text != null || !isinTb.Text.Equals("") ? isinTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(isinTb.Text));
                symbol.CurrencyCode = currencyCodeTb.Text != null || !currencyCodeTb.Text.Equals("") ? currencyCodeTb.Text : throw new ArgumentException("Parameter cannot be null or empty", nameof(currencyCodeTb.Text));
                symbol.DateAdded = DateTime.Now.Date;
                symbol.Price = priceTb.Text != null || !priceTb.Text.Equals("") ? Convert.ToDouble(priceTb.Text) : throw new ArgumentException("Parameter cannot be null or empty", nameof(priceTb.Text));
                symbol.PriceDate = priceDateDp.Value != null ? priceDateDp.Value : throw new ArgumentException("Parameter cannot be null or empty", nameof(priceDateDp.Value));

                string type = (string)typeCb.SelectedItem;
                symbol.TypeId = (int)Program.typeList?.Where(x => x.Name.Equals(type)).Select(x => x.Id).FirstOrDefault();

                string exchange = (string)exchangeCb.SelectedItem;
                symbol.ExchangeId = (int)Program.exchangeList?.Where(x => x.Name.Equals(exchange)).Select(x => x.Id).FirstOrDefault();

                connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandType = CommandType.Text;
                fmd.CommandText = @"UPDATE Symbol 
                                    SET Name = @Name, Ticker = @Ticker, Isin = @Isin, CurrencyCode = @CurrencyCode, 
                                        DateAdded = @DateAdded, Price = @Price, PriceDate = @PriceDate, 
                                        TypeId = @TypeId, ExchangeId = @ExchangeId
                                    WHERE Id = @Id";
                fmd.Parameters.AddWithValue("@Id", symbol.Id);
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
            finally
            {
                closeConnection();
            }
        }
    }
}
