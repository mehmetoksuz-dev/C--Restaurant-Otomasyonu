using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Siparis_Programı
{
    class HelperClass
    {
        public static void ClearTextBoxes(Control.ControlCollection cc) //temizleme fonksiyonu
        {
            foreach (Control ctrl in cc)
            {
                if (ctrl.GetType() == typeof(TextBox)) //Txt icin
                {
                    (ctrl as TextBox).Clear();
                }
                if (ctrl.GetType() == typeof(MaskedTextBox)) //Msk icin
                {
                    (ctrl as MaskedTextBox).Clear();
                }
            }
        }
    }
}
