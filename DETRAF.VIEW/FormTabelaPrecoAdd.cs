using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DETRAF.VIEW
{
    public partial class FormTabelaPrecoAdd : Form
    {
        public FormTabelaPrecoAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            try
            {
                fdlg.Title = "Selecione as EOT´s";
                fdlg.InitialDirectory = @"c:\detraf\tabelas";
                fdlg.Filter = "Documentos de texto (*.csv) | *.csv";

                if (fdlg.ShowDialog() == DialogResult.OK)
                    textCaminhoTurl.Text = fdlg.FileName;
                else
                    textCaminhoTurl.Text = "";

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
            OpenFileDialog fdlg = new OpenFileDialog();
            try
            {
                fdlg.Title = "Selecione as EOT´s";
                fdlg.InitialDirectory = @"c:\detraf\tabelas";
                fdlg.Filter = "Documentos de texto (*.csv) | *.csv";

                if (fdlg.ShowDialog() == DialogResult.OK)
                    textCaminhoVum.Text = fdlg.FileName;
                else
                    textCaminhoVum.Text = "";

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

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            try
            {
                fdlg.Title = "Selecione as EOT´s";
                fdlg.InitialDirectory = @"c:\detraf\tabelas";
                fdlg.Filter = "Documentos de texto (*.csv) | *.csv";

                if (fdlg.ShowDialog() == DialogResult.OK)
                    textCaminhoTuriu.Text = fdlg.FileName;
                else
                    textCaminhoTuriu.Text = "";

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

        private void button2_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoTURL();
            bool erro = objPreco.Validar(textCaminhoTurl.Text);
            objPreco = null;
            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
                MessageBox.Show("Arquivo validado com sucesso!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoVUM();
            bool erro = objPreco.Validar(textCaminhoVum.Text);
            objPreco = null;
            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
                MessageBox.Show("Arquivo validado com sucesso!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoTURIU();
            bool erro = objPreco.Validar(textCaminhoTuriu.Text);
            objPreco = null;
            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
                MessageBox.Show("Arquivo validado com sucesso!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoTURL();
            bool erro = objPreco.Validar(textCaminhoTurl.Text);

            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
            {
                objPreco.Processar(textCaminhoTurl.Text);
                MessageBox.Show("Arquivo Processado!");
            }
            objPreco = null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoVUM();
            bool erro = objPreco.Validar(textCaminhoVum.Text);

            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
            {
                objPreco.Processar(textCaminhoVum.Text);
                MessageBox.Show("Arquivo Processado!");
            }
            objPreco = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoTURIU();
            bool erro = objPreco.Validar(textCaminhoTuriu.Text);

            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
            {
                objPreco.Processar(textCaminhoTuriu.Text);
                MessageBox.Show("Arquivo Processado!");
            }
            objPreco = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            try
            {
                fdlg.Title = "Selecione as EOT´s";
                fdlg.InitialDirectory = @"c:\detraf\tabelas";
                fdlg.Filter = "Documentos de texto (*.csv) | *.csv";

                if (fdlg.ShowDialog() == DialogResult.OK)
                    textCaminhoVut.Text = fdlg.FileName;
                else
                    textCaminhoVut.Text = "";

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

        private void button11_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoVUT();
            bool erro = objPreco.Validar(textCaminhoVut.Text);
            objPreco = null;
            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
                MessageBox.Show("Arquivo validado com sucesso!");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DETRAF.BLL.Preco objPreco = new DETRAF.BLL.PrecoVUT();
            bool erro = objPreco.Validar(textCaminhoVut.Text);

            if (erro)
                MessageBox.Show("Favor verificar o arquivo de críticas!");
            else
            {
                objPreco.Processar(textCaminhoVut.Text);
                MessageBox.Show("Arquivo Processado!");
            }
            objPreco = null;
        }
    }
}