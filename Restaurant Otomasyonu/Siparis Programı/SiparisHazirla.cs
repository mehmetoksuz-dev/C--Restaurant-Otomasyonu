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
    public partial class SiparisHazirla : Form
    {
        DataTable dataTable = new DataTable();

        public SiparisHazirla()
        {
            InitializeComponent();

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string searchValue = txtAra.Text;
            dtSiparisMusteri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in dtSiparisMusteri.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Contains(searchValue))
                        {
                            int rowIndex = row.Index;
                            dtSiparisMusteri.Rows[rowIndex].Selected = true;
                            valueResult = true;
                            break;
                        }
                    }

                }
                if (!valueResult)
                {
                    MessageBox.Show("Unable to find " + txtAra.Text, "Not Found");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SiparisHazirla_Load(object sender, EventArgs e)
        {
            Menuler.MusteriGetir(dtSiparisMusteri);
        }



        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            string srSiparisQry = "INSERT INTO Siparisler (SiparisTuru,SiparisDetay,SiparisTutar,MusteriId) values (@SiparisTuru,@SiparisDetay,@SiparisTutar,@MusteriId)";
            if (cmbAnaYemek.SelectedIndex!=-1 || cmbAperatifler.SelectedIndex !=-1 || cmbTatlilar.SelectedIndex !=-1 || cmbIcecek.SelectedIndex !=-1)
            {
                string[] siparisOzet = { cmbSiparisTuru.SelectedItem.ToString(),cmbAnaYemek.SelectedItem.ToString(), cmbAperatifler.SelectedItem.ToString(), cmbTatlilar.SelectedItem.ToString(), cmbIcecek.SelectedItem.ToString(), richTxtEkBilgi.Text };
                richSiparisOzet.Text = string.Join(",", siparisOzet);
            }
            else
            {
                MessageBox.Show("Alanlar boş bırakılamaz!");
            }
            List<dbConnection.cmdParameterType> lstParam = new List<dbConnection.cmdParameterType> {
                new dbConnection.cmdParameterType("@SiparisTuru", cmbSiparisTuru.SelectedItem.ToString()),
                new dbConnection.cmdParameterType("@SiparisDetay", richSiparisOzet.Text),
                new dbConnection.cmdParameterType("@SiparisTutar", 150),
                new dbConnection.cmdParameterType("@MusteriId", musteriId)            
            };

            DialogResult dialogResult = MessageBox.Show("Emin misiniz?", "Siparişi Onayla", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dbConnection.cmd_update_DB(srSiparisQry, lstParam) > 0)
                {
                    MessageBox.Show("Siparis Basariyla Kaydedildi.");
                }
                else
                {
                    MessageBox.Show("Hata oluştu");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        int musteriId;
        private void dtSiparisMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            musteriId = int.Parse(dtSiparisMusteri.CurrentRow.Cells[0].Value.ToString());
            txtIsım.Text = dtSiparisMusteri.CurrentRow.Cells[1].Value.ToString() + " " + dtSiparisMusteri.CurrentRow.Cells[2].Value.ToString();

        }
    }
}
