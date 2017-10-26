namespace DETRAF.VIEW
{
    partial class FormDetraf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDebito = new System.Windows.Forms.RadioButton();
            this.radioButtonCredito = new System.Windows.Forms.RadioButton();
            this.comboBoxTipoDetraf = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxModalidadeLigacao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxComOperadora = new System.Windows.Forms.TextBox();
            this.textBoxDataFinal = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBoxOperadora = new System.Windows.Forms.TextBox();
            this.textBoxDataInicial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelResposta = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "PROCESAMENTO DETRAF";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDebito);
            this.groupBox1.Controls.Add(this.radioButtonCredito);
            this.groupBox1.Controls.Add(this.comboBoxTipoDetraf);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBoxModalidadeLigacao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxComOperadora);
            this.groupBox1.Controls.Add(this.textBoxDataFinal);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBoxOperadora);
            this.groupBox1.Controls.Add(this.textBoxDataInicial);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detraf";
            // 
            // radioButtonDebito
            // 
            this.radioButtonDebito.AutoSize = true;
            this.radioButtonDebito.Location = new System.Drawing.Point(102, 93);
            this.radioButtonDebito.Name = "radioButtonDebito";
            this.radioButtonDebito.Size = new System.Drawing.Size(56, 17);
            this.radioButtonDebito.TabIndex = 10;
            this.radioButtonDebito.TabStop = true;
            this.radioButtonDebito.Text = "Débito";
            this.radioButtonDebito.UseVisualStyleBackColor = true;
            // 
            // radioButtonCredito
            // 
            this.radioButtonCredito.AutoSize = true;
            this.radioButtonCredito.Location = new System.Drawing.Point(10, 93);
            this.radioButtonCredito.Name = "radioButtonCredito";
            this.radioButtonCredito.Size = new System.Drawing.Size(58, 17);
            this.radioButtonCredito.TabIndex = 9;
            this.radioButtonCredito.TabStop = true;
            this.radioButtonCredito.Text = "Crédito";
            this.radioButtonCredito.UseVisualStyleBackColor = true;
            // 
            // comboBoxTipoDetraf
            // 
            this.comboBoxTipoDetraf.FormattingEnabled = true;
            this.comboBoxTipoDetraf.Items.AddRange(new object[] {
            "Batimento",
            "Desbalanceamento",
            "Detalhado",
            "Resumido"});
            this.comboBoxTipoDetraf.Location = new System.Drawing.Point(506, 50);
            this.comboBoxTipoDetraf.Name = "comboBoxTipoDetraf";
            this.comboBoxTipoDetraf.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoDetraf.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tipo de Detraf:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(687, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calcular Detraf";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxModalidadeLigacao
            // 
            this.comboBoxModalidadeLigacao.FormattingEnabled = true;
            this.comboBoxModalidadeLigacao.Items.AddRange(new object[] {
            "Local",
            "Nacional",
            "Transito Local",
            "Transporte"});
            this.comboBoxModalidadeLigacao.Location = new System.Drawing.Point(506, 12);
            this.comboBoxModalidadeLigacao.Name = "comboBoxModalidadeLigacao";
            this.comboBoxModalidadeLigacao.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModalidadeLigacao.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Modalidade da Ligação:";
            // 
            // textBoxComOperadora
            // 
            this.textBoxComOperadora.Location = new System.Drawing.Point(273, 52);
            this.textBoxComOperadora.Name = "textBoxComOperadora";
            this.textBoxComOperadora.Size = new System.Drawing.Size(100, 20);
            this.textBoxComOperadora.TabIndex = 1;
            // 
            // textBoxDataFinal
            // 
            this.textBoxDataFinal.Location = new System.Drawing.Point(273, 12);
            this.textBoxDataFinal.Name = "textBoxDataFinal";
            this.textBoxDataFinal.Size = new System.Drawing.Size(100, 20);
            this.textBoxDataFinal.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(273, 52);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 1;
            // 
            // textBoxOperadora
            // 
            this.textBoxOperadora.Location = new System.Drawing.Point(77, 52);
            this.textBoxOperadora.Name = "textBoxOperadora";
            this.textBoxOperadora.Size = new System.Drawing.Size(100, 20);
            this.textBoxOperadora.TabIndex = 1;
            // 
            // textBoxDataInicial
            // 
            this.textBoxDataInicial.Location = new System.Drawing.Point(77, 12);
            this.textBoxDataInicial.Name = "textBoxDataInicial";
            this.textBoxDataInicial.Size = new System.Drawing.Size(100, 20);
            this.textBoxDataInicial.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Com Operadora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data Final:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Operadora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Inicial:";
            // 
            // labelResposta
            // 
            this.labelResposta.AutoSize = true;
            this.labelResposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResposta.Location = new System.Drawing.Point(19, 228);
            this.labelResposta.Name = "labelResposta";
            this.labelResposta.Size = new System.Drawing.Size(0, 16);
            this.labelResposta.TabIndex = 3;
            // 
            // FormDetraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.labelResposta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormDetraf";
            this.Text = "Detraf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormDetraf_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDataInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxModalidadeLigacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxComOperadora;
        private System.Windows.Forms.TextBox textBoxDataFinal;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBoxOperadora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxTipoDetraf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelResposta;
        private System.Windows.Forms.RadioButton radioButtonDebito;
        private System.Windows.Forms.RadioButton radioButtonCredito;
    }
}