namespace Klijent
{
    partial class FormaKlijent
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNazivLinije = new System.Windows.Forms.TextBox();
            this.cmbPocetna = new System.Windows.Forms.ComboBox();
            this.cmbMedjustanica = new System.Windows.Forms.ComboBox();
            this.cmbKrajnja = new System.Windows.Forms.ComboBox();
            this.btnDodajMedjuStanicu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSacuvajLiniju = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSacuvajLiniju);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnDodajMedjuStanicu);
            this.groupBox1.Controls.Add(this.cmbKrajnja);
            this.groupBox1.Controls.Add(this.cmbMedjustanica);
            this.groupBox1.Controls.Add(this.cmbPocetna);
            this.groupBox1.Controls.Add(this.txtNazivLinije);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unos linije";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv linije:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pocetna stanica:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Krajnja stanica:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Medjustanice:";
            // 
            // txtNazivLinije
            // 
            this.txtNazivLinije.Location = new System.Drawing.Point(106, 29);
            this.txtNazivLinije.Name = "txtNazivLinije";
            this.txtNazivLinije.ReadOnly = true;
            this.txtNazivLinije.Size = new System.Drawing.Size(232, 20);
            this.txtNazivLinije.TabIndex = 4;
            // 
            // cmbPocetna
            // 
            this.cmbPocetna.FormattingEnabled = true;
            this.cmbPocetna.Location = new System.Drawing.Point(106, 63);
            this.cmbPocetna.Name = "cmbPocetna";
            this.cmbPocetna.Size = new System.Drawing.Size(232, 21);
            this.cmbPocetna.TabIndex = 5;
            this.cmbPocetna.SelectedIndexChanged += new System.EventHandler(this.cmbPocetna_SelectedIndexChanged);
            // 
            // cmbMedjustanica
            // 
            this.cmbMedjustanica.FormattingEnabled = true;
            this.cmbMedjustanica.Location = new System.Drawing.Point(106, 128);
            this.cmbMedjustanica.Name = "cmbMedjustanica";
            this.cmbMedjustanica.Size = new System.Drawing.Size(232, 21);
            this.cmbMedjustanica.TabIndex = 6;
            // 
            // cmbKrajnja
            // 
            this.cmbKrajnja.FormattingEnabled = true;
            this.cmbKrajnja.Location = new System.Drawing.Point(106, 96);
            this.cmbKrajnja.Name = "cmbKrajnja";
            this.cmbKrajnja.Size = new System.Drawing.Size(232, 21);
            this.cmbKrajnja.TabIndex = 7;
            this.cmbKrajnja.SelectedIndexChanged += new System.EventHandler(this.cmbKrajnja_SelectedIndexChanged);
            // 
            // btnDodajMedjuStanicu
            // 
            this.btnDodajMedjuStanicu.Location = new System.Drawing.Point(10, 162);
            this.btnDodajMedjuStanicu.Name = "btnDodajMedjuStanicu";
            this.btnDodajMedjuStanicu.Size = new System.Drawing.Size(175, 37);
            this.btnDodajMedjuStanicu.TabIndex = 8;
            this.btnDodajMedjuStanicu.Text = "Dodaj medjustanicu";
            this.btnDodajMedjuStanicu.UseVisualStyleBackColor = true;
            this.btnDodajMedjuStanicu.Click += new System.EventHandler(this.btnDodajMedjuStanicu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(328, 80);
            this.dataGridView1.TabIndex = 9;
            // 
            // btnSacuvajLiniju
            // 
            this.btnSacuvajLiniju.Location = new System.Drawing.Point(10, 292);
            this.btnSacuvajLiniju.Name = "btnSacuvajLiniju";
            this.btnSacuvajLiniju.Size = new System.Drawing.Size(175, 29);
            this.btnSacuvajLiniju.TabIndex = 10;
            this.btnSacuvajLiniju.Text = "Sacuvaj liniju";
            this.btnSacuvajLiniju.UseVisualStyleBackColor = true;
            this.btnSacuvajLiniju.Click += new System.EventHandler(this.btnSacuvajLiniju_Click);
            // 
            // FormaKlijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 355);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormaKlijent";
            this.Text = "Design Preview [FrmKlijent]";
            this.Load += new System.EventHandler(this.FormaKlijent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSacuvajLiniju;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDodajMedjuStanicu;
        private System.Windows.Forms.ComboBox cmbKrajnja;
        private System.Windows.Forms.ComboBox cmbMedjustanica;
        private System.Windows.Forms.ComboBox cmbPocetna;
        private System.Windows.Forms.TextBox txtNazivLinije;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

