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
    public partial class FormEOT : Form
    {
        public FormEOT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            try
            {
                fdlg.Title = "Selecione os CDR´s";
                fdlg.InitialDirectory = @"C:\detraf\eot";
                fdlg.Filter = "Documentos de texto (*.csv) | *.csv";

                if (fdlg.ShowDialog() == DialogResult.OK)
                    textBoxCaminhoArquivo.Text = fdlg.FileName;
                else
                    textBoxCaminhoArquivo.Text = "";
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
            if (!File.Exists(textBoxCaminhoArquivo.Text))
                MessageBox.Show("Arquivo inválido!");
            else
            {
                StreamReader objReader = new StreamReader(textBoxCaminhoArquivo.Text);
                DETRAF.BLL.Eot objEot = new DETRAF.BLL.Eot();
                bool erro = objEot.ProcessarEot(objReader);
                string msg;
                if (!erro)
                    msg = "Arquivo processado com sucesso!";
                else
                    msg = "Arquivo processado com sucesso!\nFavor, verificar o arquivo de críticas!";
                objEot = null;
                MessageBox.Show(msg);
            }
        }
    }
}
