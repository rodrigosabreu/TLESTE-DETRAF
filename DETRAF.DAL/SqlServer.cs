using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DETRAF.DAL
{
    public class SqlServer
    {
        private static SqlServer instance = null;

        private SqlServer() { }

        public static SqlServer getInstance()
        {
            if (instance == null)
                instance = new SqlServer();
            return instance;
        }

        public SqlConnection getConnection()
        {
            string conn = "Database=detraf;Server=172.27.72.236;Persist Security Info=True;User ID=TESTE;Password='TESTE';";
            //string conn = "Database=detraf;Server=172.28.82.13;Persist Security Info=True;User ID=TESTE;Password='TESTE';";
            //string conn = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=detraf;Persist Security Info=True;User ID=detraf;Password=master;Connection Timeout=0";
            
            return new SqlConnection(conn);
        }

    }

}