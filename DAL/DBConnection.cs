using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DBConnection
    {
        public static IConfiguration Configuration { get; set; }
        public static string DBPath = "UAT";
        public static string GetDBConnection()
        {
            return DBPath == "UAT" ? "Server = DESKTOP-AKASH\\SQLEXPRESS; Database =TestDB;Trusted_Connection=True;"
                : "Server = DESKTOP-AKASH\\SQLEXPRESS; Database =TestDB;Trusted_Connection=True;";
        }
    }
}
