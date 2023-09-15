using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WinFormsTest.Models;

namespace WinFormsTest.Repository
{
    public class SymbolRepository
    {
        private string selectedDbPath;
        private SQLiteConnection connect;

        public SymbolRepository(string selectedDbPath)
        {
            this.selectedDbPath = selectedDbPath;
            this.connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
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

        public List<Symbol> getFilteredSymbols(string type, string exchange)
        {
            List<Symbol> symbolList = new List<Symbol>();
            try
            {
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandText = createQuery(type, exchange);
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader rdr = fmd.ExecuteReader();

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

                    symbolList.Add(symbol);

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

            return symbolList;
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

        public bool deleteSymbol(Symbol symbol)
        {
            try
            {
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandType = CommandType.Text;
                fmd.CommandText = @"DELETE FROM Symbol WHERE Name = '" + symbol.Name + "' AND Ticker = '" + symbol.Ticker + "' AND " +
                                    "Price = @Price";
                fmd.Parameters.AddWithValue("@Price", symbol.Price);

                int rows = fmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    closeConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return true;
        }

        public bool createNewSymbol(Symbol symbol)
        {
            try
            {
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

                if (rows != 1)
                {
                    closeConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return true;
        }

        public Symbol getSymbolByNameByTickerByPrice(Symbol symbol)
        {
            try
            {
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandType = CommandType.Text;
                fmd.CommandText = @"SELECT * FROM Symbol WHERE Name = '" + symbol.Name + "' AND Ticker = '" + symbol.Ticker + "' AND " +
                                    "Price = @Price";
                fmd.Parameters.AddWithValue("@Price", symbol.Price);

                SQLiteDataReader rdr = fmd.ExecuteReader();

                if (rdr.Read())
                {
                    symbol.Id = (int)(long)rdr["Id"];
                    symbol.Isin = (string)rdr["Isin"];
                    symbol.CurrencyCode = (string)rdr["CurrencyCode"];
                    symbol.PriceDate = (DateTime)rdr["PriceDate"];
                    symbol.TypeId = (int)rdr["TypeId"];
                    symbol.ExchangeId = (int)rdr["ExchangeId"];
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

            return symbol;
        }

        public bool updateSymbol(Symbol symbol)
        {
            try
            {
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandType = CommandType.Text;
                fmd.CommandText = @"UPDATE Symbol " +
                                        "SET Name = @Name, Ticker = @Ticker, Isin = @Isin, CurrencyCode = @CurrencyCode, " + 
                                        "DateAdded = @DateAdded, Price = @Price, PriceDate = @PriceDate, " + 
                                        "TypeId = @TypeId, ExchangeId = @ExchangeId " + 
                                    "WHERE Id = @Id";
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

                if (rows != 1)
                {
                    closeConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                closeConnection();
            }

            return true;
        }
    }
}
