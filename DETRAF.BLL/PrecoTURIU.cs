using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DETRAF.BLL
{
    public sealed class PrecoTURIU : Preco
    {
        public PrecoTURIU() { }

        public override bool Validar(string caminho)
        {
            string sLine = "";
            string[] campo;
            string mensagem;
            bool erro = false;

            StreamReader objReader = new StreamReader(caminho);
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (!string.IsNullOrEmpty(sLine))
                {
                    campo = sLine.Split(new char[] { ';' });
                    try
                    {
                        Eot = Convert.ToInt32(campo[0]);
                        ValorHorarioReduzido = Convert.ToDecimal(campo[1]);
                        ValorHorarioDiferenciado = Convert.ToDecimal(campo[2]);
                        ValorHorarioNormal = Convert.ToDecimal(campo[3]);                        
                        ValorHorarioSuperReduzido = Convert.ToDecimal(campo[4]);
                    }
                    catch (Exception ex)
                    {
                        erro = true;
                        mensagem = ex.Message;
                        objLogger.Gravar(@"C:/detraf/tabelas/critica-tabelas.txt", sLine.ToString() + " - TURIU - " + mensagem);
                    }
                }
            }

            return erro;
        }

        public override bool Processar(string caminho)
        {
            string sLine = "";
            string[] campo;
            string mensagem;
            bool erro = false;

            StreamReader objReader = new StreamReader(caminho);
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DETRAF.DAL.PrecoDal objPrecoDal = new DETRAF.DAL.PrecoDal();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (!string.IsNullOrEmpty(sLine))
                {
                    campo = sLine.Split(new char[] { ';' });
                    try
                    {
                        Eot = Convert.ToInt32(campo[0]);
                        ValorHorarioReduzido = Convert.ToDecimal(campo[1]);
                        ValorHorarioDiferenciado = Convert.ToDecimal(campo[2]);
                        ValorHorarioNormal = Convert.ToDecimal(campo[3]);                        
                        ValorHorarioSuperReduzido = Convert.ToDecimal(campo[4]);

                        objPrecoDal.GravarTURIU(Eot, ValorHorarioReduzido, ValorHorarioDiferenciado, ValorHorarioNormal, ValorHorarioSuperReduzido);

                    }
                    catch (Exception ex)
                    {
                        erro = true;
                        mensagem = ex.Message;                        
                    }
                }
            }
            objReader.Close();
            objReader.Dispose();

            objLogger = null;
            objPrecoDal = null;
            return erro;
        }

    }
}
