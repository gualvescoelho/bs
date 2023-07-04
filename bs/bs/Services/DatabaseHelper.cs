using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace bs.Services
{
    public static class DatabaseHelper
    {
        public static SQLiteConnection GetConnection(string database)
        {
            var dbName = database+".db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}
