using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DETRAF.DAL
{
    public class DetrafDal
    {
        public DataTable CalcularDetrafLocalDesbalanceamento(string dataInicial, string dataFinal, string eotOrigem, string eotDestino)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@EOT_DESTINO", eotDestino);
            return db.ExecuteDataSet("CalcularDetrafLocalLocal", p).Tables[0];
        }

        public DataTable CalcularDetrafLocalResumido(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, int tipo)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@EOT_DESTINO", eotDestino);
            if(tipo == 0)
                return db.ExecuteDataSet("CalcularDetrafLocalResumidoCredito", p).Tables[0];
            else
                return db.ExecuteDataSet("CalcularDetrafLocalResumidoDebito", p).Tables[0];
        }

        public DataTable CalcularDetrafNacionalResumidoCredito(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, int tipo)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@EOT_DESTINO", eotDestino);

            return db.ExecuteDataSet("CalcularDetrafNacionalResumidoCredito", p).Tables[0];          
        }

        public DataTable CalcularDetrafTransitoLocalResumidoDebito(string dataInicial, string dataFinal)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);            

            return db.ExecuteDataSet("CalcularDetrafTransitoLocalResumidoDebito", p).Tables[0];
        }

        public DataTable CalcularDetrafTransporteResumidoDebito(string dataInicial, string dataFinal)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);

            return db.ExecuteDataSet("CalcularDetrafTransporteResumidoDebito", p).Tables[0];
        }


        public DataTable CalcularDetrafLocalDetalhado(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, int tipo)
        {

            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@EOT_DESTINO", eotDestino);

            if (tipo == 0)
                return db.ExecuteDataSet("CalcularDetrafLocalDetalhadoCredito", p).Tables[0];
            else
                return db.ExecuteDataSet("CalcularDetrafLocalDetalhadoDebito", p).Tables[0];
        }


        public DataTable CalcularDetrafNacionalDetalhadoCredito(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, int tipo)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@EOT_DESTINO", eotDestino);

            return db.ExecuteDataSet("CalcularDetrafNacionalDetalhadoCredito", p).Tables[0];
        }

        public DataTable CalcularDetrafTransitoLocalDetalhadoDebito(string dataInicial, string dataFinal)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);

            return db.ExecuteDataSet("CalcularDetrafTransitoLocalDetalhadoDebito", p).Tables[0];
        }

        public DataTable CalcularDetrafTransporteDetalhadoDebito(string dataInicial, string dataFinal)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);

            return db.ExecuteDataSet("CalcularDetrafTransporteDetalhadoDebito", p).Tables[0];
        }
        
        public DataTable CalcularDetrafLocalBatimento(string dataInicial, string dataFinal, string eotOrigem, string eotDestino)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@EOT_DESTINO", eotDestino);

            return db.ExecuteDataSet("CalcularDetrafLocalBatimento", p).Tables[0];
        }

        public DataTable CalcularDetrafNacionalBatimento(string dataInicial, string dataFinal, string eotOrigem, string eotDestino)
        {
            DbManager db = new DbManager();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@DATA_INICIAL", dataInicial);
            p[1] = new SqlParameter("@DATA_FINAL", dataFinal);
            p[2] = new SqlParameter("@EOT_ORIGEM", eotOrigem);
            p[3] = new SqlParameter("@EOT_DESTINO", eotDestino);

            return db.ExecuteDataSet("CalcularDetrafNacionalBatimento", p).Tables[0];
        }

    }
}