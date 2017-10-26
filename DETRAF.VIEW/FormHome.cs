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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private FormPrefixoAdd objPrefixo;
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Abre a janela de Importação de EOT´s e não permite abrir novamente a mesma janela
            if (objPrefixo != null)
            {
                this.objPrefixo.Activate();
            }
            else
            {
                this.objPrefixo = new FormPrefixoAdd();
                objPrefixo.MdiParent = this;
                this.objPrefixo.Closed += delegate { this.objPrefixo = null; };
                this.objPrefixo.Show();
            }
        }

        private FormCdrAdd objCdr;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Abre a janela de Importação de CDR´s e não permite abrir novamente a mesma janela
            if (objCdr != null)
            {
                this.objCdr.Activate();
            }
            else
            {
                this.objCdr = new FormCdrAdd();
                objCdr.MdiParent = this;
                this.objCdr.Closed += delegate { this.objCdr = null; };
                this.objCdr.Show();
            }
        }
        
        private FormTabelaPrecoAdd objTab;
        private void pREÇOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre a janela de Importação de CDR´s e não permite abrir novamente a mesma janela
            if (objTab != null)
            {
                this.objTab.Activate();
            }
            else
            {
                this.objTab = new FormTabelaPrecoAdd();
                objTab.MdiParent = this;
                this.objTab.Closed += delegate { this.objTab = null; };
                this.objTab.Show();
            }
        }
        private FormDetraf objDetraf;
        private void detrafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre a janela de Importação de CDR´s e não permite abrir novamente a mesma janela
            if (objDetraf != null)
            {
                this.objDetraf.Activate();
            }
            else
            {
                this.objDetraf = new FormDetraf();
                objDetraf.MdiParent = this;
                this.objDetraf.Closed += delegate { this.objDetraf = null; };
                this.objDetraf.Show();
            }
        }

        private FormEOT objEOT;
        private void eOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abre a janela de Importação de EOT´s e não permite abrir novamente a mesma janela
            if (objEOT != null)
            {
                this.objEOT.Activate();
            }
            else
            {
                this.objEOT = new FormEOT();
                objEOT.MdiParent = this;
                this.objEOT.Closed += delegate { this.objEOT = null; };
                this.objEOT.Show();
            }
        }
    }
}
