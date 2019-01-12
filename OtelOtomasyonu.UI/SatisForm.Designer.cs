namespace OtelOtomasyonu.UI
{
    partial class SatisForm
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
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.cmbOda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudOdaFiyati = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.nudUrunMiktarı = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudUrunFiyati = new System.Windows.Forms.NumericUpDown();
            this.nudIndirim = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSatisaEkle = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnKatdet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbKasaOdemeTip = new System.Windows.Forms.ComboBox();
            this.btnListviewTemizle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTutar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudOdaFiyati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUrunMiktarı)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUrunFiyati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndirim)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Honeydew;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Müşteri";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.BackColor = System.Drawing.Color.LightCyan;
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Location = new System.Drawing.Point(24, 42);
            this.cmbMusteri.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(180, 26);
            this.cmbMusteri.TabIndex = 0;
            // 
            // cmbOda
            // 
            this.cmbOda.BackColor = System.Drawing.Color.LightCyan;
            this.cmbOda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOda.FormattingEnabled = true;
            this.cmbOda.Location = new System.Drawing.Point(224, 42);
            this.cmbOda.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOda.Name = "cmbOda";
            this.cmbOda.Size = new System.Drawing.Size(180, 26);
            this.cmbOda.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Honeydew;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(224, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Oda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Honeydew;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(418, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Oda Ekstra Servis";
            // 
            // nudOdaFiyati
            // 
            this.nudOdaFiyati.Location = new System.Drawing.Point(418, 44);
            this.nudOdaFiyati.Margin = new System.Windows.Forms.Padding(4);
            this.nudOdaFiyati.Name = "nudOdaFiyati";
            this.nudOdaFiyati.Size = new System.Drawing.Size(184, 24);
            this.nudOdaFiyati.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Location = new System.Drawing.Point(24, 97);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(647, 483);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Honeydew;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(690, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ürün Miktarı";
            // 
            // nudUrunMiktarı
            // 
            this.nudUrunMiktarı.Location = new System.Drawing.Point(690, 121);
            this.nudUrunMiktarı.Margin = new System.Windows.Forms.Padding(4);
            this.nudUrunMiktarı.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudUrunMiktarı.Name = "nudUrunMiktarı";
            this.nudUrunMiktarı.Size = new System.Drawing.Size(180, 24);
            this.nudUrunMiktarı.TabIndex = 4;
            this.nudUrunMiktarı.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Honeydew;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(690, 176);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ürün Fiyatı";
            // 
            // nudUrunFiyati
            // 
            this.nudUrunFiyati.Location = new System.Drawing.Point(690, 200);
            this.nudUrunFiyati.Margin = new System.Windows.Forms.Padding(4);
            this.nudUrunFiyati.Name = "nudUrunFiyati";
            this.nudUrunFiyati.Size = new System.Drawing.Size(180, 24);
            this.nudUrunFiyati.TabIndex = 5;
            // 
            // nudIndirim
            // 
            this.nudIndirim.Location = new System.Drawing.Point(690, 270);
            this.nudIndirim.Margin = new System.Windows.Forms.Padding(4);
            this.nudIndirim.Name = "nudIndirim";
            this.nudIndirim.Size = new System.Drawing.Size(180, 24);
            this.nudIndirim.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Honeydew;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(690, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "İndirim";
            // 
            // btnSatisaEkle
            // 
            this.btnSatisaEkle.BackColor = System.Drawing.Color.Ivory;
            this.btnSatisaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisaEkle.Image = global::OtelOtomasyonu.UI.Properties.Resources.arti;
            this.btnSatisaEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatisaEkle.Location = new System.Drawing.Point(690, 395);
            this.btnSatisaEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnSatisaEkle.Name = "btnSatisaEkle";
            this.btnSatisaEkle.Size = new System.Drawing.Size(150, 45);
            this.btnSatisaEkle.TabIndex = 7;
            this.btnSatisaEkle.Text = "Satışa Ekle";
            this.btnSatisaEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSatisaEkle.UseVisualStyleBackColor = false;
            this.btnSatisaEkle.Click += new System.EventHandler(this.btnSatisaEkle_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(878, 97);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(469, 388);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sıra No";
            this.columnHeader1.Width = 53;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ürün Adı";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Miktar";
            this.columnHeader3.Width = 128;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fiyat";
            this.columnHeader4.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "İndirim";
            this.columnHeader5.Width = 78;
            // 
            // btnKatdet
            // 
            this.btnKatdet.BackColor = System.Drawing.Color.Ivory;
            this.btnKatdet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKatdet.Image = global::OtelOtomasyonu.UI.Properties.Resources.arti;
            this.btnKatdet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKatdet.Location = new System.Drawing.Point(878, 512);
            this.btnKatdet.Margin = new System.Windows.Forms.Padding(4);
            this.btnKatdet.Name = "btnKatdet";
            this.btnKatdet.Size = new System.Drawing.Size(150, 45);
            this.btnKatdet.TabIndex = 9;
            this.btnKatdet.Text = "Satışı Onayla";
            this.btnKatdet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKatdet.UseVisualStyleBackColor = false;
            this.btnKatdet.Click += new System.EventHandler(this.btnKatdet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Honeydew;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(690, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ödeme Tipi";
            // 
            // cmbKasaOdemeTip
            // 
            this.cmbKasaOdemeTip.BackColor = System.Drawing.Color.LightCyan;
            this.cmbKasaOdemeTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKasaOdemeTip.FormattingEnabled = true;
            this.cmbKasaOdemeTip.Location = new System.Drawing.Point(690, 344);
            this.cmbKasaOdemeTip.Name = "cmbKasaOdemeTip";
            this.cmbKasaOdemeTip.Size = new System.Drawing.Size(121, 26);
            this.cmbKasaOdemeTip.TabIndex = 17;
            // 
            // btnListviewTemizle
            // 
            this.btnListviewTemizle.BackColor = System.Drawing.Color.Ivory;
            this.btnListviewTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListviewTemizle.Location = new System.Drawing.Point(1058, 55);
            this.btnListviewTemizle.Name = "btnListviewTemizle";
            this.btnListviewTemizle.Size = new System.Drawing.Size(132, 35);
            this.btnListviewTemizle.TabIndex = 18;
            this.btnListviewTemizle.Text = "Listeyi Temizle";
            this.btnListviewTemizle.UseVisualStyleBackColor = false;
            this.btnListviewTemizle.Click += new System.EventHandler(this.btnListviewTemizle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(1044, 525);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Toplam Tutar:";
            // 
            // lblTutar
            // 
            this.lblTutar.AutoSize = true;
            this.lblTutar.Location = new System.Drawing.Point(1163, 525);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(0, 18);
            this.lblTutar.TabIndex = 20;
            // 
            // SatisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.ControlBox = false;
            this.Controls.Add(this.lblTutar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnListviewTemizle);
            this.Controls.Add(this.cmbKasaOdemeTip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnKatdet);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnSatisaEkle);
            this.Controls.Add(this.nudIndirim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudUrunFiyati);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudUrunMiktarı);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nudOdaFiyati);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbOda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMusteri);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SatisForm";
            this.Text = "Satis";
            this.Load += new System.EventHandler(this.SatisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudOdaFiyati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUrunMiktarı)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUrunFiyati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndirim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.ComboBox cmbOda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudOdaFiyati;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudUrunMiktarı;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudUrunFiyati;
        private System.Windows.Forms.NumericUpDown nudIndirim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSatisaEkle;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnKatdet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbKasaOdemeTip;
        private System.Windows.Forms.Button btnListviewTemizle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTutar;
    }
}