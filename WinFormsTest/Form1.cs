using System;
using System.Data;
using System.Data.SQLite;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        private string selectedDbPath;
        private static SQLiteConnection connect = new SQLiteConnection(@"Data Source=");

        public Form1()
        {
            InitializeComponent();
        }

        private void selectPathBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            selectedDbPath = openFileDialog1.FileName;
            tfPath.Text = selectedDbPath;

            try
            {
                connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandText = @"SELECT * FROM Type";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader rdr = fmd.ExecuteReader();

                List<Type> typelList = new List<Type>();
                cbType.Items.Clear();
                cbType.Items.Add("All");
                cbType.SelectedItem = "All";

                while (rdr.Read())
                {
                    Type type = new Type();
                    type.Id = (int)(long)rdr["Id"];
                    type.Name = (string)rdr["Name"];

                    typelList.Add(type);        //nema potrebe, ali moze da posluzi da se ima ceo objekat
                    cbType.Items.Add(type.Name);
                }

                rdr.Close();
                typeLbl.Show();
                cbType.Show();


                fmd.CommandText = @"SELECT * FROM Exchange";
                rdr = fmd.ExecuteReader();

                List<Exchange> exchangelList = new List<Exchange>();
                cbExchange.Items.Clear();
                cbExchange.Items.Add("All");
                cbExchange.SelectedItem = "All";

                while (rdr.Read())
                {
                    Exchange exchange = new Exchange();
                    exchange.Id = (int)(long)rdr["Id"];
                    exchange.Name = (string)rdr["Name"];

                    exchangelList.Add(exchange);
                    cbExchange.Items.Add(exchange.Name);
                }

                rdr.Close();
                exchangeLbl.Show();
                cbExchange.Show();

                pretraziBtn.Show();
                
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (tfPath.Text != null && tfPath.Text != "")
                selectedDbPath = tfPath.Text;

            string type = (string)cbType.SelectedItem;
            string exchange = (string)cbExchange.SelectedItem;

            try
            {
                connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandText = createQuery(type, exchange);
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader rdr = fmd.ExecuteReader();

                List<SymbolViewModel> symbolList = new List<SymbolViewModel>();
                while (rdr.Read())
                {

                    Symbol symbol = new Symbol();

                    symbol.Id = (int)(long)rdr["Id"];
                    symbol.Name = (string)rdr["Name"];
                    symbol.Ticker = (string)rdr["Ticker"];
                    symbol.Isin = (string)rdr["Isin"];
                    symbol.CurrencyCode = (string)rdr["CurrencyCode"];
                    symbol.DateAdded = (DateTime)rdr["DateAdded"];
                    symbol.Price = (double)rdr["Price"];
                    symbol.PriceDate = (DateTime)rdr["PriceDate"];
                    symbol.TypeId = (int)rdr["TypeId"];
                    symbol.ExchangeId = (int)rdr["ExchangeId"];
                    symbol.TypeName = (string)rdr[11];
                    symbol.ExchangeName = (string)rdr[13];

                    SymbolViewModel swm = new SymbolViewModel(symbol.Name, symbol.Ticker, symbol.Price, symbol.TypeName, symbol.ExchangeName);
                    symbolList.Add(swm);

                }
                rdr.Close();

                BindingSource binding = new BindingSource();
                binding.DataSource = symbolList;
                dataGridView1.DataSource = binding;

                if(!addSymbolBtn.Visible)
                    addSymbolBtn.Show();
                if (!editSymbolBtn.Visible)
                    editSymbolBtn.Show();
                if (!deleteSymbolBtn.Visible)
                    deleteSymbolBtn.Show();
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

        private string createQuery(string type, string exchange)
        {
            if (type == null || exchange == null)
                return "";

            string query = @"SELECT * 
                            FROM Symbol s, Type t, Exchange e
                            WHERE s.TypeId = t.Id AND s.ExchangeId = e.Id";

            if (type.Equals("All") && exchange.Equals("All"))
                return query;
            else if (type.Equals("All") && !exchange.Equals("All"))
                return query + " AND e.Name = '" + exchange + "'";
            else if (!type.Equals("All") && exchange.Equals("All"))
                return query + " AND t.Name = '" + type + "'";
            else
                return query + " AND t.Name = '" + type + "'" + " AND e.Name = '" + exchange + "'";
        }
    }
}