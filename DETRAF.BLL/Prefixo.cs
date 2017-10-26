using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace DETRAF.BLL
{
    public class Prefixo
    {

        private int prefixoID;
        private string codPrefixo;
        private int codEot;
        private string localidade;

        public int PrefixoID
        {
            get { return prefixoID; }
            set { prefixoID = value; }
        }
        public string CodPrefixo
        {
            get { return codPrefixo; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    codPrefixo = value;
                else
                    throw new InvalidCastException("Prefixo incorreto");
            }
        }
        public int CodEot
        {
            get { return codEot; }
            set { codEot = value;}
        }        
        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        /// <summary>
        /// Método que recebe o arquivo txt de eot para ser processado
        /// O mesmo retorna um valor booleano que indica se teve criticas ou não
        /// </summary>
        /// <param name="objReader"></param>
        /// <returns></returns>
        public bool ProcessarPrefixo(StreamReader objReader)
        {            
            bool erro = false;
            string sLine = "";
                        
            DETRAF.DAL.PrefixoDal objPrefixoDal = new DETRAF.DAL.PrefixoDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (!string.IsNullOrEmpty(sLine))
                {
                    string[] campo = sLine.Split(new char[] { ';' });

                    try
                    {
                        CodPrefixo = campo[0];
                        CodEot = Convert.ToInt32(campo[1]);
                        Localidade = campo[2];

                        objPrefixoDal.GravarPrefixo(codPrefixo, CodEot, Localidade);
                    }
                    catch (Exception ex)
                    {
                        erro = true;
                        objLogger.Gravar(@"C:/detraf/eot/critica-prefixo.txt", sLine.ToString() + " - " + ex.Message);
                    }

                }
            }
            
            objReader.Close();
            objReader.Dispose();

            objLogger = null;
            objPrefixoDal = null;            

            return erro;

        }

    }
}
