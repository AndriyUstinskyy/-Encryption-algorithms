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
    public partial class PlayFair_Uc : UserControl
    {
        public PlayFair_Uc()
        {
            InitializeComponent();
        }

        private void PlayFairEncryptClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPlayFairkey.Text))
                {
                    MessageBox.Show("Introduceti cheia!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxPlayFairInput.Text))
                {
                    MessageBox.Show("Introduceti mesajul de criptat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var crypto = new PlayFair(textBoxPlayFairkey.Text);
                textBoxPlayFairOutput.Text = crypto.Encrypt(textBoxPlayFairInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlayFairDecryptClick(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPlayFairkey.Text))
                {
                    MessageBox.Show("Introduceti cheia!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxPlayFairInput.Text))
                {
                    MessageBox.Show("Introduceti mesajul de decriptat!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var crypto = new PlayFair(textBoxPlayFairkey.Text);
                textBoxPlayFairOutput.Text = crypto.Decrypt(textBoxPlayFairInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
