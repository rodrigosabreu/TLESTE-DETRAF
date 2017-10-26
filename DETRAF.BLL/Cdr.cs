using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace DETRAF.BLL
{
    public class Cdr
    {
        private int id;
        private string clid;
        private int eotOrigem;
        private string localidadeOrigem;
        private string dst;
        private int eotDestino;
        private string localidadeDestino;
        private int billsec;
        private string tempoCobrado;
        private string data;
        private string hora;
        private string valorLigacao;
        //private string sentidoLigacao;//E=Entrante, S=Sainte 
        private int entrante;        
        private int sainte;        
        private string tipoLigacao;//N=Normal, A=Acobrar
        private string modalidadeLigacao;//L=Local, N=Nacional, I=Internacional

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Clid
        {
            get { return clid; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    clid = value;
                else                    
                    throw new InvalidCastException("Número de origem incorreto");
            }
        }
        public int EotOrigem
        {
            get { return eotOrigem; }
            set { eotOrigem = value;}
        }
        public string LocalidadeOrigem
        {
            get { return localidadeOrigem; }
            set { localidadeOrigem = value; }
        }
        public string Dst
        {
            get { return dst; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    dst = value;
                else
                    throw new InvalidCastException("Número de destino incorreto");
            }
        }
        public int EotDestino
        {
            get { return eotDestino; }
            set { eotDestino = value;}
        }
        public string LocalidadeDestino
        {
            get { return localidadeDestino; }
            set { localidadeDestino = value;}
        }
        public int Billsec
        {
            get { return billsec; }
            set { billsec = value;}
        }
        public string TempoCobrado
        {
            get { return tempoCobrado; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    tempoCobrado = value;
                else
                    throw new InvalidCastException("Tempo cobrado incorreto");
            }
        }
        public string Data
        {
            get { return data; }
            set 
            {
                if ((!string.IsNullOrEmpty(value)) && (value.Length == 8))
                    data = value; 
                else
                    throw new InvalidCastException("Data incorreta");
            }
        }
        public string Hora
        {
            get { return hora; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    hora = value;
                else
                    throw new InvalidCastException("Hora incorreto");
            }
        }
        public string ValorLigacao
        {
            get { return valorLigacao; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    valorLigacao = value; 
                else
                    throw new InvalidCastException("Valor da ligação incorreto");
            }
        }
        /*public string SentidoLigacao
        {
            get { return sentidoLigacao; }
            set { sentidoLigacao = value; }
        }*/
        public int Entrante
        {
            get { return entrante; }
            set { entrante = value; }
        }
        public int Sainte
        {
            get { return sainte; }
            set { sainte = value; }
        }
        public string TipoLigacao
        {
            get { return tipoLigacao; }
            set 
            {
                /*if (string.IsNullOrEmpty(value))
                    throw new FormatException("Tipo da ligação nulo");
                else*/
                    tipoLigacao = value; 
            }
        }
        public string ModalidadeLigacao
        {
            get { return modalidadeLigacao; }
            set
            {
                /*if (string.IsNullOrEmpty(value))
                    throw new FormatException("Modalidade da ligação nulo");
                else*/
                    modalidadeLigacao = value; 
            }
        }

        public bool ValidarCdr(string caminho) 
        {            
            bool erro;
            bool erroMetodo=true;
            string sLine = "";
            string mensagem = "";
            string Clid_novo = "";
            string Dst_novo = "";
            string critica_prefixo = "";
            string[] campo;
            DataTable dtEotLocOrigem;
            DataTable dtEotLocDestino;

            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            StreamReader objReader = new StreamReader(caminho);

            while (sLine != null)
            {
                erro = false;
                sLine = objReader.ReadLine();
                if (!string.IsNullOrEmpty(sLine))
                {
                    campo = sLine.Split(new char[] { ';' });

                    try
                    {
                        Clid = campo[0];
                        Dst = campo[1];
                        Billsec = Convert.ToInt32(campo[2]);
                        Data = campo[3];
                        Hora = campo[4];
                        /*SentidoLigacao = campo[5];
                        TipoLigacao = campo[6];
                        ModalidadeLigacao = campo[7];*/

                        Clid_novo = Clid;
                        Dst_novo = Dst;

                        dtEotLocOrigem = ObterEotLocalidade(Clid_novo);
                        foreach (DataRow dr in dtEotLocOrigem.Rows)
                        {
                            EotOrigem = Convert.ToInt32(dr["eot"].ToString());
                            LocalidadeOrigem = dr["localidade"].ToString();
                        }

                        dtEotLocDestino = ObterEotLocalidade(Dst_novo);
                        foreach (DataRow dr in dtEotLocDestino.Rows)
                        {
                            EotDestino = Convert.ToInt32(dr["eot"].ToString());
                            LocalidadeDestino = dr["localidade"].ToString();
                        }

                        if ((EotOrigem == 0 || EotDestino == 0) && !Dst_novo.StartsWith("00"))
                        {
                            if (EotOrigem == 0 && EotDestino == 0)
                                critica_prefixo = ObterPrefixo(Clid_novo) + "-" + ObterPrefixo(Dst_novo);
                            else if (EotOrigem == 0)
                                critica_prefixo = ObterPrefixo(Clid_novo);
                            else
                                critica_prefixo = ObterPrefixo(Dst_novo);

                            throw new InvalidCastException("Eot não encontrado: " + critica_prefixo);
                        }                        

                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        erro = true;
                        mensagem = ex.Message;
                        objLogger.Gravar(@"C:/detraf/cdr/critica-cdr.txt", sLine.ToString() + " - " + mensagem);
                    }
                    catch (InvalidCastException ex)
                    {
                        erro = true;
                        mensagem = ex.Message;
                        objLogger.Gravar(@"C:/detraf/cdr/critica-cdr.txt", sLine.ToString() + " - " + mensagem);
                    }
                    catch (Exception ex)
                    {
                        erro = true;
                        mensagem = ex.Message;
                        objLogger.Gravar(@"C:/detraf/cdr/critica-cdr.txt", sLine.ToString() + " - " + mensagem);
                    }
                    
                    if (erro == true)
                    {
                        erroMetodo = false;                        
                    }
                }
            }
            objReader.Close();
            objReader.Dispose();  
            objLogger = null;
            return erroMetodo;
        }

        public bool ProcessaCdr(string caminho)
        {
            bool erroMetodo = true;
            string sLine = "";
            string Clid_novo;
            string Dst_novo;
            string[] campo;
            string strDateTime;
            string ano;
            string mes;
            string dia;
            StreamReader objReader = new StreamReader(caminho);
            DataTable dtEotLocOrigem;
            DataTable dtEotLocDestino;
            DateTime DateCdr;
            DETRAF.LOGGER.Logger objLogger = new DETRAF.LOGGER.Logger();
            DETRAF.DAL.CdrDal objCdrDal = new DETRAF.DAL.CdrDal();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (!string.IsNullOrEmpty(sLine))
                {
                    campo = sLine.Split(new char[] { ';' });
                    try
                    {
                        Clid = campo[0];
                        Dst = campo[1];
                        Billsec = Convert.ToInt32(campo[2]);
                        Data = campo[3];
                        Hora = campo[4];
                        /*SentidoLigacao = campo[5];
                        TipoLigacao = campo[6];
                        ModalidadeLigacao = campo[7];*/
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidCastException("Arquivo fora do padrão!");
                    }

                    Clid_novo = Clid;
                    Dst_novo = Dst;

                    dtEotLocOrigem = ObterEotLocalidade(Clid_novo);
                    EotOrigem = 0;
                    LocalidadeOrigem = "";
                    foreach (DataRow dr in dtEotLocOrigem.Rows)
                    {
                        EotOrigem = Convert.ToInt32(dr["eot"].ToString());
                        LocalidadeOrigem = dr["localidade"].ToString();
                    }

                    dtEotLocDestino = ObterEotLocalidade(Dst_novo);
                    EotDestino = 0;
                    LocalidadeDestino = "";
                    foreach (DataRow dr in dtEotLocDestino.Rows)
                    {
                        EotDestino = Convert.ToInt32(dr["eot"].ToString());
                        LocalidadeDestino = dr["localidade"].ToString();
                    }                   
                    
                    //Verificação de Localidades e Tipo de Ligações (Entrante e Sainte)
                    if (LocalidadeOrigem == "SPO" && LocalidadeDestino == "SPO" && (EotOrigem.ToString() == "829" || EotDestino.ToString() == "829"))
                    {
                        ModalidadeLigacao = "L";
                        if (EotOrigem.ToString() == "829")
                        {
                            Entrante = 0;
                            Sainte = 1;
                        }
                        else 
                        {
                            Entrante = 1;
                            Sainte = 0;
                        }
                    }
                    else if (LocalidadeDestino == "INTL")
                    {
                        ModalidadeLigacao = "I";
                        if (EotOrigem.ToString() == "829")
                        {
                            Entrante = 0;
                            Sainte = 1;
                        }
                        else
                        {
                            Entrante = 1;
                            Sainte = 0;
                        }
                    }
                    else
                    {
                        ModalidadeLigacao = "N";
                        if (EotOrigem.ToString() == "829")
                        {
                            Entrante = 0;
                            Sainte = 1;
                        }
                        else if (EotDestino.ToString() == "829")
                        {
                            Entrante = 1;
                            Sainte = 0;
                        }                        
                        else if(Dst == "02910329")
                        {
                            Entrante = 1;
                            Sainte = 0;
                        }
                        else
                        {
                            Entrante = 1;
                            Sainte = 1;
                        }
                    }
                    TipoLigacao = "N";
                    if (Dst_novo.StartsWith("90")){
                        TipoLigacao = "A";
                    }

                    //strDateTime = "1992-10-10 12:15:12";
                    ano = Data.Substring(0, 4);
                    mes = Data.Substring(4, 2);
                    dia = Data.Substring(6, 2);
                    strDateTime = ano+"-"+mes+"-"+dia+" "+Hora;
                    DateCdr = DateTime.Parse(strDateTime);

                    objCdrDal.GravarCdr(Clid_novo, EotOrigem, LocalidadeOrigem, Dst_novo, EotDestino, LocalidadeDestino, Billsec, Data, Hora, DateCdr, Entrante, Sainte, TipoLigacao, ModalidadeLigacao);

                 }

            }
            objReader.Close();
            objReader.Dispose();
            objLogger = null;
            objCdrDal = null;
            
            return erroMetodo;
        }        

        public string PadronizarNumDestinoPortabilidade(string tn)
        {
            string tn_novo;

            if (tn.StartsWith("080") || tn.StartsWith("030"))//0800 e 0300
                tn_novo = tn;                        
            else if (tn.StartsWith("011")) //Local Normal 01147473291
                tn_novo = tn.Substring(1, 10);            
            else if (tn.StartsWith("9011")) //Local Acobrar 901147473291
                tn_novo = tn.Substring(2, 10);
            else if (tn.StartsWith("0")) //Longa Normal 0293538531234
                tn_novo = tn.Substring(3, 10);
            else if (tn.StartsWith("90")) //Longa Acobrar 90293538531234
                tn_novo = tn.Substring(4, 10);
            else if (tn.StartsWith("8044")) //Linha Habilitada 80441147473291
                tn_novo = tn.Substring(4, 10);
            else
                tn_novo = tn;

            return tn_novo;
        }

        public DataTable ObterEotLocalidade(string tn) 
        {
            DETRAF.DAL.CdrDal objCdrDal = new DETRAF.DAL.CdrDal();            
            int eotPortado = 0;
            int eot = 0;
            string localidade = "";
                        
            if (tn.StartsWith("00"))
            {
                eot = 99999;
                localidade = "INTL";
            }
            else if (tn == "10329")
            {
                eot = 829;
                localidade = "SE";
            }
            else if (tn == "1")
            {
                eot = 77777;
                localidade = "SE";
            }
            else if (tn == "02910329")
            {
                eot = 88888;
                localidade = "TLESTE";
            }
            else
            {
                DataTable dtPortado = objCdrDal.ConsultarTnPortado(PadronizarNumDestinoPortabilidade(tn));
                foreach (DataRow dr in dtPortado.Rows)
                {
                    eotPortado = Convert.ToInt32(dr["subscription_recipient_eot"].ToString());
                }

                DETRAF.DAL.PrefixoDal objPrefixoDal = new DETRAF.DAL.PrefixoDal();
                string prefixo = ObterPrefixo(tn);
                DataTable dtPrefixo = objPrefixoDal.ConsultarPrefixo(prefixo);
                foreach (DataRow dr in dtPrefixo.Rows)
                {
                    eot = Convert.ToInt32(dr["eot"].ToString());
                    localidade = dr["localidade"].ToString();
                }

                objCdrDal = null;
                objPrefixoDal = null;               

            }

            DataTable mDataTable = new DataTable();
            DataColumn mDataColumn;
            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "eot";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "localidade";
            mDataTable.Columns.Add(mDataColumn);

            DataRow linha;
            linha = mDataTable.NewRow();
            if(eotPortado > 0)
                linha["eot"] = eotPortado;
            else
                linha["eot"] = eot;

            //Regras de localidade para celular
            /*if (tn.StartsWith("116") || tn.StartsWith("0116") || tn.StartsWith("90116") ||
                tn.StartsWith("117") || tn.StartsWith("0117") || tn.StartsWith("90117") ||
                tn.StartsWith("118") || tn.StartsWith("0118") || tn.StartsWith("90118") ||
                tn.StartsWith("119") || tn.StartsWith("0119") || tn.StartsWith("90119"))
            {
                localidade = "SPO";
            }*/


            //Regras de localidade para celular
            if (tn.StartsWith("119") || tn.StartsWith("0119") || tn.StartsWith("90119"))             
            {
                localidade = "SPO";
            }


            linha["localidade"] = localidade;
            mDataTable.Rows.Add(linha);

            return mDataTable;

        }

        public string ObterPrefixo(string tn) {
            string prefixo = "";

            if (tn.StartsWith("080") || tn.StartsWith("030"))//0800 e 0300
                prefixo = tn;            
            else if (tn.Length == 10)//Numero de Origem 1129083844        
                prefixo = tn.Substring(0, 6);                        
            else if (tn.StartsWith("00"))//Internacional
                prefixo = tn;
            else if (tn.StartsWith("0119")) //Local Normal 011972099029
                prefixo = tn.Substring(1, 7);
            else if (tn.StartsWith("119")) //Local Normal 011972099029
                prefixo = tn.Substring(0, 7);
            else if(tn.StartsWith("011")) //Local Normal 01147473291
                prefixo = tn.Substring(1, 6);
            else if (tn.StartsWith("9011")) //Local Acobrar 901147473291
                prefixo = tn.Substring(2, 6);
            else if (tn.StartsWith("0")) //Longa Normal 0293538531234
                prefixo = tn.Substring(3, 6);
            else if (tn.StartsWith("90")) //Longa Acobrar 90293538531234
                prefixo = tn.Substring(4, 6);
            else if (tn.StartsWith("8044")) //Linha Habilitada 80441147473291
                prefixo = tn.Substring(4, 6);
            else if (tn.StartsWith("1"))//SE            
                prefixo = tn;
            else
                prefixo = tn;

            return prefixo;

        }

        public void ExcluirCdr(string dataInicial, string dataFinal)
        {
            DETRAF.DAL.CdrDal objCdrDal = new DETRAF.DAL.CdrDal();
            objCdrDal.ExcluirCdr(dataInicial, dataFinal);
            objCdrDal = null;
        }

        public int ReprocessarCdr()
        {
            DETRAF.DAL.CdrDal objCdrDal = new DETRAF.DAL.CdrDal();
            DataTable dt = objCdrDal.ConsultarEotCdr();
            int i = 0;
            int id;
            DataTable dtEotLocOrigem;
            DataTable dtEotLocDestino;
            string Clid_novo;
            string Dst_novo;
            string strDateTime;
            string ano;
            string mes;
            string dia;
            DateTime DateCdr;

            foreach (DataRow dr in dt.Rows)
            {
                id = Convert.ToInt32(dr["id"].ToString());
                Clid = dr["clid"].ToString();
                Dst = dr["dst"].ToString();
                Billsec = Convert.ToInt32(dr["billsec"]);
                Data = dr["data"].ToString();
                Hora = dr["hora"].ToString();

                Clid_novo = Clid;
                Dst_novo = Dst;

                dtEotLocOrigem = ObterEotLocalidade(Clid_novo);
                EotOrigem = 0;
                LocalidadeOrigem = "";
                foreach (DataRow dr2 in dtEotLocOrigem.Rows)
                {
                    EotOrigem = Convert.ToInt32(dr2["eot"].ToString());
                    LocalidadeOrigem = dr2["localidade"].ToString();
                }

                dtEotLocDestino = ObterEotLocalidade(Dst_novo);
                EotDestino = 0;
                LocalidadeDestino = "";
                foreach (DataRow dr3 in dtEotLocDestino.Rows)
                {
                    EotDestino = Convert.ToInt32(dr3["eot"].ToString());
                    LocalidadeDestino = dr3["localidade"].ToString();
                }

                //Verificação de Localidades e Tipo de Ligações (Entrante e Sainte)
                if (LocalidadeOrigem == "SPO" && LocalidadeDestino == "SPO" && (EotOrigem.ToString() == "829" || EotDestino.ToString() == "829"))
                {
                    ModalidadeLigacao = "L";
                    if (EotOrigem.ToString() == "829")
                    {
                        Entrante = 0;
                        Sainte = 1;
                    }
                    else
                    {
                        Entrante = 1;
                        Sainte = 0;
                    }
                }
                else if (LocalidadeDestino == "INTL")
                {
                    ModalidadeLigacao = "I";
                    if (EotOrigem.ToString() == "829")
                    {
                        Entrante = 0;
                        Sainte = 1;
                    }
                    else
                    {
                        Entrante = 1;
                        Sainte = 0;
                    }
                }
                else
                {
                    ModalidadeLigacao = "N";
                    if (EotOrigem.ToString() == "829")
                    {
                        Entrante = 0;
                        Sainte = 1;
                    }
                    else if (EotDestino.ToString() == "829")
                    {
                        Entrante = 1;
                        Sainte = 0;
                    }
                    else if (Dst == "02910329")
                    {
                        Entrante = 1;
                        Sainte = 0;
                    }
                    else
                    {
                        Entrante = 1;
                        Sainte = 1;
                    }
                }
                TipoLigacao = "N";
                if (Dst_novo.StartsWith("90"))
                {
                    TipoLigacao = "A";
                }

                //strDateTime = "1992-10-10 12:15:12";
                ano = Data.Substring(0, 4);
                mes = Data.Substring(4, 2);
                dia = Data.Substring(6, 2);
                strDateTime = ano + "-" + mes + "-" + dia + " " + Hora;
                DateCdr = DateTime.Parse(strDateTime);

                objCdrDal.AtualizarCdr(id, Clid_novo, EotOrigem, LocalidadeOrigem, Dst_novo, EotDestino, LocalidadeDestino, Billsec, Data, Hora, DateCdr, Entrante, Sainte, TipoLigacao, ModalidadeLigacao);



            }

            objCdrDal = null;
            return i;
        }

    }

}
