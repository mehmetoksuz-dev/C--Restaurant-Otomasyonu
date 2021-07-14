
namespace Siparis_Programı
{
    partial class Rezervasyon
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
            this.btnRezerveEt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_RezDate = new System.Windows.Forms.DateTimePicker();
            this.mskRezTel = new System.Windows.Forms.MaskedTextBox();
            this.txt_musteriAdi = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_MusteriSoyad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRezerveEt
            // 
            this.btnRezerveEt.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezerveEt.Location = new System.Drawing.Point(367, 291);
            this.btnRezerveEt.Name = "btnRezerveEt";
            this.btnRezerveEt.Size = new System.Drawing.Size(168, 55);
            this.btnRezerveEt.TabIndex = 51;
            this.btnRezerveEt.Text = "REZERVE ET";
            this.btnRezerveEt.UseVisualStyleBackColor = true;
            this.btnRezerveEt.Click += new System.EventHandler(this.btnRezerveEt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_RezDate);
            this.groupBox1.Controls.Add(this.mskRezTel);
            this.groupBox1.Controls.Add(this.txt_musteriAdi);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txt_MusteriSoyad);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(103, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 258);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Müşteri";
            // 
            // dtp_RezDate
            // 
            this.dtp_RezDate.CustomFormat = "MMMM dd , yyyy - HH:mm";
            this.dtp_RezDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_RezDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_RezDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtp_RezDate.Location = new System.Drawing.Point(200, 194);
            this.dtp_RezDate.Name = "dtp_RezDate";
            this.dtp_RezDate.Size = new System.Drawing.Size(300, 32);
            this.dtp_RezDate.TabIndex = 27;
            this.dtp_RezDate.Value = new System.DateTime(2021, 7, 7, 0, 0, 0, 0);
            // 
            // mskRezTel
            // 
            this.mskRezTel.Location = new System.Drawing.Point(200, 135);
            this.mskRezTel.Mask = "(999) 000-0000";
            this.mskRezTel.Name = "mskRezTel";
            this.mskRezTel.Size = new System.Drawing.Size(300, 32);
            this.mskRezTel.TabIndex = 25;
            // 
            // txt_musteriAdi
            // 
            this.txt_musteriAdi.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_musteriAdi.Location = new System.Drawing.Point(200, 42);
            this.txt_musteriAdi.Name = "txt_musteriAdi";
            this.txt_musteriAdi.Size = new System.Drawing.Size(300, 32);
            this.txt_musteriAdi.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(62, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 23);
            this.label13.TabIndex = 14;
            this.label13.Text = "Müşteri Adı";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(98, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 16;
            this.label12.Text = "Telefon";
            // 
            // txt_MusteriSoyad
            // 
            this.txt_MusteriSoyad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_MusteriSoyad.Location = new System.Drawing.Point(200, 89);
            this.txt_MusteriSoyad.Name = "txt_MusteriSoyad";
            this.txt_MusteriSoyad.Size = new System.Drawing.Size(300, 32);
            this.txt_MusteriSoyad.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(29, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Müşteri Soyadı";
            // 
            // Rezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(87)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRezerveEt);
            this.Controls.Add(this.groupBox1);
            this.Name = "Rezervasyon";
            this.Text = "Rezervasyon";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRezerveEt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mskRezTel;
        private System.Windows.Forms.TextBox txt_musteriAdi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_MusteriSoyad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_RezDate;
    }
}