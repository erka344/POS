using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosForm
{
    class DataBaseConnection
    {
        public static string DbPath = "\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\pos1.db\"";
        public static string connectionString = $"Data Source={DbPath};";
    }
}
