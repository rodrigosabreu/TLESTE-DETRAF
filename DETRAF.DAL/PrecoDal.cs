using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DETRAF.DAL
{
    public class PrecoDal
    {
        public int GravarTURL(int codEot, decimal valor_horario_normal, decimal valor_horario_reduzido)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@EOT", codEot);
            p[1] = new SqlParameter("@VALOR_HORARIO_NORMAL", valor_horario_normal);
            p[2] = new SqlParameter("@VALOR_HORARIO_REDUZIDO", valor_horario_reduzido);
            return db.ExecuteNonQuery("GravarTURL", p);
        }

        public int GravarVUM(int codEot, decimal valor_horario_normal, decimal valor_horario_reduzido)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@EOT", codEot);
            p[1] = new SqlParameter("@VALOR_HORARIO_NORMAL", valor_horario_normal);
            p[2] = new SqlParameter("@VALOR_HORARIO_REDUZIDO", valor_horario_reduzido);
            return db.ExecuteNonQuery("GravarVUM", p);
        }

        public int GravarTURIU(int codEot, decimal valor_horario_reduzido, decimal valor_horario_diferenciado, decimal valor_horario_normal, decimal valor_horario_super_reduzido)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@EOT", codEot);
            p[1] = new SqlParameter("@VALOR_HORARIO_REDUZIDO", valor_horario_reduzido);
            p[2] = new SqlParameter("@VALOR_HORARIO_DIFERENCIADO", valor_horario_diferenciado);
            p[3] = new SqlParameter("@VALOR_HORARIO_NORMAL", valor_horario_normal);
            p[4] = new SqlParameter("@VALOR_HORARIO_SUPER_REDUZIDO", valor_horario_super_reduzido);
            return db.ExecuteNonQuery("GravarTURIU", p);
        }

        public int GravarVUT(int codEot, decimal valor_horario_normal, decimal valor_horario_reduzido)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@EOT", codEot);
            p[1] = new SqlParameter("@VALOR_HORARIO_NORMAL", valor_horario_normal);
            p[2] = new SqlParameter("@VALOR_HORARIO_REDUZIDO", valor_horario_reduzido);
            return db.ExecuteNonQuery("GravarVUT", p);
        }

        public DataTable ConsultarTabela(int eot, string tabela)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@EOT", eot);
            p[1] = new SqlParameter("@TABELA", tabela);
            return db.ExecuteDataSet("ConsultarTabela", p).Tables[0];
        }

    }
}
