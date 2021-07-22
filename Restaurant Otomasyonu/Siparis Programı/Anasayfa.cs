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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void menu_Load(object sender, EventArgs e)
        {
            btn_menu.Enabled = false;
        }

        private void btn_masalar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menuler masalarForm = new Menuler();
            masalarForm.Show();
        }

        private void btn_rezerv_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menuler ms = new Menuler();
            ms.Show();
            ms.tabControl1.SelectTab(1);
            
        }
    }
}
