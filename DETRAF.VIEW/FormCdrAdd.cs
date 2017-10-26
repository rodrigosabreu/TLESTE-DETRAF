using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DETRAF.VIEW
{
    public partial class FormCdrAdd : Form
    {
        public FormCdrAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            try
            {
                fdlg.Title = "Selecione os CDR´s";
                fdlg.InitialDirectory = @"C:\detraf\cdr";
                fdlg.Filter = "Documentos de texto (*.csv) | *.csv";

                if (fdlg.ShowDialog() == DialogResult.OK)
                    textBoxCaminho.Text = fdlg.FileName;
                else
                    textBoxCaminho.Text = "";
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                fdlg.Dispose();
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxCaminho.Text))
                MessageBox.Show("Arquivo inválido!");
            else
            {
                if (MessageBox.Show("Deseja importar os cdr´s?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    try
                    {
                        DETRAF.BLL.Cdr objCdr = new DETRAF.BLL.Cdr();
                        bool ret = objCdr.ProcessaCdr(textBoxCaminho.Text);
                        string msg;
                        if (ret)
                            msg = "Arquivo importado com sucesso!";
                        else
                            msg = "Arquivo importado com sucesso!\nFavor, verificar o arquivo de críticas!";
                        objCdr = null;
                        MessageBox.Show(msg);
                    }catch(InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxCaminho.Text))
                MessageBox.Show("Arquivo inválido!");
            else
            {
                if (MessageBox.Show("Deseja validar os cdr´s?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DETRAF.BLL.Cdr objCdr = new DETRAF.BLL.Cdr();
                    bool ret = objCdr.ValidarCdr(textBoxCaminho.Text);
                    string msg;
                    if (ret)
                        msg = "Arquivo validado!";
                    else
                        msg = "Favor, verificar o arquivo de críticas!";
                    objCdr = null;
                    MessageBox.Show(msg);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textDataInicial.Text) && !string.IsNullOrEmpty(textDataFinal.Text))
            {
                if (MessageBox.Show("Deseja deletar os cdr´s?", "Confirmação", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DETRAF.BLL.Cdr objCdr = new DETRAF.BLL.Cdr();
                    objCdr.ExcluirCdr(textDataInicial.Text, textDataFinal.Text);
                    objCdr = null;
                    MessageBox.Show("Cdr Excluído!");
                }
            }
            else 
            {
                MessageBox.Show("Favor, preencha os campos Data Inicial e Final!");
            }
        }

        private void FormCdrAdd_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Cdr objCdr = new DETRAF.BLL.Cdr();
            int i = objCdr.ReprocessarCdr();
            objCdr = null;
            MessageBox.Show("Foram reprocessados "+i.ToString()+" eot´s!");
        }
    }
}