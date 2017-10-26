using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DETRAF.DAL
{
    public class EotDal
    {
        public int GravarEot(int codEot, string tipoServico)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@EOT", codEot);
            p[1] = new SqlParameter("@TIPO_SERVICO", tipoServico);            
            return db.ExecuteNonQuery("GravarEot", p);
        }

        public DataTable ConsultarEot(string codEot)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@EOT", codEot);
            return db.ExecuteDataSet("ConsultarEot", p).Tables[0];
        }
    }
}
