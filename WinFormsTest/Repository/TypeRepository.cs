using System.Data;
using System.Data.SQLite;
using Type = WinFormsTest.Models.Type;

namespace WinFormsTest.Repository
{
    public class TypeRepository
    {
        private SQLiteConnection connect;
        public List<Type> typeList { get; set; }

        public TypeRepository(string selectedDbPath)
        {
            this.connect = new SQLiteConnection(@"Data Source=" + selectedDbPath);
            this.typeList = new List<Type>();
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

        public List<Type> getAllTypes()
        {
            try
            {
                openConnection();

                SQLiteCommand fmd = connect.CreateCommand();
                fmd.CommandText = @"SELECT * FROM Type";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader rdr = fmd.ExecuteReader();

                while (rdr.Read())
                {
                    Type type = new Type();
                    type.Id = Convert.ToInt32(rdr["Id"]);
                    type.Name = (string)rdr["Name"];

                    typeList.Add(type);
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
            return typeList;
        }

    }
}
