using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTest.Models;

namespace WinFormsTest.Repository
{
    public class ExchangeRepository
    {
        private string selectedDbPath;
        private SQLiteConnection connect;
        public List<Exchange> exchangeList { get; set; }

        public ExchangeRepository(string selectedDbPath)
        {
            this.selectedDbPath = selectedDbPath;
            this.connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
            this.exchangeList = new List<Exchange>();
        }

        private void openConnection()
        {
            if (connect != null && connect.State == ConnectionState.Closed)
                connect.Open();
        }

        private void closeConnection()
        {
            if (connect != null && connect.State == ConnectionState.Open)
                connect.Close();
        }

        public List<Exchange> getAllExchanges()
        {
            try
            {
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandText = @"SELECT * FROM Exchange";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader rdr = fmd.ExecuteReader();

                while (rdr.Read())
                {
                    Exchange exchange = new Exchange();
                    exchange.Id = (int)(long)rdr["Id"];
                    exchange.Name = (string)rdr["Name"];

                    exchangeList.Add(exchange);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return exchangeList;
        }
    }
}
