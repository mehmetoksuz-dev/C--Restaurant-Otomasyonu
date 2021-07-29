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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string a = txt_Sifre.Text;
                txt_Sifre.PasswordChar = '\0';
            }
            else
            {
                txt_Sifre.PasswordChar = '*';
            }
        }


        private void txt_kAdi_TextChanged(object sender, EventArgs e)
        {
            txt_kAdi.BorderStyle = BorderStyle.None;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Sifre_TextChanged(object sender, EventArgs e)
        {
            txt_Sifre.BorderStyle = BorderStyle.None;
        }

        Object[] user;
        public static bool blLoginType = false;
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string passCheckQuery = "select * from Kullanıcılar where KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre";
            try
            {
                List<dbConnection.cmdParameterType> loginParams = new List<dbConnection.cmdParameterType> {
                    new dbConnection.cmdParameterType("@KullaniciAdi",txt_kAdi.Text),
                    new dbConnection.cmdParameterType("@Sifre",txt_Sifre.Text)
                };

                user = dbConnection.cmd_Select_DB(passCheckQuery, loginParams).Rows[0].ItemArray;
            }
            catch (Exception E)
            {
                MessageBox.Show("Kullanıcı Bulunamadı.");
                return;
            }
            string name = user[1].ToString();
            string pass = user[2].ToString();
            string rol = user[3].ToString();

            if (txt_kAdi.Text == name && txt_Sifre.Text == pass) //Id Pw kontrolü
            {
                if (Convert.ToInt32(rol) == 1) //admin girişi (tam erişim)
                {
                    blLoginType = true;
                    Menuler adminMenu = new Menuler();
                    adminMenu.Show();
                    this.Hide();
                }
                else if(Convert.ToInt32(rol) == 2) //garson girişi (kısıtlı yetki)
                {
                    blLoginType = false;
                    Menuler garsonMenu = new Menuler();
                    garsonMenu.Show();
                }
            }

        }
    }
}
