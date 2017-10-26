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
    public partial class FormPrefixoAdd : Form
    {
        public FormPrefixoAdd()
        {
            InitializeComponent();
        }

        private void buttonProcurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            try
            {
                fdlg.Title = "Selecione as EOT´s";
                fdlg.InitialDirectory = @"c:\detraf\prefixo";
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

        private void buttonImportar_Click(object sender, EventArgs e)
        {

            if (!File.Exists(textBoxCaminho.Text))            
                MessageBox.Show("Arquivo inválido!");            
            else
            {                
                StreamReader objReader = new StreamReader(textBoxCaminho.Text);
                DETRAF.BLL.Prefixo objPrefixo = new DETRAF.BLL.Prefixo();                                
                bool erro = objPrefixo.ProcessarPrefixo(objReader);                
                string msg;
                if (!erro) 
                    msg = "Arquivo processado com sucesso!";                    
                else
                    msg = "Arquivo processado com sucesso!\nFavor, verificar o arquivo de críticas!";
                objPrefixo = null;
                MessageBox.Show(msg);
            }
        }
    }
}
