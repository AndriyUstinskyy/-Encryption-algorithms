using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography.Uc
{
    public partial class Homophonic_Uc : UserControl
    {
        public Homophonic_Uc()
        {
            InitializeComponent();
        }

        private void HomoEncrypt(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBoxHomoInput.Text))
                {
                    MessageBox.Show("Introduceti mesajul de criptat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var crypto = new HomophonicV1();
                richTextBoxHomoOutput.Text = crypto.Encrypt(richTextBoxHomoInput.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HomoDecrypt(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBoxHomoInput.Text))
                {
                    MessageBox.Show("Introduceti mesajul de decriptat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var crypto = new HomophonicV1();
                richTextBoxHomoOutput.Text = crypto.Decrypt(richTextBoxHomoInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
