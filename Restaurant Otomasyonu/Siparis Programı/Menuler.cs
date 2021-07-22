using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siparis_Programı
{
    public partial class Menuler : Form
    {
        public Menuler()
        {
            InitializeComponent();
            
        }
        private void Menuler_Load(object sender, EventArgs e)
        {
            masaGetir();
            RezGetir();
            MusteriGetir();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void masaGetir()
        {
            int bahceMasa, iceriMasa;
            string srMasaAdi, srMasaRengi;
            string srMasaSayisiQuery = "select * from Ayarlar";
            //new
            string srMasaRenk = "select * from Masalar";
            DataTable dTable = dbConnection.return_data_set(srMasaSayisiQuery, out string Message).Tables[0];
            DataTable dTblMasaRenk = dbConnection.return_data_set(srMasaRenk, out string Msg).Tables[0];
            if (dTable.Rows.Count > 0)
            {
                //MessageBox.Show("Veri Var");
            }
            else { MessageBox.Show("Veri Yok"); return; }

            if (dTblMasaRenk.Rows.Count >0)
            {
                //
            }
            else { MessageBox.Show("Masa Renk Veri Yok"); return; }

            Object[] masaSayilari = dTable.Rows[0].ItemArray; //tum veriler
            //0. index bahce masa sayisi, 1. index iceri masa sayisi

            iceriMasa = Convert.ToInt32(masaSayilari[1]);
            bahceMasa = Convert.ToInt32(masaSayilari[0]);
            int x = 40, y = 30, bx = 0;
            for (int i = 0; i < iceriMasa+1; i++)
            {
                Object[] masaRenk = dTblMasaRenk.Rows[i].ItemArray;
                y += -20;
                x = 60;

                bx = x;
                Button btn = new Button();
                Point btnYer = new Point(y + 5,bx - 50);
                btn.Location = btnYer;
                btn.Width = 100;
                btn.Height = 60;
                btn.Name = "btn" + i;
                btn.Text = "Masa "+(i+1).ToString();
                srMasaAdi = masaRenk[1].ToString();
                srMasaRengi = masaRenk[2].ToString();
                if (btn.Text == srMasaAdi)
                {
                    if (srMasaRengi == "Green") //bos
                    {
                        btn.BackColor = Color.FromArgb(67, 172, 29);
                    }
                    else if (srMasaRengi == "Red") //dolu
                    {
                        btn.BackColor = Color.Red;
                    }
                    else if (srMasaRengi == "Orange") //rezerve
                    {
                        btn.BackColor = Color.Orange;
                    }
                }
                btn.ForeColor = Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 14.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.BorderColor = Color.White;
                btn.ContextMenuStrip = contextMenuStrip1;

                panel4.Controls.Add(btn);

                y += 130;

                if (i<=bahceMasa-1)
                {
                    Button btnBahce = new Button();
                    Point BahceBtnYer = new Point(y + 5, bx - 50);
                    btnBahce.Location = btnYer;
                    btnBahce.Width = 100;
                    btnBahce.Height = 60;
                    btnBahce.Name = "btn" + i;
                    btnBahce.Text = "Masa " + (i+1).ToString();
                    btnBahce.BackColor = Color.FromArgb(67, 172, 29);
                    btnBahce.ForeColor = Color.White;
                    btnBahce.Font = new System.Drawing.Font("Segoe UI", 14.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    btnBahce.FlatStyle = FlatStyle.Flat;
                    btnBahce.FlatAppearance.BorderSize = 2;
                    btnBahce.FlatAppearance.BorderColor = Color.White;
                    btnBahce.ContextMenuStrip = contextMenuStrip1;
                    panel5.Controls.Add(btnBahce);
                }
                btn.Click += new EventHandler(masaControl);
            }
        }
        
        public void RezGetir()
        {
            string rezQuery = "select RezervasyonId,RezAd,RezSoyAd,RezTelefon,RezTarih,RezMasa from Rezervasyon";
            DataTable dtRez = dbConnection.return_data_set(rezQuery, out string Msg).Tables[0];
            for (int i = 0; i < dtRez.Rows.Count; i++)
            {
                Object[] rezervasyonVerileri = dtRez.Rows[i].ItemArray;
                dataGridRez.Rows.Add(rezervasyonVerileri);
            }
        }

        public void MusteriGetir()
        {
            string musteriQry = "select * from Musteriler";
            DataTable dtMusteri = dbConnection.return_data_set(musteriQry, out string Msg).Tables[0];
            for (int i = 0; i < dtMusteri.Rows.Count; i++)
            {
                Object[] musteriVerileri = dtMusteri.Rows[i].ItemArray;
                dataGridMusteriler.Rows.Add(musteriVerileri);
            }
        }
        private void siparisHazırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            if (txt_musteriAdi.Text == "" || txt_MusteriSoyad.Text=="" || mskdtxt_MusteriTel.Text == "" || txt_MusteriAdres.Text=="")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz.");
                return;
            }

            string srMusteriQuery = "INSERT INTO Musteriler (MusteriAd,MusteriSoyad,MusteriTelefon,MusteriAdres) values (@MusteriAd,@MusteriSoyad,@MusteriTelefon,@MusteriAdres)";

            List<dbConnection.cmdParameterType> lstParam = new List<dbConnection.cmdParameterType> { 
                new dbConnection.cmdParameterType("@MusteriAd", txt_musteriAdi.Text),
                new dbConnection.cmdParameterType("@MusteriSoyad", txt_MusteriSoyad.Text),
                new dbConnection.cmdParameterType("@MusteriTelefon", mskdtxt_MusteriTel.Text),
                new dbConnection.cmdParameterType("@MusteriAdres", txt_MusteriAdres.Text)
            };

            if (dbConnection.cmd_update_DB(srMusteriQuery, lstParam) > 0)
            {
                MessageBox.Show("Musteri Basariyla Kaydedildi!");
            }
            
        }
       
        private void btnMasalar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        } 
        private void btnRezervasyonlar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnEkleMusteri_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void rezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Rezervasyon rez = new Rezervasyon();
                rez.Show();

        }

        public static void masaControl(object sender, EventArgs e)
        {
            if (Rezervasyon.kontrol == 1)
            {
                Button dinamikButton = (sender as Button);
                string rezQuery = "update Masalar set MasaRenk=@MasaRenk where MasaAd=@MasaAd";
                List<dbConnection.cmdParameterType> rezParams = new List<dbConnection.cmdParameterType>
                {
                    new dbConnection.cmdParameterType("@MasaRenk","Orange"),
                    new dbConnection.cmdParameterType("@MasaAd", dinamikButton.Text)
                };

                if (dbConnection.cmd_update_DB(rezQuery,rezParams) > 0)
                {
                    dinamikButton.BackColor = Color.Orange;
                    int rezId;
                    DataTable dtId = dbConnection.return_data_set("SELECT top 1 * FROM Rezervasyon order by RezervasyonId desc ", out string msg).Tables[0];
                    Object[] objId = dtId.Rows[0].ItemArray;
                    rezId = Convert.ToInt32(objId[0]);
                    string srRezMasaQry = "update Rezervasyon set RezMasa=@RezMasa where RezervasyonId=@RezervasyonId";
                    List<dbConnection.cmdParameterType> lstRezParam = new List<dbConnection.cmdParameterType>
                    {
                        new dbConnection.cmdParameterType("@RezMasa",dinamikButton.Text),
                        new dbConnection.cmdParameterType("@RezervasyonId", rezId)
                    };

                    if (dbConnection.cmd_update_DB(srRezMasaQry, lstRezParam)>0)
                    {
                        MessageBox.Show("Müşterinin Rezervasyonu Tamamlandı. Masa : " +dinamikButton.Text);
                        //Rezervasyon.kontrol = 0;
                    }
                }
                else { MessageBox.Show("Bir Hata oluştu"); return; }                
            }   
        }

        int id = 0;
        private void dataGridRez_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridRez.CurrentRow.Cells[0].Value.ToString()); 
            txt_RezervName.Text = dataGridRez.CurrentRow.Cells[1].Value.ToString();
            txtRezervSoyad.Text = dataGridRez.CurrentRow.Cells[2].Value.ToString();
            mskRezTel.Text = dataGridRez.CurrentRow.Cells[3].Value.ToString();
            dtp_RezervDate.Value = Convert.ToDateTime(dataGridRez.CurrentRow.Cells[4].Value);
            txt_RezervMasa.Text = dataGridRez.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnUpdateRez_Click(object sender, EventArgs e)
        {
            string updateRezQry = "update Rezervasyon set RezAd=@RezAd,RezSoyAd=@RezSoyad,RezTelefon=@RezTelefon,RezTarih=@RezTarih,RezMasa=@RezMasa where RezervasyonId=@RezervasyonId";
            List<dbConnection.cmdParameterType> rezParam = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@RezAd",txt_RezervName.Text),
                new dbConnection.cmdParameterType("@RezSoyad",txtRezervSoyad.Text),
                new dbConnection.cmdParameterType("@RezTelefon",mskRezTel.Text),
                new dbConnection.cmdParameterType("@RezTarih",dtp_RezervDate.Value),
                new dbConnection.cmdParameterType("@RezMasa",txt_RezervMasa.Text),
                new dbConnection.cmdParameterType("@RezervasyonId",id)
            };

            if (dbConnection.cmd_update_DB(updateRezQry, rezParam) > 0)
            {
                MessageBox.Show("Müşterinin rezervasyon bilgileri güncellenmiştir.");
                dataGridRez.Rows.Clear();
                RezGetir();
            }
            else { MessageBox.Show("Bir Hata oluştu"); return; }

        }

        private void btnDeleteRez_Click(object sender, EventArgs e)
        {
            string srDeleteRezQry = "DELETE FROM Rezervasyon WHERE RezervasyonId=@RezervasyonId";
            List<dbConnection.cmdParameterType> delPrm = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@RezervasyonId", id)
            };

            if (dbConnection.cmd_update_DB(srDeleteRezQry,delPrm) > 0)
            {
                MessageBox.Show("Müşterinin rezervasyonu silinmiştir.");
                dataGridRez.Rows.Clear();
                RezGetir();
            }
            else { MessageBox.Show("Bir Hata oluştu"); return; }
        }

        int musteriId = 0;
        private void dataGridMusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            musteriId = int.Parse(dataGridMusteriler.CurrentRow.Cells[0].Value.ToString());
            txtUpdateName.Text = dataGridMusteriler.CurrentRow.Cells[1].Value.ToString();
            txtUpdateSurName.Text = dataGridMusteriler.CurrentRow.Cells[2].Value.ToString();
            txtUpdateTel.Text = dataGridMusteriler.CurrentRow.Cells[3].Value.ToString();
            txtUpdateAdres.Text = dataGridMusteriler.CurrentRow.Cells[4].Value.ToString();
        }

        private void btn_musteri_guncelle_Click(object sender, EventArgs e)
        {
            string updateMusteriQry = "update Musteriler set MusteriAd=@MusteriAd, MusteriSoyad=@MusteriSoyad, MusteriTelefon=@MusteriTelefon, MusteriAdres=@MusteriAdres where MusteriId=@MusteriId";
            List<dbConnection.cmdParameterType> musteriParam = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@MusteriAd",txtUpdateName.Text),
                new dbConnection.cmdParameterType("@MusteriSoyad",txtUpdateSurName.Text),
                new dbConnection.cmdParameterType("@MusteriTelefon",txtUpdateTel.Text),
                new dbConnection.cmdParameterType("@MusteriAdres",txtUpdateAdres.Text),
                new dbConnection.cmdParameterType("@MusteriId",musteriId)
            };

            if (dbConnection.cmd_update_DB(updateMusteriQry, musteriParam) > 0)
            {
                MessageBox.Show("Müşterinin bilgileri güncellenmiştir.");
                dataGridMusteriler.Rows.Clear();
                MusteriGetir();
            }
            else { MessageBox.Show("Bir Hata oluştu"); return; }
        }

        private void btn_musteri_sil_Click(object sender, EventArgs e)
        {
            string srMusteriSilQry = "DELETE FROM Musteriler WHERE MusteriId=@MusteriId";
            List<dbConnection.cmdParameterType> delPrm = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@MusteriId", musteriId)
            };

            if (dbConnection.cmd_update_DB(srMusteriSilQry, delPrm) > 0)
            {
                MessageBox.Show("Müşterinin rezervasyonu silinmiştir.");
                dataGridMusteriler.Rows.Clear();
                HelperClass.ClearTextBoxes(groupBox2.Controls);
                MusteriGetir();
            }
            else { MessageBox.Show("Bir Hata oluştu"); return; }
        }
    }
}
