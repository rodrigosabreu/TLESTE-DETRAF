using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DETRAF.DAL
{
    public class PrefixoDal
    {
        public int GravarPrefixo(string codPrefixo, int codEot, string localidade)
        {   
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@PREFIXO", codPrefixo);
            p[1] = new SqlParameter("@EOT", codEot);
            p[2] = new SqlParameter("@LOCALIDADE", localidade);
            return db.ExecuteNonQuery("GravarPrefixo", p);
        }
        
        public DataTable ConsultarPrefixo(string codPrefixo)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@PREFIXO", codPrefixo);           
            return db.ExecuteDataSet("ConsultarPrefixo", p).Tables[0];
        }

    }
}
