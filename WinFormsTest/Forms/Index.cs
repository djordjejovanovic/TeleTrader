using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsTest.Forms;
using WinFormsTest.Models;
using WinFormsTest.Repository;
using Type = WinFormsTest.Models.Type;

namespace WinFormsTest
{
    public partial class Index : Form
    {
        private string selectedDbPath = "";
        private static SQLiteConnection connect = new SQLiteConnection();
        private TypeRepository typeRepo;
        private ExchangeRepository exchangeRepo;
        private SymbolRepository symbolRepo;

        public Index()
        {
            InitializeComponent();
        }

        private void selectPathBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            selectedDbPath = openFileDialog1.FileName;

            if (!selectedDbPath.Equals(""))
            {
                typeRepo = new TypeRepository(selectedDbPath);
                exchangeRepo = new ExchangeRepository(selectedDbPath);
                symbolRepo = new SymbolRepository(selectedDbPath);
            }

            try
            {
                cbType.Items.Clear();
                cbType.Items.Add("All");
                cbType.SelectedItem = "All";
                List<Type> typelList = typeRepo.getAllTypes();
                cbType.Items.AddRange(typelList.Select(x => x.Name).ToArray());

                typeLbl.Show();
                cbType.Show();

                cbExchange.Items.Clear();
                cbExchange.Items.Add("All");
                cbExchange.SelectedItem = "All";
                List<Exchange> exchangelList = exchangeRepo.getAllExchanges();
                cbExchange.Items.AddRange(exchangelList.Select(x => x.Name).ToArray());

                exchangeLbl.Show();
                cbExchange.Show();

                filterBtn.Show();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void filterButton_Click(object sender, EventArgs e)
        {

            string type = (string)cbType.SelectedItem;
            string exchange = (string)cbExchange.SelectedItem;

            try
            {

                List<Symbol> symbolList = symbolRepo.getFilteredSymbols(type, exchange);
                List<SymbolViewModel> symbolViewModelList = new List<SymbolViewModel>();
                
                foreach (Symbol symbol in symbolList)
                {
                    SymbolViewModel swm = new SymbolViewModel(symbol.Name, symbol.Ticker, symbol.Price, symbol.TypeName, symbol.ExchangeName);
                    symbolViewModelList.Add(swm);
                }

                BindingSource binding = new BindingSource();
                binding.DataSource = symbolViewModelList;
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
        }

        private void closeApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addSymbol_Click(object sender, EventArgs e)
        {
            AddSymbolForm addSymbolForm = new AddSymbolForm(symbolRepo, typeRepo, exchangeRepo);

            if (addSymbolForm.typeCb != null)
            {
                addSymbolForm.typeCb.Items.AddRange(typeRepo.typeList.Select(x => x.Name).ToArray());
                addSymbolForm.typeCb.SelectedIndex = 0;
            }

            if (addSymbolForm.exchangeCb != null)
            {
                addSymbolForm.exchangeCb.Items.AddRange(exchangeRepo.exchangeList.Select(x => x.Name).ToArray());
                addSymbolForm.exchangeCb.SelectedIndex = 0;
            }

            addSymbolForm.Show();
        }

        private void deleteSymbolButton_Click(object sender, EventArgs e)
        {
            string message = "Da li ste sigurni da zelite da obrisete Symbol(e)";
            string title = "Upozorenje";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        try
                        {
                            Symbol symbol = new Symbol();
                            symbol.Name = (string)row.Cells[0].Value;
                            symbol.Ticker = (string)row.Cells[1].Value;
                            symbol.Price = (double)row.Cells[2].Value;
                            symbol.TypeName = (string)row.Cells[3].Value;
                            symbol.ExchangeName = (string)row.Cells[4].Value;

                            bool ok = symbolRepo.deleteSymbol(symbol);

                            if (!ok)
                            {
                                MessageBox.Show("Doslo je do greske! " + symbol.Name + " nije obrisan.");
                            }
                            else
                                dataGridView1.Rows.RemoveAt(row.Index);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
            }
        }

        private void editSymbolBtn_Click(object sender, EventArgs e)
        {
            UpdateSymbolForm updateForm = new UpdateSymbolForm(symbolRepo, typeRepo, exchangeRepo);

            if (dataGridView1.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                    Symbol symbol = new Symbol();

                    symbol.Name = (string)row.Cells[0].Value;
                    symbol.Ticker = (string)row.Cells[1].Value;
                    symbol.Price = (double)row.Cells[2].Value;
                    symbol.TypeName = (string)row.Cells[3].Value;
                    symbol.ExchangeName = (string)row.Cells[4].Value;

                    symbol = symbolRepo.getSymbolByNameByTickerByPrice(symbol);

                    updateForm.id = symbol.Id;
                    updateForm.nameTb.Text = symbol.Name;
                    updateForm.tickerTb.Text = symbol.Ticker;
                    updateForm.isinTb.Text = symbol.Isin;
                    updateForm.currencyCodeTb.Text = symbol.CurrencyCode;
                    updateForm.priceTb.Text = symbol.Price.ToString();
                    updateForm.priceDateDp.Value = symbol.PriceDate;

                    updateForm.typeCb.Items.AddRange(typeRepo.typeList.Select(x => x.Name).ToArray());
                    updateForm.typeCb.SelectedItem = symbol.TypeName;

                    updateForm.exchangeCb.Items.AddRange(exchangeRepo.exchangeList.Select(x => x.Name).ToArray());
                    updateForm.exchangeCb.SelectedItem = symbol.ExchangeName;

                    updateForm.Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}