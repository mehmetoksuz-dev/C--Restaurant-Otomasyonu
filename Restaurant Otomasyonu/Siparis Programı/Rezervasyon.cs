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
    public partial class Rezervasyon : Form
    {
        public static int kontrol = 0;

        public Rezervasyon()
        {
            InitializeComponent();
        }
        private void btnRezerveEt_Click(object sender, EventArgs e)
        {
            string srRezQuery = "INSERT INTO Rezervasyon (RezAd,RezSoyAd,RezTelefon,RezTarih) values (@RezAd,@RezSoyAd,@RezTelefon,@RezTarih)";
            List<dbConnection.cmdParameterType> lstParam = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@RezAd",txt_musteriAdi.Text),
                new dbConnection.cmdParameterType("@RezSoyAd",txt_MusteriSoyad.Text),
                new dbConnection.cmdParameterType("@RezTelefon", mskRezTel.Text),
                new dbConnection.cmdParameterType("@RezTarih", dtp_RezDate.Value)
            };

            if (dbConnection.cmd_update_DB(srRezQuery, lstParam) > 0)
            {
                MessageBox.Show("Lütfen masa seçin");
                kontrol = 1;
            }
            
        }
    }
}
