using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DETRAF.DAL
{
    public class CdrDal
    {
        public int GravarCdr(string clid, int eotOrigem, string localidadeOrigem, string dst, int eotDestino, string localidadeDestino, int billsec, string data, string hora, DateTime dataHora, int entrante, int sainte, string tipoLigacao, string modalidadeLigacao)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[14];
            p[0] = new SqlParameter("@CLID", clid);
            p[1] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[2] = new SqlParameter("@LOCALIDADE_ORIGEM", localidadeOrigem);
            p[3] = new SqlParameter("@DST",dst);
            p[4] = new SqlParameter("@EOT_DESTINO", eotDestino);
            p[5] = new SqlParameter("@LOCALIDADE_DESTINO", localidadeDestino);
            p[6] = new SqlParameter("@BILLSEC", billsec);
            p[7] = new SqlParameter("@DATA", data);
            p[8] = new SqlParameter("@HORA", hora);
            p[9] = new SqlParameter("@DATA_HORA", dataHora);
            p[10] = new SqlParameter("@ENTRANTE", entrante);
            p[11] = new SqlParameter("@SAINTE", sainte);
            p[12] = new SqlParameter("@TIPO_LIGACAO", tipoLigacao);
            p[13] = new SqlParameter("@MODALIDADE_LIGACAO", modalidadeLigacao);
            return db.ExecuteNonQuery("GravarCdr", p);
        }

        public int AtualizarCdr(int id, string clid, int eotOrigem, string localidadeOrigem, string dst, int eotDestino, string localidadeDestino, int billsec, string data, string hora, DateTime dataHora, int entrante, int sainte, string tipoLigacao, string modalidadeLigacao)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@ID", id);
            p[1] = new SqlParameter("@CLID", clid);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@LOCALIDADE_ORIGEM", localidadeOrigem);
            p[4] = new SqlParameter("@DST", dst);
            p[5] = new SqlParameter("@EOT_DESTINO", eotDestino);
            p[6] = new SqlParameter("@LOCALIDADE_DESTINO", localidadeDestino);
            p[7] = new SqlParameter("@BILLSEC", billsec);
            p[8] = new SqlParameter("@DATA", data);
            p[9] = new SqlParameter("@HORA", hora);
            p[10] = new SqlParameter("@DATA_HORA", dataHora);
            p[11] = new SqlParameter("@ENTRANTE", entrante);
            p[12] = new SqlParameter("@SAINTE", sainte);
            p[13] = new SqlParameter("@TIPO_LIGACAO", tipoLigacao);
            p[14] = new SqlParameter("@MODALIDADE_LIGACAO", modalidadeLigacao);
            return db.ExecuteNonQuery("AtualizarCdr", p);
        }

        public DataTable ConsultarTnPortado(string tn)
        {
            DbManagerPortabilidade db = new DbManagerPortabilidade();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@TN", tn);
            return db.ExecuteDataSet("ConsultarTnPortado", p).Tables[0];
        }

        public int ExcluirCdr(string dataInicial, string dataFinal)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            return db.ExecuteNonQuery("DeletarCdr", p);
        }

        public DataTable ConsultarEotCdr()
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[0];
            return db.ExecuteDataSet("ConsultarEotCdr", p).Tables[0];
        }

        public int AtualizarCdrEotOrigem(int id, int eotOrigem, string localidadeOrigem)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@ID", id);
            p[1] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[2] = new SqlParameter("@LOCALIDADE_ORIGEM", localidadeOrigem);
            return db.ExecuteNonQuery("AtualizarCdrEotOrigem", p);
        }

        public int AtualizarCdrEotDestino(int id, int eotDestino, string localidadeDestino)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@ID", id);            
            p[1] = new SqlParameter("@EOT_DESTINO", eotDestino);
            p[2] = new SqlParameter("@LOCALIDADE_DESTINO", localidadeDestino);
            return db.ExecuteNonQuery("AtualizarCdrEotDestino", p);
        }

    }
}