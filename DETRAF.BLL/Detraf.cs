using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DETRAF.DAL;

namespace DETRAF.BLL
{
    public class Detraf
    {
        private double creditoHorarioNormal;
        private double debitoHorarioNormal;
        private double totalHorarioNormal;
        private double limiteSuperiorNormal;
        private double excessoNormal;
        private double valorBrutoNormal;
        private double creditoHorarioReduzido;
        private double debitoHorarioReduzido;
        private double totalHorarioReduzido;
        private double limiteSuperiorReduzido;
        private double excessoReduzido;
        private double valorBrutoReduzido;
        private double valorHorarioNormal;
        private double valorHorarioReduzido;
        private int eotDevedorNormal;
        private int eotDevedorReduzido;

        public double CreditoHorarioNormal
        {
            get { return creditoHorarioNormal; }
            set { creditoHorarioNormal = Math.Round(value, 2); }
        }
        public double DebitoHorarioNormal
        {
            get { return debitoHorarioNormal; }
            set { debitoHorarioNormal = Math.Round(value, 2); }
        }
        public double TotalHorarioNormal
        {
            get { return totalHorarioNormal; }
            set { totalHorarioNormal = Math.Round(value, 2); }
        }
        public double LimiteSuperiorNormal
        {
            get { return limiteSuperiorNormal; }
            set { limiteSuperiorNormal = Math.Round(value, 2); }
        }
        public double ExcessoNormal
        {
            get { return excessoNormal; }
            set { excessoNormal = Math.Round(value, 2); }
        }
        public double CreditoHorarioReduzido
        {
            get { return creditoHorarioReduzido; }
            set { creditoHorarioReduzido = Math.Round(value, 2); }
        }
        public double DebitoHorarioReduzido
        {
            get { return debitoHorarioReduzido; }
            set { debitoHorarioReduzido = Math.Round(value, 2); }
        }
        public double TotalHorarioReduzido
        {
            get { return totalHorarioReduzido; }
            set { totalHorarioReduzido = Math.Round(value, 2); }
        }
        public double LimiteSuperiorReduzido
        {
            get { return limiteSuperiorReduzido; }
            set { limiteSuperiorReduzido = Math.Round(value, 2); }
        }
        public double ExcessoReduzido
        {
            get { return excessoReduzido; }
            set { excessoReduzido = Math.Round(value,2); }
        }
        public double ValorBrutoNormal
        {
            get { return valorBrutoNormal; }
            set { valorBrutoNormal = Math.Round(value,2); }
        }
        public double ValorBrutoReduzido
        {
            get { return valorBrutoReduzido; }
            set { valorBrutoReduzido = Math.Round(value,2); }
        }
        public double ValorHorarioNormal
        {
            get { return valorHorarioNormal; }
            set { valorHorarioNormal = value; }
        }
        public double ValorHorarioReduzido
        {
            get { return valorHorarioReduzido; }
            set { valorHorarioReduzido = value; }
        }
        public int EotDevedorNormal
        {
            get { return eotDevedorNormal; }
            set { eotDevedorNormal = value; }
        }
        public int EotDevedorReduzido
        {
            get { return eotDevedorReduzido; }
            set { eotDevedorReduzido = value; }
        }

        public void CalcularDetrafLocalDesbalanceamento(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, modalidadeLigacao ModalidadeLigacao, tipoDetraf TipoDetraf)
        {
            DataTable dt = null;
            DetrafDal objDetrafDal = new DetrafDal();
            PrecoDal objPrecoDal = new PrecoDal();   

            //Local Local = Desbalanceamento
            dt = objDetrafDal.CalcularDetrafLocalDesbalanceamento(dataInicial, dataFinal, eotOrigem, eotDestino);
            double segundos_normal_credito = 0;
            double segundos_reduzido_credito = 0;
            double segundos_normal_debito = 0;
            double segundos_reduzido_debito = 0;
            
            foreach (DataRow dr in dt.Rows)
            {
                segundos_normal_credito = Convert.ToDouble(dr["normal_credito"]);
                segundos_reduzido_credito = Convert.ToDouble(dr["reduzido_credito"]);

                segundos_normal_debito = Convert.ToDouble(dr["normal_debito"]);
                segundos_reduzido_debito = Convert.ToDouble(dr["reduzido_debito"]);
            }

            double minutos_normal_credito = Math.Round(segundos_normal_credito / 60, 2);
            double minutos_normal_debito = Math.Round(segundos_normal_debito / 60, 2);
            double total_minutos_normal = Math.Round(minutos_normal_credito + minutos_normal_debito, 2);
            double limite_superior_normal = Math.Round(total_minutos_normal * 0.55, 2);

            double excesso_limite_superior_normal = 0;
            int eot_turl_normal;
            int eot_turl_reduzido;

            if (minutos_normal_debito <= minutos_normal_credito)
            {
                eot_turl_normal = Convert.ToInt32(eotOrigem);
                excesso_limite_superior_normal = minutos_normal_credito - limite_superior_normal;

                dt = objPrecoDal.ConsultarTabela(eot_turl_normal, "tabela_turl");
                foreach (DataRow dr in dt.Rows)
                {
                    ValorHorarioNormal = Convert.ToDouble(dr["valor_horario_normal"]);                    
                }
                EotDevedorNormal = Convert.ToInt32(eotDestino);

            }
            else
            {
                eot_turl_normal = Convert.ToInt32(eotDestino);
                excesso_limite_superior_normal = minutos_normal_debito - limite_superior_normal;

                dt = objPrecoDal.ConsultarTabela(eot_turl_normal, "tabela_turl");
                foreach (DataRow dr in dt.Rows)
                {
                    ValorHorarioNormal = Convert.ToDouble(dr["valor_horario_normal"]);                    
                }
                EotDevedorNormal = Convert.ToInt32(eotOrigem);
            }

            double minutos_reduzido_credito = segundos_reduzido_credito / 60;
            double minutos_reduzido_debito = segundos_reduzido_debito / 60;
            double total_minutos_reduzido = minutos_reduzido_credito + minutos_reduzido_debito;
            double limite_superior_reduzido = total_minutos_reduzido * 0.55;

            double excesso_limite_superior_reduzido = 0;                             

            if (minutos_reduzido_debito <= minutos_reduzido_credito)
            {
                eot_turl_reduzido = Convert.ToInt32(eotOrigem);
                excesso_limite_superior_reduzido = minutos_reduzido_credito - limite_superior_reduzido;
                                
                dt = objPrecoDal.ConsultarTabela(eot_turl_reduzido, "tabela_turl");
                foreach (DataRow dr in dt.Rows)
                {                    
                    ValorHorarioReduzido = Convert.ToDouble(dr["valor_horario_reduzido"]);
                }
                EotDevedorReduzido = Convert.ToInt32(eotDestino);

            }
            else
            {
                eot_turl_reduzido = Convert.ToInt32(eotDestino);
                excesso_limite_superior_reduzido = minutos_reduzido_debito - limite_superior_reduzido;
                                
                dt = objPrecoDal.ConsultarTabela(eot_turl_reduzido, "tabela_turl");
                foreach (DataRow dr in dt.Rows)
                {                   
                    ValorHorarioReduzido = Convert.ToDouble(dr["valor_horario_reduzido"]);
                }
                EotDevedorReduzido = Convert.ToInt32(eotOrigem);

            }

            CreditoHorarioNormal = minutos_normal_credito;
            DebitoHorarioNormal = minutos_normal_debito;
            TotalHorarioNormal = total_minutos_normal;
            LimiteSuperiorNormal = limite_superior_normal;
            ExcessoNormal = excesso_limite_superior_normal;
            ValorBrutoNormal = ExcessoNormal * ValorHorarioNormal;

            CreditoHorarioReduzido = minutos_reduzido_credito;
            DebitoHorarioReduzido = minutos_reduzido_debito;
            TotalHorarioReduzido = total_minutos_reduzido;
            LimiteSuperiorReduzido = limite_superior_reduzido;
            ExcessoReduzido = excesso_limite_superior_reduzido;
            ValorBrutoReduzido = ExcessoReduzido * ValorHorarioReduzido;

            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            string linha = "";
            linha = "Creditos Minutos Normal;" + CreditoHorarioNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Debitos Minutos Normal;" + DebitoHorarioNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Total Normal;" + TotalHorarioNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Limite Superior Normal;" + LimiteSuperiorNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Excesso Normal;" + ExcessoNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Tarifa Normal;" + ValorHorarioNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Valor Bruto Normal;" + ValorBrutoNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "EOT Devedor Normal;" + EotDevedorNormal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "";
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Creditos Minutos Reduzido;" + CreditoHorarioReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Debitos Minutos Reduzido;" + DebitoHorarioReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Total Reduzido;" + TotalHorarioReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Limite Superior Reduzido;" + LimiteSuperiorReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Excesso Reduzido;" + ExcessoReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Tarifa Reduzido;" + ValorHorarioReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "Valor Bruto Reduzido;" + ValorBrutoReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);
            linha = "EOT Devedor Reduzido;" + EotDevedorReduzido.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafLocalDesbalanceamento.csv", linha);

            objLogger = null;
            objDetrafDal = null;
            objPrecoDal = null;
        }

        public void CalcularDetrafLocalResumido(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, modalidadeLigacao ModalidadeLigacao, tipoDetraf TipoDetraf, int tipo)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafLocalResumido(dataInicial, dataFinal, eotOrigem, eotDestino, tipo);

            string nome_arquivo = "DetrafLocalResumidoCredito";
            if (tipo > 0)
                nome_arquivo = "DetrafLocalResumidoDebito";

            string eotCredor="";
            string eotDevedor = "";
            string periodoRef = "";
            string periodoTraf = "";
            string poi = "";
            string tipoRelatorio = "";
            string descriptor = "";
            string grupoHorario = "";
            string mensagem = "";

            string tarifa;
            string qtdChamadas;
            string duracaoSegundos;
            string valorLiquido;
            string valorImposto;
            string valorBruto;

            double qtdChamadasAux;
            double duracaoSegundosAux;
            decimal valorLiquidoAux;
            decimal valorImpostoAux;
            decimal valorBrutoAux;

            double qtdChamadasTotal = 0;
            double duracaoSegundosTotal = 0;
            decimal valorLiquidoTotal = 0;
            decimal valorImpostoTotal = 0;
            decimal valorBrutoTotal = 0;           

            foreach (DataRow dr in dt.Rows)
            {

                eotCredor       = dr["EOT_CREDOR"].ToString();
                eotDevedor      = dr["EOT_DEVEDOR"].ToString();
                periodoRef      = dr["PERIODO_REF"].ToString();
                periodoTraf     = dr["PERIODO_TRAF"].ToString();
                poi             = dr["POI"].ToString();
                tipoRelatorio   = dr["TIPO_RELATORIO"].ToString();
                descriptor      = dr["DESCRIPTOR"].ToString();
                grupoHorario    = dr["GRUPO_HORARIO"].ToString();
                tarifa          = dr["TARIFA"].ToString();
                qtdChamadas     = dr["QTD_CHAMADAS"].ToString();
                duracaoSegundos = dr["DURACAO_SEGUNDOS"].ToString();
                valorLiquido    = dr["VALOR_LIQUIDO"].ToString();
                valorImposto    = dr["VALOR_IMPOSTO"].ToString();
                valorBruto      = dr["VALOR_BRUTO"].ToString();
                                
                qtdChamadasAux = Convert.ToDouble(qtdChamadas);
                duracaoSegundosAux = Convert.ToDouble(duracaoSegundos)/60;
                valorLiquidoAux = Convert.ToDecimal(valorLiquido);
                valorImpostoAux = Convert.ToDecimal(valorImposto);
                valorBrutoAux = Convert.ToDecimal(valorBruto);

                mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";" + poi + ";" + tipoRelatorio + ";" + descriptor + ";" + grupoHorario + ";" + qtdChamadas.ToString() + ";" + duracaoSegundosAux.ToString() + ";" + tarifa + ";" + valorLiquido.ToString() + ";" + valorImposto.ToString() + ";" + valorBruto.ToString();
                objLogger.GravarCSV(@"C:/detraf/resumido/"+nome_arquivo+".csv", mensagem);

                qtdChamadasTotal += qtdChamadasAux;
                duracaoSegundosTotal += duracaoSegundosAux;
                valorLiquidoTotal += valorLiquidoAux;
                valorImpostoTotal += valorImpostoAux;
                valorBrutoTotal += valorBrutoAux;                    
               

            }
            mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";" + poi + ";1;;;" + qtdChamadasTotal.ToString() + ";" + duracaoSegundosTotal.ToString() + ";;" + valorLiquidoTotal.ToString() + ";" + valorImpostoTotal.ToString() + ";" + valorBrutoTotal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/" + nome_arquivo + ".csv", mensagem);

            objDetrafDal = null;
            objLogger = null;
            dt = null;
        }

        public void CalcularDetrafNacionalResumidoCredito(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, modalidadeLigacao ModalidadeLigacao, tipoDetraf TipoDetraf, int tipo)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafNacionalResumidoCredito(dataInicial, dataFinal, eotOrigem, eotDestino, tipo);

            string eotCredor = "";
            string eotDevedor = "";
            string periodoRef = "";
            string periodoTraf = "";
            string poi = "";
            string tipoRelatorio = "";
            string descriptor = "";
            string grupoHorario = "";
            string mensagem = "";

            string tarifa;
            string qtdChamadas;
            string duracaoSegundos;
            string valorLiquido;
            string valorImposto;
            string valorBruto;

            double qtdChamadasAux;
            double duracaoSegundosAux;
            decimal valorLiquidoAux;
            decimal valorImpostoAux;
            decimal valorBrutoAux;

            double qtdChamadasTotal = 0;
            double duracaoSegundosTotal = 0;
            decimal valorLiquidoTotal = 0;
            decimal valorImpostoTotal = 0;
            decimal valorBrutoTotal = 0;

            foreach (DataRow dr in dt.Rows)
            {

                eotCredor = dr["EOT_CREDOR"].ToString();
                eotDevedor = dr["EOT_DEVEDOR"].ToString();
                periodoRef = dr["PERIODO_REF"].ToString();
                periodoTraf = dr["PERIODO_TRAF"].ToString();
                poi = dr["POI"].ToString();
                tipoRelatorio = dr["TIPO_RELATORIO"].ToString();
                descriptor = dr["DESCRIPTOR"].ToString();
                grupoHorario = dr["GRUPO_HORARIO"].ToString();
                tarifa = dr["TARIFA"].ToString();
                qtdChamadas = dr["QTD_CHAMADAS"].ToString();
                duracaoSegundos = dr["DURACAO_SEGUNDOS"].ToString();
                valorLiquido = dr["VALOR_LIQUIDO"].ToString();
                valorImposto = dr["VALOR_IMPOSTO"].ToString();
                valorBruto = dr["VALOR_BRUTO"].ToString();

                qtdChamadasAux = Convert.ToDouble(qtdChamadas);
                duracaoSegundosAux = Convert.ToDouble(duracaoSegundos) / 60;
                valorLiquidoAux = Convert.ToDecimal(valorLiquido);
                valorImpostoAux = Convert.ToDecimal(valorImposto);
                valorBrutoAux = Convert.ToDecimal(valorBruto);

                mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";" + poi + ";" + tipoRelatorio + ";" + descriptor + ";" + grupoHorario + ";" + qtdChamadas.ToString() + ";" + duracaoSegundosAux.ToString() + ";" + tarifa + ";" + valorLiquido.ToString() + ";" + valorImposto.ToString() + ";" + valorBruto.ToString();
                objLogger.GravarCSV(@"C:/detraf/resumido/DetrafNacionalResumidoCredito.csv", mensagem);

                qtdChamadasTotal += qtdChamadasAux;
                duracaoSegundosTotal += duracaoSegundosAux;
                valorLiquidoTotal += valorLiquidoAux;
                valorImpostoTotal += valorImpostoAux;
                valorBrutoTotal += valorBrutoAux;
            }

            mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";" + poi + ";1;;;" + qtdChamadasTotal.ToString() + ";" + duracaoSegundosTotal.ToString() + ";;" + valorLiquidoTotal.ToString() + ";" + valorImpostoTotal.ToString() + ";" + valorBrutoTotal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafNacionalResumidoCredito.csv", mensagem);

            objDetrafDal = null;
            objLogger = null;
            dt = null;
        }

        public void CalcularDetrafTransitoLocalResumidoDebito(string dataInicial, string dataFinal)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafTransitoLocalResumidoDebito(dataInicial, dataFinal);

            string eotCredor = "";
            string eotDevedor = "";
            string periodoRef = "";
            string periodoTraf = "";
            string poi = "";
            string tipoRelatorio = "";
            string descriptor = "";
            string grupoHorario = "";
            string mensagem = "";

            string tarifa;
            string qtdChamadas;
            string duracaoSegundos;
            string valorLiquido;
            string valorImposto;
            string valorIcms;
            string valorBruto;
            string eot_ponta;

            double qtdChamadasAux;
            double duracaoSegundosAux;
            decimal valorLiquidoAux;
            decimal valorImpostoAux;
            decimal valorBrutoAux;

            double qtdChamadasTotal = 0;
            double duracaoSegundosTotal = 0;
            decimal valorLiquidoTotal = 0;
            decimal valorImpostoTotal = 0;
            decimal valorBrutoTotal = 0;

            foreach (DataRow dr in dt.Rows)
            {

                eotCredor = dr["EOT_CREDOR"].ToString();
                eotDevedor = dr["EOT_DEVEDOR"].ToString();
                periodoRef = dr["PERIODO_REF"].ToString();
                periodoTraf = dr["PERIODO_TRAF"].ToString();
                poi = dr["POI"].ToString();
                tipoRelatorio = dr["TIPO_RELATORIO"].ToString();
                descriptor = dr["DESCRIPTOR"].ToString();
                grupoHorario = dr["GRUPO_HORARIO"].ToString();
                tarifa = dr["TARIFA"].ToString();
                qtdChamadas = dr["QTD_CHAMADAS"].ToString();
                duracaoSegundos = dr["DURACAO_SEGUNDOS"].ToString();
                valorLiquido = dr["VALOR_LIQUIDO"].ToString();
                valorIcms = dr["VALOR_ICMS"].ToString();
                valorImposto = dr["VALOR_IMPOSTO"].ToString();
                valorBruto = dr["VALOR_BRUTO"].ToString();
                eot_ponta = dr["EOT_PONTA"].ToString();

                qtdChamadasAux = Convert.ToDouble(qtdChamadas);
                duracaoSegundosAux = Convert.ToDouble(duracaoSegundos) / 60;
                valorLiquidoAux = Convert.ToDecimal(valorLiquido);
                valorImpostoAux = Convert.ToDecimal(valorImposto);
                valorBrutoAux = Convert.ToDecimal(valorBruto);

                mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";" + poi + ";" + tipoRelatorio + ";" + descriptor + ";" + grupoHorario + ";" + qtdChamadas.ToString() + ";" + duracaoSegundosAux.ToString() + ";" + tarifa + ";" + valorIcms + ";" + valorLiquido.ToString() + ";" + valorImposto.ToString() + ";" + valorBruto.ToString() + ";" + eot_ponta;
                objLogger.GravarCSV(@"C:/detraf/resumido/DetrafTransitoLocalResumidoDebito.csv", mensagem);

                qtdChamadasTotal += qtdChamadasAux;
                duracaoSegundosTotal += duracaoSegundosAux;
                valorLiquidoTotal += valorLiquidoAux;
                valorImpostoTotal += valorImpostoAux;
                valorBrutoTotal += valorBrutoAux;
            }

            mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";;1;;;" + qtdChamadasTotal.ToString() + ";" + duracaoSegundosTotal.ToString() + ";;" + valorLiquidoTotal.ToString() +";" +valorImpostoTotal.ToString() + ";0.00000;" +  valorBrutoTotal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafTransitoLocalResumidoDebito.csv", mensagem);

            objDetrafDal = null;
            objLogger = null;
            dt = null;
        }

        public void CalcularDetrafTransporteResumidoDebito(string dataInicial, string dataFinal)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafTransporteResumidoDebito(dataInicial, dataFinal);

            string eotCredor = "";
            string eotDevedor = "";
            string periodoRef = "";
            string periodoTraf = "";
            string poi = "";
            string tipoRelatorio = "";
            string descriptor = "";
            string grupoHorario = "";
            string mensagem = "";

            string tarifa;
            string qtdChamadas;
            string duracaoSegundos;
            string valorLiquido;
            string valorImposto;
            string valorIcms;
            string valorBruto;
            string eot_ponta;

            double qtdChamadasAux;
            double duracaoSegundosAux;
            decimal valorLiquidoAux;
            decimal valorImpostoAux;
            decimal valorBrutoAux;

            double qtdChamadasTotal = 0;
            double duracaoSegundosTotal = 0;
            decimal valorLiquidoTotal = 0;
            decimal valorImpostoTotal = 0;
            decimal valorBrutoTotal = 0;

            foreach (DataRow dr in dt.Rows)
            {

                eotCredor = dr["EOT_CREDOR"].ToString();
                eotDevedor = dr["EOT_DEVEDOR"].ToString();
                periodoRef = dr["PERIODO_REF"].ToString();
                periodoTraf = dr["PERIODO_TRAF"].ToString();
                poi = dr["POI"].ToString();
                tipoRelatorio = dr["TIPO_RELATORIO"].ToString();
                descriptor = dr["DESCRIPTOR"].ToString();
                grupoHorario = dr["GRUPO_HORARIO"].ToString();
                tarifa = dr["TARIFA"].ToString();
                qtdChamadas = dr["QTD_CHAMADAS"].ToString();
                duracaoSegundos = dr["DURACAO_SEGUNDOS"].ToString();
                valorLiquido = dr["VALOR_LIQUIDO"].ToString();
                valorIcms = dr["VALOR_ICMS"].ToString();
                valorImposto = dr["VALOR_IMPOSTO"].ToString();
                valorBruto = dr["VALOR_BRUTO"].ToString();
                eot_ponta = dr["EOT_PONTA"].ToString();

                qtdChamadasAux = Convert.ToDouble(qtdChamadas);
                duracaoSegundosAux = Convert.ToDouble(duracaoSegundos) / 60;
                valorLiquidoAux = Convert.ToDecimal(valorLiquido);
                valorImpostoAux = Convert.ToDecimal(valorImposto);
                valorBrutoAux = Convert.ToDecimal(valorBruto);

                mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";" + poi + ";" + tipoRelatorio + ";" + descriptor + ";" + grupoHorario + ";" + qtdChamadas.ToString() + ";" + duracaoSegundosAux.ToString() + ";" + tarifa + ";" + valorLiquido.ToString() + ";" + valorImposto.ToString() + ";" + valorIcms + ";" + valorBruto.ToString() + ";" + eot_ponta;
                objLogger.GravarCSV(@"C:/detraf/resumido/DetrafTransporteResumidoDebito.csv", mensagem);

                qtdChamadasTotal += qtdChamadasAux;
                duracaoSegundosTotal += duracaoSegundosAux;
                valorLiquidoTotal += valorLiquidoAux;
                valorImpostoTotal += valorImpostoAux;
                valorBrutoTotal += valorBrutoAux;
            }

            mensagem = eotCredor + ";" + eotDevedor + ";" + periodoRef + ";" + periodoTraf + ";;1;;;" + qtdChamadasTotal.ToString() + ";" + duracaoSegundosTotal.ToString() + ";;" + valorLiquidoTotal.ToString() +";"+ valorImpostoTotal.ToString() + ";0.00000;" + valorBrutoTotal.ToString();
            objLogger.GravarCSV(@"C:/detraf/resumido/DetrafTransporteResumidoDebito.csv", mensagem);

            objDetrafDal = null;
            objLogger = null;
            dt = null;
        }

        public void CalcularDetrafLocalDetalhado(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, modalidadeLigacao ModalidadeLigacao, tipoDetraf TipoDetraf, int tipo)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafLocalDetalhado(dataInicial, dataFinal, eotOrigem, eotDestino, tipo);

            string nome_arquivo = "DetrafLocalDetalhadoCredito";
            if (tipo > 0) 
                nome_arquivo = "DetrafLocalDetalhadoDebito";

            string mensagem = "";
            string clid = "";
            string eot_origem = "";
            string localidade_origem = "";
            string dst = "";
            string eot_destino = "";
            string localidade_destino = "";
            string billsec = "";
            string data = "";
            string hora = "";
            string entrante = "";
            string sainte = "";
            string tipo_ligacao = "";
            string modalidade_ligacao = "";
            string billsec_cobrado = "";
            string tarifa = "";
            string valor_cobrado = "";

            foreach (DataRow dr in dt.Rows)
            {

                clid               = dr["clid"].ToString();
                eot_origem         = dr["eot_origem"].ToString();
                localidade_origem  = dr["localidade_origem"].ToString();
                dst                = dr["dst"].ToString();
                eot_destino        = dr["eot_destino"].ToString();
                localidade_destino = dr["localidade_destino"].ToString();
                billsec            = dr["billsec"].ToString();
                data               = dr["data"].ToString();
                hora               = dr["hora"].ToString();
                entrante           = dr["entrante"].ToString();
                sainte             = dr["sainte"].ToString();
                tipo_ligacao       = dr["tipo_ligacao"].ToString();
                modalidade_ligacao = dr["modalidade_ligacao"].ToString();
                billsec_cobrado    = dr["billsec_cobrado"].ToString();
                tarifa             = dr["tarifa"].ToString();
                valor_cobrado      = dr["valor"].ToString();

                mensagem = clid + ";" + eot_origem+";"+localidade_origem+";"+dst+";"+eot_destino+";"+localidade_destino+";"+billsec+";"+data+";"+hora+";"+entrante+";"+sainte+";"+tipo_ligacao+";"+modalidade_ligacao+";"+billsec_cobrado+";"+tarifa+";"+valor_cobrado;

                objLogger.GravarCSV(@"C:/detraf/detalhado/"+nome_arquivo+".csv", mensagem);

            }

            objDetrafDal = null;
            objLogger = null;
            dt = null;
        }

        public void CalcularDetrafNacionalDetalhadoCredito(string dataInicial, string dataFinal, string eotOrigem, string eotDestino, modalidadeLigacao ModalidadeLigacao, tipoDetraf TipoDetraf, int tipo)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafNacionalDetalhadoCredito(dataInicial, dataFinal, eotOrigem, eotDestino, tipo);

            string mensagem = "";
            string clid = "";
            string eot_origem = "";
            string localidade_origem = "";
            string dst = "";
            string eot_destino = "";
            string localidade_destino = "";
            string billsec = "";
            string data = "";
            string hora = "";
            string entrante = "";
            string sainte = "";
            string tipo_ligacao = "";
            string modalidade_ligacao = "";
            string billsec_cobrado = "";
            string tarifa = "";
            string valor_cobrado = "";

            foreach (DataRow dr in dt.Rows)
            {
                clid = dr["clid"].ToString();
                eot_origem = dr["eot_origem"].ToString();
                localidade_origem = dr["localidade_origem"].ToString();
                dst = dr["dst"].ToString();
                eot_destino = dr["eot_destino"].ToString();
                localidade_destino = dr["localidade_destino"].ToString();
                billsec = dr["billsec"].ToString();
                data = dr["data"].ToString();
                hora = dr["hora"].ToString();
                entrante = dr["entrante"].ToString();
                sainte = dr["sainte"].ToString();
                tipo_ligacao = dr["tipo_ligacao"].ToString();
                modalidade_ligacao = dr["modalidade_ligacao"].ToString();
                billsec_cobrado = dr["billsec_cobrado"].ToString();
                tarifa = dr["tarifa"].ToString();
                valor_cobrado = dr["valor"].ToString();

                mensagem = clid + ";" + eot_origem + ";" + localidade_origem + ";" + dst + ";" + eot_destino + ";" + localidade_destino + ";" + billsec + ";" + data + ";" + hora + ";" + entrante + ";" + sainte + ";" + tipo_ligacao + ";" + modalidade_ligacao + ";" + billsec_cobrado + ";" + tarifa + ";" + valor_cobrado;

                objLogger.GravarCSV(@"C:/detraf/detalhado/DetrafNacionalDetalhadoCredito.csv", mensagem);

            }

            objDetrafDal = null;
            objLogger = null;
            dt = null;
        }

        public void CalcularDetrafTransitoLocalDetalhadoDebito(string dataInicial, string dataFinal)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafTransitoLocalDetalhadoDebito(dataInicial, dataFinal);

            string mensagem = "";
            string clid = "";
            string eot_origem = "";
            string localidade_origem = "";
            string dst = "";
            string eot_destino = "";
            string localidade_destino = "";
            string billsec = "";
            string data = "";
            string hora = "";
            string entrante = "";
            string sainte = "";
            string tipo_ligacao = "";
            string modalidade_ligacao = "";
            string billsec_cobrado = "";
            string tarifa = "";
            string valor_cobrado = "";

            foreach (DataRow dr in dt.Rows)
            {
                clid = dr["clid"].ToString();
                eot_origem = dr["eot_origem"].ToString();
                localidade_origem = dr["localidade_origem"].ToString();
                dst = dr["dst"].ToString();
                eot_destino = dr["eot_destino"].ToString();
                localidade_destino = dr["localidade_destino"].ToString();
                billsec = dr["billsec"].ToString();
                data = dr["data"].ToString();
                hora = dr["hora"].ToString();
                entrante = dr["entrante"].ToString();
                sainte = dr["sainte"].ToString();
                tipo_ligacao = dr["tipo_ligacao"].ToString();
                modalidade_ligacao = dr["modalidade_ligacao"].ToString();
                billsec_cobrado = dr["billsec_cobrado"].ToString();
                tarifa = dr["tarifa"].ToString();
                valor_cobrado = dr["valor"].ToString();

                mensagem = clid + ";" + eot_origem + ";" + localidade_origem + ";" + dst + ";" + eot_destino + ";" + localidade_destino + ";" + billsec + ";" + data + ";" + hora + ";" + entrante + ";" + sainte + ";" + tipo_ligacao + ";" + modalidade_ligacao + ";" + billsec_cobrado + ";" + tarifa + ";" + valor_cobrado;

                objLogger.GravarCSV(@"C:/detraf/detalhado/DetrafTransitoLocalDetalhadoDebito.csv", mensagem);

            }

            objDetrafDal = null;
            objLogger = null;
            dt = null;

        }

        public void CalcularDetrafTransporteDetalhadoDebito(string dataInicial, string dataFinal)
        {
            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafTransporteDetalhadoDebito(dataInicial, dataFinal);

            string mensagem = "";
            string clid = "";
            string eot_origem = "";
            string localidade_origem = "";
            string dst = "";
            string eot_destino = "";
            string localidade_destino = "";
            string billsec = "";
            string data = "";
            string hora = "";
            string entrante = "";
            string sainte = "";
            string tipo_ligacao = "";
            string modalidade_ligacao = "";
            string billsec_cobrado = "";
            string tarifa = "";
            string valor_cobrado = "";

            foreach (DataRow dr in dt.Rows)
            {
                clid = dr["clid"].ToString();
                eot_origem = dr["eot_origem"].ToString();
                localidade_origem = dr["localidade_origem"].ToString();
                dst = dr["dst"].ToString();
                eot_destino = dr["eot_destino"].ToString();
                localidade_destino = dr["localidade_destino"].ToString();
                billsec = dr["billsec"].ToString();
                data = dr["data"].ToString();
                hora = dr["hora"].ToString();
                entrante = dr["entrante"].ToString();
                sainte = dr["sainte"].ToString();
                tipo_ligacao = dr["tipo_ligacao"].ToString();
                modalidade_ligacao = dr["modalidade_ligacao"].ToString();
                billsec_cobrado = dr["billsec_cobrado"].ToString();
                tarifa = dr["tarifa"].ToString();
                valor_cobrado = dr["valor"].ToString();

                mensagem = clid + ";" + eot_origem + ";" + localidade_origem + ";" + dst + ";" + eot_destino + ";" + localidade_destino + ";" + billsec + ";" + data + ";" + hora + ";" + entrante + ";" + sainte + ";" + tipo_ligacao + ";" + modalidade_ligacao + ";" + billsec_cobrado + ";" + tarifa + ";" + valor_cobrado;

                objLogger.GravarCSV(@"C:/detraf/detalhado/DetrafTransporteDetalhadoDebito.csv", mensagem);

            }

            objDetrafDal = null;
            objLogger = null;
            dt = null;

        }

        public void CalcularDetrafLocalBatimento(string dataInicial, string dataFinal, string eotOrigem, string eotDestino)
        {

            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafLocalBatimento(dataInicial, dataFinal, eotOrigem, eotDestino);

            string mensagem = "";
            string clid = "";
            string dataChamada = "";
            string horaAtendimento = "";
            string dst = "";
            string billsec = "";
            string pontoInterconexao = "BRETYCC01";
            string descriptor = "";
            string duracaoCalculada = "";
            string categoriaAssinante = "01";
            string fds = "01";
            string causaSaida = "01";
            string contadorSaidas = "01";
            string identificacaoOrigem = "-------";
            string valorRemuneracao = "";
            string sequencial = "";
            int k = 0;

            foreach (DataRow dr in dt.Rows)
            {
                k++;
                clid = dr["clid"].ToString();
                dataChamada = dr["data"].ToString();
                horaAtendimento = dr["hora"].ToString().Replace(":","");
                dst = dr["dst"].ToString();
                billsec = dr["billsec"].ToString();                
                descriptor = dr["descriptor"].ToString();
                duracaoCalculada = dr["billsec_cobrado"].ToString();                                                                                
                valorRemuneracao = dr["valor"].ToString();                
                sequencial = k.ToString();

                if(dst.StartsWith("0"))
                {                    
                    dst = dst.Substring(1, 10);
                }


                mensagem = "";
                sequencial =          insereTexto(sequencial,10,"direita","0");
                clid =                insereTexto(clid, 21, "esquerda", "-");
                dataChamada =         insereTexto(dataChamada, 8, "esquerda", "0");
                horaAtendimento =     insereTexto(horaAtendimento, 6, "esquerda", "0");
                dst             =     insereTexto(dst, 20, "esquerda", "-");
                billsec         =     insereTexto(billsec, 7, "direita", "0");
                pontoInterconexao =   insereTexto(pontoInterconexao, 10, "esquerda", " ");
                descriptor        =   insereTexto(descriptor, 5, "direita", " ");
                duracaoCalculada  =   insereTexto(duracaoCalculada, 13, "direita", "0");
                categoriaAssinante =  insereTexto(categoriaAssinante, 2, "esquerda", " ");
                fds =                 insereTexto(fds, 2, "esquerda", " ");
                causaSaida =          insereTexto(causaSaida, 1, "esquerda", " ");
                contadorSaidas =      insereTexto(contadorSaidas, 2, "esquerda", " ");
                identificacaoOrigem = insereTexto(identificacaoOrigem, 7, "esquerda", "-");
                valorRemuneracao =    insereTexto("0", 15, "esquerda", "0");

                
                mensagem = sequencial + clid + dataChamada + horaAtendimento + dst + billsec + pontoInterconexao + descriptor + duracaoCalculada + categoriaAssinante + fds + causaSaida + contadorSaidas + identificacaoOrigem + valorRemuneracao;

                objLogger.GravarCSV(@"C:/detraf/detalhado/CalcularDetrafLocalBatimento.csv", mensagem);
            }

            objDetrafDal = null;
            objLogger = null;
            dt = null;

        }


        public void CalcularDetrafNacionalBatimento(string dataInicial, string dataFinal, string eotOrigem, string eotDestino)
        {

            DetrafDal objDetrafDal = new DetrafDal();
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DataTable dt;
            dt = objDetrafDal.CalcularDetrafNacionalBatimento(dataInicial, dataFinal, eotOrigem, eotDestino);

            string mensagem = "";
            string clid = "";
            string dataChamada = "";
            string horaAtendimento = "";
            string dst = "";
            string billsec = "";
            string pontoInterconexao = "BRETYCC01";
            string descriptor = "";
            string duracaoCalculada = "";
            string categoriaAssinante = "01";
            string fds = "01";
            string causaSaida = "01";
            string contadorSaidas = "01";
            string identificacaoOrigem = "-------";
            string valorRemuneracao = "";
            string sequencial = "";
            int k = 0;

            foreach (DataRow dr in dt.Rows)
            {
                k++;
                clid = dr["clid"].ToString();
                dataChamada = dr["data"].ToString();
                horaAtendimento = dr["hora"].ToString().Replace(":", "");
                dst = dr["dst"].ToString();
                billsec = dr["billsec"].ToString();
                descriptor = dr["descriptor"].ToString();
                duracaoCalculada = dr["billsec_cobrado"].ToString();
                valorRemuneracao = dr["valor"].ToString();
                sequencial = k.ToString();
                
                mensagem = "";
                sequencial = insereTexto(sequencial, 10, "direita", "0");
                clid = insereTexto(clid, 21, "esquerda", "-");
                dataChamada = insereTexto(dataChamada, 8, "esquerda", "0");
                horaAtendimento = insereTexto(horaAtendimento, 6, "esquerda", "0");
                dst = insereTexto(dst, 20, "esquerda", "-");
                billsec = insereTexto(billsec, 7, "direita", "0");
                pontoInterconexao = insereTexto(pontoInterconexao, 10, "esquerda", " ");
                descriptor = insereTexto(descriptor, 5, "direita", " ");
                duracaoCalculada = insereTexto(duracaoCalculada, 13, "direita", "0");
                categoriaAssinante = insereTexto(categoriaAssinante, 2, "esquerda", " ");
                fds = insereTexto(fds, 2, "esquerda", " ");
                causaSaida = insereTexto(causaSaida, 1, "esquerda", " ");
                contadorSaidas = insereTexto(contadorSaidas, 2, "esquerda", " ");
                identificacaoOrigem = insereTexto(identificacaoOrigem, 7, "esquerda", "-");
                valorRemuneracao = insereTexto("0", 15, "esquerda", "0");

                mensagem = sequencial + clid + dataChamada + horaAtendimento + dst + billsec + pontoInterconexao + descriptor + duracaoCalculada + categoriaAssinante + fds + causaSaida + contadorSaidas + identificacaoOrigem + valorRemuneracao;

                objLogger.GravarCSV(@"C:/detraf/detalhado/CalcularDetrafNacionalBatimento.csv", mensagem);
            }

            objDetrafDal = null;
            objLogger = null;
            dt = null;

        }


        public string insereTexto(string texto, int tamanho, string alinhamento, string pos)
        {
            string str = "";

            if (tamanho > texto.Length)
            {
                for (int i = texto.Length; i < tamanho; i++)
                {
                    str = str + pos;
                }

                if (alinhamento == "esquerda")
                {
                    texto = texto + str;
                }
                else
                {
                    texto = str + texto;
                }

            }
            else
            {
                string texto_novo = "";
                for (int i = 0; i < tamanho; i++)
                {
                    texto_novo = texto_novo+texto[i].ToString(); ;
                }
                texto = texto_novo;
            }

            return texto;
        }

    }   

    public enum modalidadeLigacao : byte 
    { 
        Local,
        Nacional,
        TransitoLocal,
        Transporte  
    }

    public enum tipoDetraf : byte 
    {
        Batimento,
        Desbalanceamento,
        Detalhado,
        Resumido
    }

}