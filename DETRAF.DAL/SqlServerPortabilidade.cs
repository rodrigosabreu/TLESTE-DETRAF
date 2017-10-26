using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DETRAF.DAL
{
    public class SqlServerPortabilidade
    {
        private static SqlServerPortabilidade instance = null;

        private SqlServerPortabilidade() { }

        public static SqlServerPortabilidade getInstance()
        {
            if (instance == null)
                instance = new SqlServerPortabilidade();
            return instance;
        }

        public SqlConnection getConnection()
        {
            string conn = "Database=portabilidade;Server=172.27.72.236;Persist Security Info=True;User ID=TESTE;Password='TESTE';";
            //string conn = "Database=portabilidade;Server=172.28.82.13;Persist Security Info=True;User ID=TESTE;Password='TESTE';";
            //string conn = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=portabilidade;Persist Security Info=True;User ID=detraf;Password=master;Connection Timeout=0";
            return new SqlConnection(conn);
        }

    }

}