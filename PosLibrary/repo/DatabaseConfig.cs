using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.repo
{
    public static class DatabaseConfig
    {
        public static string DbPath = @"C:\Users\erdeneochirerka\Desktop\windowsPos\POS\PosForm\PosDatabase.db";
        public static string ConnectionString = $"Data Source={DbPath};";
    }
}
