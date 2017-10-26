using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DETRAF.BLL;

namespace DETRAF.VIEW
{
    public partial class FormDetraf : Form
    {
        public FormDetraf()
        {
            InitializeComponent();
        }

        private void FormDetraf_Load(object sender, EventArgs e)
        {            
            comboBoxModalidadeLigacao.SelectedIndexChanged += new EventHandler(PreencherOperadoras);
            radioButtonCredito.Click += new EventHandler(VerificaModalidadeSelecionada);
            radioButtonDebito.Click += new EventHandler(VerificaModalidadeSelecionada);

        }

        public void VerificaModalidadeSelecionada(object obj, EventArgs evento)
        {
            RadioButton op = (RadioButton)obj;
            string sel = op.Text;

            string selModalidade = comboBoxModalidadeLigacao.SelectedIndex.ToString();

            


        }

        public void PreencherOperadoras(object obj, EventArgs evento)
        {
            ComboBox list = (ComboBox)obj;
            string sel = list.Text;
            radioButtonCredito.Checked = false;
            radioButtonDebito.Checked = false;
            switch (sel)
            {
                case ("Transito Local"):
                    textBoxOperadora.Text = "829";
                    textBoxComOperadora.Text = "11";
                    radioButtonDebito.Checked = true;                    
                    break;
                case ("Transporte"):
                    textBoxOperadora.Text = "929";
                    textBoxComOperadora.Text = "11";
                    radioButtonDebito.Checked = true;
                    break;
                case ("Nacional"):
                    radioButtonCredito.Checked = true;
                    break;
                default:
                    textBoxOperadora.Text = "";
                    textBoxComOperadora.Text = "";
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {          
            
            if (comboBoxModalidadeLigacao.SelectedIndex != 0 && comboBoxTipoDetraf.SelectedIndex == 1)
            {
                MessageBox.Show("Detraf de desbalanceamento é permitido para a modalidade LOCAL!");
            }
            else
            {

                string msg = "";

                if (textBoxDataInicial.Text == "") msg += "- Data Inicial\n";
                if (textBoxDataFinal.Text == "") msg += "- Data Final\n";
                if (textBoxOperadora.Text == "") msg += "- Crédito\n";
                if (textBoxComOperadora.Text == "") msg += "- Com Operadora\n";
                if (comboBoxModalidadeLigacao.SelectedIndex == -1) msg += "- Modalidade da Ligação\n";
                if (comboBoxTipoDetraf.SelectedIndex == -1) msg += "- Tipo de Detraf\n";
                if (radioButtonCredito.Checked == false && radioButtonDebito.Checked == false) msg += "- Crédito / Débito\n";

                if (msg != "")
                    MessageBox.Show("Favor preencher o(s) seguinte(s) campo(s):\n"+msg);
                else
                {
                    Detraf objDetraf = new Detraf();

                    int tipo;

                    if (radioButtonCredito.Checked == true)
                        tipo = 0;
                    else
                        tipo = 1;                    

                    if (comboBoxModalidadeLigacao.SelectedIndex == 0 && comboBoxTipoDetraf.SelectedIndex == 1)
                    {
                        objDetraf.CalcularDetrafLocalDesbalanceamento(textBoxDataInicial.Text, textBoxDataFinal.Text, textBoxOperadora.Text, textBoxComOperadora.Text, (modalidadeLigacao)comboBoxModalidadeLigacao.SelectedIndex, (tipoDetraf)comboBoxTipoDetraf.SelectedIndex);
                        labelResposta.Text = "Créditos Minutos Normal: " + objDetraf.CreditoHorarioNormal.ToString() + "\n" +
                        "Débitos Minutos Normal: " + objDetraf.DebitoHorarioNormal.ToString() + "\n" +
                        "Total Normal: " + objDetraf.TotalHorarioNormal.ToString() + "\n" +
                        "Limite Superior Normal: " + objDetraf.LimiteSuperiorNormal.ToString() + "\n" +
                        "Excesso Normal: " + objDetraf.ExcessoNormal.ToString() + "\n" +
                        "Tarifa Normal: " + objDetraf.ValorHorarioNormal.ToString() + "\n" +
                        "Valor Bruto Normal: " + objDetraf.ValorBrutoNormal.ToString() + "\n" +
                        "EOT Devedor Normal: " + objDetraf.EotDevedorNormal.ToString() + "\n\n" +

                        "Créditos Minutos Reduzido: " + objDetraf.CreditoHorarioReduzido.ToString() + "\n" +
                        "Débitos Minutos Reduzido: " + objDetraf.DebitoHorarioReduzido.ToString() + "\n" +
                        "Total Reduzido: " + objDetraf.TotalHorarioReduzido.ToString() + "\n" +
                        "Limite Superior Reduzido: " + objDetraf.LimiteSuperiorReduzido.ToString() + "\n" +
                        "Excesso Reduzido: " + objDetraf.ExcessoReduzido.ToString() + "\n" +
                        "Tarifa Reduzido: " + objDetraf.ValorHorarioReduzido.ToString() + "\n" +
                        "Valor Bruto Reduzido: " + objDetraf.ValorBrutoReduzido.ToString()+"\n"+
                        "EOT Devedor Reduzido: " + objDetraf.EotDevedorReduzido.ToString();

                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 0 && comboBoxTipoDetraf.SelectedIndex == 3)
                    {
                        objDetraf.CalcularDetrafLocalResumido(textBoxDataInicial.Text, textBoxDataFinal.Text, textBoxOperadora.Text, textBoxComOperadora.Text, (modalidadeLigacao)comboBoxModalidadeLigacao.SelectedIndex, (tipoDetraf)comboBoxTipoDetraf.SelectedIndex, tipo);
                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 0 && comboBoxTipoDetraf.SelectedIndex == 0)
                    {
                        objDetraf.CalcularDetrafLocalBatimento(textBoxDataInicial.Text, textBoxDataFinal.Text, textBoxOperadora.Text, textBoxComOperadora.Text);
                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 1 && comboBoxTipoDetraf.SelectedIndex == 0)
                    {
                        objDetraf.CalcularDetrafNacionalBatimento(textBoxDataInicial.Text, textBoxDataFinal.Text, textBoxOperadora.Text, textBoxComOperadora.Text);
                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 0 && comboBoxTipoDetraf.SelectedIndex == 2)
                    {
                        objDetraf.CalcularDetrafLocalDetalhado(textBoxDataInicial.Text, textBoxDataFinal.Text, textBoxOperadora.Text, textBoxComOperadora.Text, (modalidadeLigacao)comboBoxModalidadeLigacao.SelectedIndex, (tipoDetraf)comboBoxTipoDetraf.SelectedIndex, tipo);
                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 1 && comboBoxTipoDetraf.SelectedIndex == 3)
                    {
                        if (tipo == 0)
                        {
                            objDetraf.CalcularDetrafNacionalResumidoCredito(textBoxDataInicial.Text, textBoxDataFinal.Text, textBoxOperadora.Text, textBoxComOperadora.Text, (modalidadeLigacao)comboBoxModalidadeLigacao.SelectedIndex, (tipoDetraf)comboBoxTipoDetraf.SelectedIndex, tipo);
                            msg = "DETRAF PROCESSADO!";
                        }
                        else
                            msg = "Não é possivel efetuar Detraf Débito!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 1 && comboBoxTipoDetraf.SelectedIndex == 2)
                    {
                        if (tipo == 0)
                        {
                            objDetraf.CalcularDetrafNacionalDetalhadoCredito(textBoxDataInicial.Text, textBoxDataFinal.Text, textBoxOperadora.Text, textBoxComOperadora.Text, (modalidadeLigacao)comboBoxModalidadeLigacao.SelectedIndex, (tipoDetraf)comboBoxTipoDetraf.SelectedIndex, tipo);
                            msg = "DETRAF PROCESSADO!";
                        }
                        else
                            msg = "Não é possivel efetuar Detraf Débito!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 2 && comboBoxTipoDetraf.SelectedIndex == 3)
                    {
                        objDetraf.CalcularDetrafTransitoLocalResumidoDebito(textBoxDataInicial.Text, textBoxDataFinal.Text);
                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 2 && comboBoxTipoDetraf.SelectedIndex == 2)
                    {
                        objDetraf.CalcularDetrafTransitoLocalDetalhadoDebito(textBoxDataInicial.Text, textBoxDataFinal.Text);
                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 3 && comboBoxTipoDetraf.SelectedIndex == 3)
                    {
                        objDetraf.CalcularDetrafTransporteResumidoDebito(textBoxDataInicial.Text, textBoxDataFinal.Text);
                        msg = "DETRAF PROCESSADO!";
                    }
                    else if (comboBoxModalidadeLigacao.SelectedIndex == 3 && comboBoxTipoDetraf.SelectedIndex == 2)
                    {
                        objDetraf.CalcularDetrafTransporteDetalhadoDebito(textBoxDataInicial.Text, textBoxDataFinal.Text);
                        msg = "DETRAF PROCESSADO!";
                    }
                    objDetraf=null;
                    MessageBox.Show(msg);
                }
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    /*public enum modalidadeLigacao : byte
    {
        Local
        Nacional
        TransitoLocal
        Transporte
    }

    public enum tipoDetraf : byte
    {
        Batimento,
        Desbalanceamento,
        Detalhado,
        Resumido        
    }*/

}