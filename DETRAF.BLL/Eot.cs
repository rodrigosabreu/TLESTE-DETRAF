using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DETRAF.BLL
{
    public class Eot
    {
        private int id;
        private int codEot;
        private string tipoServico;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int CodEot
        {
            get { return codEot; }
            set { codEot = value;}
        }
        public string TipoServico
        {
            get { return tipoServico; }
            set { tipoServico = value; }
        }

        public bool ProcessarEot(StreamReader objReader)
        {
            bool erro = false;
            string sLine = "";

            DETRAF.DAL.EotDal objEotDal = new DETRAF.DAL.EotDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (!string.IsNullOrEmpty(sLine))
                {
                    string[] campo = sLine.Split(new char[] { ';' });

                    try
                    {
                        CodEot = Convert.ToInt32(campo[0]);
                        TipoServico = campo[1];

                        objEotDal.GravarEot(CodEot, TipoServico);
                    }
                    catch (Exception ex)
                    {
                        erro = true;
                        objLogger.Gravar(@"C:/detraf/eot/critica-eot.txt", sLine.ToString() + " - " + ex.Message);
                    }

                }
            }

            objReader.Close();
            objReader.Dispose();

            objLogger = null;
            objEotDal = null;

            return erro;

        }
        
    }
}
