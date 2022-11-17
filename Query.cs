using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadComPort
{
    internal class Query
    {
        public static readonly string createMainTable = "CREATE TABLE IF NOT EXISTS \"ComDatas\" " +
            "(\"id\" INTEGER PRIMARY KEY,\"date\" TEXT,\"comdata\"TEXT)";
        public static string insertData = "INSERT INTO ComDatas (\'date\', \'comdata\') VALUES ({0}, {1})";
    }
}
