using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsTest.Forms;
using WinFormsTest.Models;

namespace WinFormsTest
{
    public partial class Index : Form
    {
        private string selectedDbPath;
        private static SQLiteConnection connect = new SQLiteConnection(@"Data Source=");

        public Index()
        {
            InitializeComponent();
        }

        private void selectPathBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            selectedDbPath = openFileDialog1.FileName;
            Program.dbPath = selectedDbPath;

            try
            {
                connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandText = @"SELECT * FROM Type";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader rdr = fmd.ExecuteReader();

                List<Models.Type> typelList = new List<Models.Type>();
                cbType.Items.Clear();
                cbType.Items.Add("All");
                cbType.SelectedItem = "All";

                while (rdr.Read())
                {
                    Models.Type type = new Models.Type();
                    type.Id = (int)(long)rdr["Id"];
                    type.Name = (string)rdr["Name"];

                    typelList.Add(type);        //nema potrebe, ali moze da posluzi da se ima ceo objekat
                    cbType.Items.Add(type.Name);
                }

                if (typelList != null && typelList.Count != 0)
                    Program.typeList = typelList;

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

                if (exchangelList != null && exchangelList.Count != 0)
                    Program.exchangeList = exchangelList;

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
            if (Program.dbPath != null && Program.dbPath != "")
                selectedDbPath = Program.dbPath;

            string type = (string)cbType.SelectedItem;
            string exchange = (string)cbExchange.SelectedItem;

            try
            {
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

                if (!addSymbolBtn.Visible)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addSymbol_Click(object sender, EventArgs e)
        {
            AddSymbolForm addSymbolForm = new AddSymbolForm();

            if (addSymbolForm.typeCb != null)
            {
                addSymbolForm.typeCb.Items.AddRange(Program.typeList.Select(x => x.Name).ToArray());
                addSymbolForm.typeCb.SelectedIndex = 0;
            }

            if (addSymbolForm.exchangeCb != null)
            {
                addSymbolForm.exchangeCb.Items.AddRange(Program.exchangeList.Select(x => x.Name).ToArray());
                addSymbolForm.exchangeCb.SelectedIndex = 0;
            }

            addSymbolForm.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string message = "Da li zelite da obrisete Symbol(e)";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        try
                        {
                            string name = (string)row.Cells[0].Value;
                            string ticker = (string)row.Cells[1].Value;
                            double price = (double)row.Cells[2].Value;
                            string typeName = (string)row.Cells[3].Value;
                            string exchangeName = (string)row.Cells[4].Value;

                            openConnection();

                            SQLiteCommand fmd = connect.CreateCommand();
                            fmd.CommandType = CommandType.Text;
                            fmd.CommandText = @"DELETE FROM Symbol WHERE Name = '" + name + "' AND Ticker = '" + ticker + "' AND " +
                                                "Price = @Price";
                            fmd.Parameters.AddWithValue("@Price", price);

                            int rows = fmd.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                MessageBox.Show("Doslo je do greske! " + name + " nije obrisan.");
                            }
                            else
                                dataGridView1.Rows.RemoveAt(row.Index);
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

    }
}